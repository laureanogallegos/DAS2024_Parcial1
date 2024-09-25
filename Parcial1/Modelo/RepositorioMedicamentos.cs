using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

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
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            try
            {
                using var command = new SqlCommand();

                command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection = connection;
                command.Connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var medicamento = new Medicamento();
                    medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                    medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"]);
                    medicamento.PrecioDeVenta = Convert.ToDecimal(reader["PRECIO_VENTA"]);
                    medicamento.StockActual = Convert.ToInt32(reader["STOCK"]);
                    medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"]);
                    medicamento.Monodroga.Nombre = reader["NOMBRE_MONODROGA"].ToString();
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
            var condicion = false;
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

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
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioDeVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga;

                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                medicamentos.Add(medicamento);
                condicion = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }

            return condicion;
        }

        public bool Modificar(Medicamento medicamento)
        {
            var condicion = false;
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

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
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioDeVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga;

                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                medicamentos.Remove(medicamento);
                medicamentos.Add(medicamento);
                condicion = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }

            return condicion;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            var condicion = false;
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

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

                medicamentos.Remove(medicamento);

                condicion = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }

            return condicion;
        }
    }
}
