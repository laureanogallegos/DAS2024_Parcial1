using Microsoft.Extensions.Configuration;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows.Input;

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

        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

            try
            {

                using var command = new SqlCommand();
                //otra forma de hacerlo es usando Store Procedures
                command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                /////////////////////////
                command.Connection = connection;
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())//lee a traves de todas las filas que existen en la tabla
                {
                    var medicamento = new Medicamento();
                    medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                    medicamento.Monodroga = (Monodroga)reader["NOMBRE_MONODROGA"];
                    medicamento.VentaLibre = (bool)reader["ES_VENTA_LIBRE"];
                    medicamento.PrecioVenta = Convert.ToDecimal(reader["ES_VENTA_LIBRE"]);
                    medicamento.StockActual = Convert.ToInt64(reader["STOCK"]);
                    medicamento.StockMinimo = Convert.ToInt64(reader["STOCK_MINIMO"]);

                    // lista de droguerias                    

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

        public void Modificar(Medicamento medicamento)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();

            try
            {

               using var command = new SqlCommand();
               command.CommandText = "SP_MODIFICARMEDICAMENTO";
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Transaction = transaction;
               command.Connection = connection;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.Int).Value = medicamento.Monodroga.Nombre;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;

                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
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
               command.CommandText = "SP_AGREGARMEDICAMENTO";
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Transaction = transaction;
               command.Connection = connection;
               command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ID_DROGUERIA", System.Data.SqlDbType.Int).Value = medicamento.Monodroga.Id;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;

                // lista de droguerias                    

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
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Transaction = transaction;
                command.Connection = connection;

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
