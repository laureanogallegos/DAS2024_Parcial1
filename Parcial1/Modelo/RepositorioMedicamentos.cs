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
                            EsVentaLibre = reader["ES_VENTA_LIBRE"].Equals(true),
                            PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString()),
                            Stock = Convert.ToInt16(reader["STOCK"].ToString()),
                            StockMinimo = Convert.ToInt16(reader["STOCK_MINIMO"].ToString()),
                            Monodroga = RepositorioMonodrogas.Instancia.Listar().FirstOrDefault(monodroga => monodroga.Nombre == reader["CodigoCategoria"].ToString())

                            //medicamento.Monodrogas = reader["NOMBRE_MONODROGA"].ToString();
                        };
                        medicamentos.Add(medicamento);
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

        private void Agregar(Medicamento medicamento)
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

        private void Modificar(Medicamento medicamento)
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
