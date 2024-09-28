using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private readonly static Lazy<RepositorioMedicamentos> instancia = new(() => new RepositorioMedicamentos());
        public static RepositorioMedicamentos Instancia = instancia.Value;
        private List<Medicamento> medicamentos;

        private IConfigurationRoot configuration;
        private SqlConnection connection;

        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            //connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            Recuperar();
        }
        public ReadOnlyCollection<Medicamento> Medicamentos
        {
            get => medicamentos.AsReadOnly();
        }
        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                //connection.Open();
                //var transaction = connection.BeginTransaction();
                try
                {
                    using var sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    sqlCommand.Connection = connection;
                    sqlCommand.Connection.Open();
                    var reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        var medicamento = new Medicamento()
                        {
                            NombreComercial = reader["NOMBRE_COMERCIAL"].ToString(),
                            VentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"]),
                            PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"]),
                            StockActual = Convert.ToInt32(reader["STOCK"]),
                            StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"]),
                            Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == reader["NOMBRE_MONODROGA"].ToString())
                        };

                        medicamentos.Add(medicamento);

                        var cmd = new SqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                        var dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {

                            Drogueria drogueria = new Drogueria();
                            drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == Convert.ToInt64(dr["CUIT"]));
                            //Drogueria drogueria = new Drogueria()
                            //{
                            //    Cuit = Convert.ToInt16(dr["CUIT"]),
                            //    RazonSocial = dr["RAZON_SOCIAL"].ToString(),
                            //    Direccion = dr["DIRECCION"].ToString(),
                            //    Email = dr["EMAIL"].ToString()

                            //};
                            medicamento.AgregarDrogueria(drogueria);
                        }
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
        }
        public bool Agregar(Medicamento medicamento)
        {
            bool insertado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
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
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
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
                    insertado = true;

                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    insertado = false;
                }
            return insertado;
        }
        public bool Eliminar(Medicamento medicamento)
        {

            bool estaEliminado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))


                try
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();
                    using var sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.Transaction = transaction;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SP_ELIMINARMEDICAMENTO";
                    sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();

                    medicamentos.Remove(medicamento);
                    estaEliminado = true;
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
            return estaEliminado;
        }
        public bool Modificar(Medicamento medicamentoMod)
        {

            bool insertado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))


                try
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();
                    using var command = new SqlCommand();
                    command.Transaction = transaction;
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";


                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoMod.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamentoMod.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamentoMod.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamentoMod.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamentoMod.StockMinimo;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoMod.Monodroga.Nombre;
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();
                    medicamentos.Remove(medicamentoMod);
                    medicamentos.Add(medicamentoMod);
                    insertado = true;

                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();

                    insertado = false;
                }
            return insertado;
        }
    }
}

