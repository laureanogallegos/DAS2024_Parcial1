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

        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    command.Connection = connection;
                    command.Connection.Open();

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //por cada fila que creo tengo que asignar manualmente cada columna con cada propiedad
                        var medicamento = new Medicamento()
                        {
                            NombreComercial = reader["NOMBRE_COMERCIAL"].ToString(),
                            VentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"]),
                            PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"]),
                            StockActual = Convert.ToInt32(reader["STOCK"]),
                            StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"]),
                            Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == reader["NOMBRE_MONODROGA"].ToString())

                        };

                        // Lectura de las droguerias
                        command.Parameters.Clear();
                        command.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        var drDrogueria = command.ExecuteReader();
                        while (drDrogueria.Read())
                        {
                            var cuitDrogueria = drDrogueria["CUIT"].ToString();
                            var drogueria = RepositorioDroguerias.Instancia.ListaDroguerias.FirstOrDefault(x => x.Cuit == cuitDrogueria);
                            medicamento.AgregarDrogueria(drogueria);
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

        public bool Agregar(Medicamento medicamento)
        {
            var fueAgregado = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {

                using var SqlCommand = new SqlCommand();
                SqlCommand.Transaction = transaction;
                SqlCommand.Connection = connection;
                SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommand.CommandText = "@SP_AGREGARMEDICAMENTO";
                SqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                SqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                SqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                SqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                SqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                SqlCommand.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar,50).Value = medicamento.Monodroga.Nombre;
                SqlCommand.ExecuteNonQuery();

                using var SqlCommand2 = new SqlCommand();
                SqlCommand2.Connection = connection;
                SqlCommand2.Transaction = transaction;
                SqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommand2.CommandText = "@SP_AGREGAR_DROGUERIASMEDICAMENTO";
                SqlCommand2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                SqlCommand2.Parameters.Add("@CUIT", System.Data.SqlDbType.NVarChar, 20);
                foreach (var drogueria in medicamento.ListadoDroguerias)
                {
                    SqlCommand2.Parameters["@CUIT"].Value = drogueria.Cuit;
                    SqlCommand2.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();
                medicamentos.Add(medicamento);
                fueAgregado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return fueAgregado;
        }

        public bool Modificar(Medicamento medicamento)
        {
            var fueModificado = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {

                using var SqlCommand = new SqlCommand();
                SqlCommand.Transaction = transaction;
                SqlCommand.Connection = connection;
                SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommand.CommandText = "@SP_MODIFICARMEDICAMENTO";
                SqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                SqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                SqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                SqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                SqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                SqlCommand.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                SqlCommand.ExecuteNonQuery();

                using var SqlCommand2 = new SqlCommand();
                SqlCommand2.Connection = connection;
                SqlCommand2.Transaction = transaction;
                SqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommand2.CommandText = "@SP_AGREGAR_DROGUERIASMEDICAMENTO";
                SqlCommand2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                SqlCommand2.Parameters.Add("@CUIT", System.Data.SqlDbType.NVarChar, 20);
                foreach (var item in medicamento.ListadoDroguerias)
                {
                    SqlCommand2.Parameters["@CUIT"].Value = item.Cuit;
                    SqlCommand2.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();
                medicamentos.Remove(medicamento);
                medicamentos.Add(medicamento);
                fueModificado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return fueModificado;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            var fueEliminado = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {

                using var SqlCommand = new SqlCommand();
                SqlCommand.Transaction = transaction;
                SqlCommand.Connection = connection;
                SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommand.CommandText = "@SP_ELIMINARMEDICAMENTO";
                SqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
     
                SqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                medicamentos.Remove(medicamento);
                fueEliminado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return fueEliminado;
        }


    }
}
