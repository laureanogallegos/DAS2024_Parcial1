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
            RecuperarMedicamento();
        }

        private static readonly Lazy<RepositorioMedicamentos> _instance = new(() => new RepositorioMedicamentos());

        // Step 3: Provide a public static method to get the instance of the class
        public static RepositorioMedicamentos Instance => _instance.Value;


        public void RecuperarMedicamento()
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
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                        var nombreMonodroga = reader["NOMBRE_MONODROGA"].ToString();
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

        public static RepositorioMedicamentos Instancia
        {
            get
            {
                instancia ??= new RepositorioMedicamentos();
                return instancia;
            }
        }

        public bool AgregarMedicamento(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal, 10).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.ExecuteNonQuery();


                using var commandMonodrogas = new SqlCommand();
                commandMonodrogas.CommandType = System.Data.CommandType.StoredProcedure;
                commandMonodrogas.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                commandMonodrogas.Connection = connection;
                commandMonodrogas.Transaction = sqlTransaction;
                commandMonodrogas.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                commandMonodrogas.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                foreach (var drogueria in medicamento.Droguerias)
                {
                    commandMonodrogas.Parameters["@NOMBRE_COMERCIAL"].Value = drogueria.Cuit;
                    commandMonodrogas.ExecuteNonQuery();

                }
                sqlTransaction.Commit();
                connection.Close();
                ok = true;
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;


        }

        public bool ModificarMedicamento(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal, 10).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.ExecuteNonQuery();


                using var commandMonodrogas = new SqlCommand();
                commandMonodrogas.CommandType = System.Data.CommandType.StoredProcedure;
                commandMonodrogas.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                commandMonodrogas.Connection = connection;
                commandMonodrogas.Transaction = sqlTransaction;
                commandMonodrogas.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                commandMonodrogas.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                foreach (var drogueria in medicamento.Droguerias)
                {
                    commandMonodrogas.Parameters["@NOMBRE_COMERCIAL"].Value = drogueria.Cuit;
                    commandMonodrogas.ExecuteNonQuery();

                }
                sqlTransaction.Commit();
                connection.Close();
                ok = true;
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;



        }

        public bool EliminarMedicamento(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.ExecuteNonQuery();


                sqlTransaction.Commit();
                connection.Close();
                ok = true;
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }
    }
}
