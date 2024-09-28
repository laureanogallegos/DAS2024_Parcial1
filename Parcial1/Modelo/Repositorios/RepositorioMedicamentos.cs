using Microsoft.Extensions.Configuration;
using Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Repositorios
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
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.VentaLibre = bool.Parse(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = decimal.Parse(reader["PRECIO_VENTA"].ToString());
                        medicamento.StockActual = int.Parse(reader["STOCK"].ToString());
                        medicamento.StockMinimo = int.Parse(reader["STOCK_MINIMO"].ToString());
                        medicamento.MonodrogaMedicamento = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(mo => mo.Nombre == reader["NOMBRE_MONODROGA"].ToString());

                        using var cmdDroguerias = new SqlCommand();
                        cmdDroguerias.Connection = connection;
                        cmdDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdDroguerias.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        cmdDroguerias.Parameters.Add("@NOMBRE_COMERCIAL",System.Data.SqlDbType.NVarChar,50).Value=medicamento.NombreComercial;
                        var readerDroguerias = cmdDroguerias.ExecuteReader();
                        while (readerDroguerias.Read())
                        {
                            var drogueria = RepositorioDroguerias.Instancia.ListarDroguerias().FirstOrDefault(dro => dro.Cuit == long.Parse(readerDroguerias["CUIT"].ToString()));
                            medicamento.AgregarDrogueria(drogueria);
                        }
                        medicamentos.Add(medicamento);
                    }
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    connection.Close();
                    connection.Dispose();
                }
        }

        public bool Agregar(Medicamento medicamento)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                
                try
                {
                    
                    using var command = new SqlCommand();
                    command.CommandText = "SP_AGREGARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    
                    command.Connection.Open();
                    var transaction = connection.BeginTransaction();
                    command.Transaction = transaction;

                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar,50).Value= medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value= medicamento.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar,50).Value = medicamento.MonodrogaMedicamento.Nombre;

                    command.ExecuteNonQuery();

                    var cmdDrogueria = new SqlCommand();
                    cmdDrogueria.Connection = connection;
                    cmdDrogueria.Transaction = transaction;
                    cmdDrogueria.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdDrogueria.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    cmdDrogueria.Parameters.Add("@NOMBRE_COMERCIAL",System.Data.SqlDbType.NVarChar,50).Value=medicamento.NombreComercial;
                    cmdDrogueria.Parameters.Add("@CUIT",System.Data.SqlDbType.BigInt);
                    foreach (Drogueria drogueria in medicamento.ListarDroguerias())
                    {
                        cmdDrogueria.Parameters["@CUIT"].Value = drogueria.Cuit;
                        cmdDrogueria.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    connection.Close();
                    medicamentos.Add(medicamento);
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    connection.Close();
                    connection.Dispose();
                    return false;
                }
        }

        public bool Modificar(Medicamento medicamentoActualizado)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {

                    using var command = new SqlCommand();
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;

                    command.Connection.Open();
                    var transaction = connection.BeginTransaction();
                    command.Transaction = transaction;

                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoActualizado.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamentoActualizado.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamentoActualizado.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamentoActualizado.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamentoActualizado.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoActualizado.MonodrogaMedicamento.Nombre;

                    command.ExecuteNonQuery();

                    var cmdDrogueria = new SqlCommand();
                    cmdDrogueria.Connection = connection;
                    cmdDrogueria.Transaction = transaction;
                    cmdDrogueria.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdDrogueria.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    cmdDrogueria.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoActualizado.NombreComercial;
                    cmdDrogueria.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                    foreach (Drogueria drogueria in medicamentoActualizado.ListarDroguerias())
                    {
                        cmdDrogueria.Parameters["@CUIT"].Value = drogueria.Cuit;
                        cmdDrogueria.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    connection.Close();
                    var filtrarViejoMedicamento = medicamentos.FirstOrDefault(mev=>mev.NombreComercial==medicamentoActualizado.NombreComercial);
                    medicamentos.Remove(filtrarViejoMedicamento);
                    medicamentos.Add(medicamentoActualizado);
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    connection.Close();
                    connection.Dispose();
                    return false;
                }
        }

        public bool Eliminar(Medicamento medicamento)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {

                    using var command = new SqlCommand();
                    command.CommandText = "SP_ELIMINARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;

                    command.Connection.Open();
                    var transaction = connection.BeginTransaction();
                    command.Transaction = transaction;

                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                    command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();
                    medicamentos.Remove(medicamento);
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    connection.Close();
                    connection.Dispose();
                    return false;
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
