using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private readonly static Lazy<RepositorioMedicamentos> instancia = new Lazy<RepositorioMedicamentos>(() => new RepositorioMedicamentos());
        public static RepositorioMedicamentos Instancia = instancia.Value;
        private List<Medicamento> medicamentos;

        private IConfigurationRoot configuration;
        private SqlConnection connection;
        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            Recuperar();
        }
        public ReadOnlyCollection<Medicamento> Medicamentos()
        {
            return medicamentos.AsReadOnly();
        }

        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    command.Connection = connection;
                    command.Connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"]);
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == reader["NOMBRE_MONODROGA"].ToString());


                        using var cmd = new SqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        var reader2 = cmd.ExecuteReader();
                        while (reader2.Read())
                        {
                            var drogueria = new Drogueria();
                            drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == Convert.ToInt64(reader2["CUIT"].ToString()));
                            medicamento.AgregarDrogueria(drogueria);
                        }
                        medicamentos.Add(medicamento);
                    }
                    connection.Close();
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
            bool agregado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();
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
                    cmd.Transaction = transaction;
                    cmd.Connection = connection;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                    foreach (Drogueria drog in medicamento.ListarDroguerias())
                    {
                        cmd.Parameters["@CUIT"].Value = drog.Cuit;
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    connection.Close();
                    medicamentos.Add(medicamento);
                    agregado = true;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    agregado = false;
                }
                return agregado;
            }
        }

        public bool Eliminar(Medicamento medicamento)
        {
            bool Eliminado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();
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
                    Eliminado = true;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Eliminado = false;
                }
            }
            return Eliminado;
        }
        public bool Modificar(Medicamento medicamentoModificado)
        {
            bool modificado = false;

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();
                    using var command = new SqlCommand();
                    command.Transaction = transaction;
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";

                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoModificado.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamentoModificado.EsVentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamentoModificado.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamentoModificado.Stock;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamentoModificado.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoModificado.Monodroga.Nombre;
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();
                    medicamentos.Remove(medicamentoModificado);
                    medicamentos.Add(medicamentoModificado);
                    modificado = true;
                }

                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    modificado = false;
                }
            }
            return modificado;
        }
    }
}



