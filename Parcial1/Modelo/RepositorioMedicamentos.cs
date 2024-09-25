using Microsoft.Extensions.Configuration;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Transactions;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private static readonly Lazy<RepositorioMedicamentos> instancia = new Lazy<RepositorioMedicamentos>(() => new RepositorioMedicamentos());
        public static RepositorioMedicamentos Instancia => instancia.Value;

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
                    //SP_RECUPERARDROGUERIASMEDICAMENTOS @NOMBRE_COMERCIAL NVARCHAR(50)
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.Nombre = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.EsVentaLibre = bool.Parse(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = decimal.Parse(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = int.Parse(reader["STOCK"].ToString());
                        medicamento.StockMinimo = int.Parse(reader["STOCK_MINIMO"].ToString());
                        var nombreMonodroga = reader["NOMBRE_MONODROGA"].ToString();
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(mon => mon.Nombre == nombreMonodroga);


                        using var commandDrog = new SqlCommand();
                        //otra forma de hacerlo es usando Store Procedures
                        commandDrog.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        commandDrog.CommandType = System.Data.CommandType.StoredProcedure;
                        /////////////////////////
                        commandDrog.Connection = connection;
                        commandDrog.Connection.Open();
                        commandDrog.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre;
                        var readerDrog = commandDrog.ExecuteReader();
                        while (readerDrog.Read())
                        {
                            var drogueria = new Drogueria();
                            drogueria.Cuit = long.Parse(reader["CUIT"].ToString());
                            drogueria.RazonSocial = reader["RAZON_SOCIAL"].ToString();
                            drogueria.Direccion = reader["DIRECCION"].ToString();
                            drogueria.Email = reader["EMAIL"].ToString();
                            medicamento.AgregarDrogueria(drogueria);
                        }
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

        public ReadOnlyCollection<Medicamento> Medicamentos
        {
            get => medicamentos.AsReadOnly();
        }

        public bool Agregar(Medicamento medicamento)
        {
            bool resultado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_AGREGARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var transaction = connection.BeginTransaction();
                    command.Transaction = transaction;
                    command.Connection = connection;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                    command.ExecuteNonQuery();


                    using var commandDrog = new SqlCommand();
                    commandDrog.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    commandDrog.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    commandDrog.Connection = connection;
                    commandDrog.Connection.Open();
                    commandDrog.Transaction = transaction;
                    commandDrog.Connection = connection;
                    commandDrog.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre;
                    commandDrog.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                    foreach (var drogueria in medicamento.ListarDroguerias())
                    {
                        commandDrog.Parameters["@CUIT"].Value = drogueria.Cuit;
                        commandDrog.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    connection.Close();
                    medicamentos.Add(medicamento);
                    resultado = true;
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    Console.WriteLine(ex.ToString());
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    Console.WriteLine(ex.ToString());
                }
            return resultado;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            bool resultado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_ELIMINARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var transaction = connection.BeginTransaction();
                    command.Transaction = transaction;
                    command.Connection = connection;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();

                    medicamentos.Remove(medicamento);
                    resultado = true;
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    Console.WriteLine(ex.ToString());
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    Console.WriteLine(ex.ToString());
                }
            return resultado;
        }

        public bool Modificar(Medicamento medicamentoViejo, Medicamento medicamentoNuevo)
        {
            bool resultado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var transaction = connection.BeginTransaction();
                    command.Transaction = transaction;
                    command.Connection = connection;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoNuevo.Nombre;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamentoNuevo.EsVentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamentoNuevo.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamentoNuevo.Stock;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamentoNuevo.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoNuevo.Monodroga.Nombre;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();

                    medicamentos.Remove(medicamentoViejo);
                    medicamentos.Add(medicamentoNuevo);
                    resultado = true;
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    Console.WriteLine(ex.ToString());
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    Console.WriteLine(ex.ToString());
                }

            return resultado;
        }
    }
}
