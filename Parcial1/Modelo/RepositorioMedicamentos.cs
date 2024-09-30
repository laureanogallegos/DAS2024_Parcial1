using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private static RepositorioMedicamentos instancia;
        private List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;
        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            Recuperar();
        }

        private static readonly Lazy<RepositorioMedicamentos> instance = new(() => new RepositorioMedicamentos());

        // Step 3: Provide a public static method to get the instance of the class
        public static RepositorioMedicamentos Instance => instance.Value;



        public ReadOnlyCollection<Medicamento> Listar()
        {
            return medicamentos.AsReadOnly();
        }

        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                
                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento
                        {
                            NombreComercial = reader["NOMBRE_COMERCIAL"].ToString(),
                            EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString()),
                            PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString()),
                            Stock = Convert.ToInt32(reader["STOCK"].ToString()),
                            StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString()),
                            Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(monodroga => monodroga.Nombre == reader["NOMBRE_MONODROGA"].ToString())
                        };
                        medicamentos.Add(medicamento);

                        using var cmd= new SqlCommand();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        cmd.Connection = connection;
                        cmd.Parameters.Add("NOMBRE_COMERCIAL",System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        var reader2 = cmd.ExecuteReader();
                        while (reader2.Read())
                        {
                            var drogueria = new Drogueria();
                            drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == Convert.ToInt64(reader2["CUIT"]));
                            medicamento.AgregarDrogueria(drogueria);
                        }
                        
                    }
                    command.Connection.Close();
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
        }

        public void Agregar(Medicamento medicamento)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                command.Transaction = transaction;
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                command.ExecuteNonQuery();

                using var cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                cmd.Connection = connection;
                cmd.Parameters.Add("NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                
                foreach (var drogueria in medicamento.ListarDrogueria())
                {
                    cmd.Parameters["@CUIT"].Value = drogueria.Cuit;
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();

                medicamentos.Add(medicamento);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                    
            }
        }

        public void Modificar(Medicamento medicamento)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                command.Transaction = transaction;
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_MODIFICARMEDICAMENTO";
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                command.ExecuteNonQuery();

                using var cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                cmd.Connection = connection;
                cmd.Parameters.Add("NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                foreach (var drogueria in medicamento.ListarDrogueria())
                {
                    cmd.Parameters["@CUIT"].Value = drogueria.Cuit;
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();

                medicamentos.Add(medicamento);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();

            }
        }

        public void Eliminar(Medicamento medicamento)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                command.Transaction = transaction;
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                medicamentos.Remove(medicamento);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
        }



        public static RepositorioMedicamentos Instancia
        {
            get
            {
                instancia ??= new RepositorioMedicamentos();
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> Medicamentos
        {
            get => medicamentos.AsReadOnly();
        }

        


    }
}
