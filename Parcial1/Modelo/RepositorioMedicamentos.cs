using Microsoft.Extensions.Configuration;
using Modelo.Objetos;
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
        private static readonly Lazy<RepositorioMedicamentos> instancia = new Lazy<RepositorioMedicamentos>(() => new RepositorioMedicamentos());
        public static RepositorioMedicamentos Instancia => instancia.Value;

        private readonly List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;

        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            Recuperar();
        }

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
                command.Connection.Open();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_RECUPERARMEDICAMENTOS";

                var rd = command.ExecuteReader();
                while (rd.Read())
                {
                        Medicamento medicamento = new Medicamento()
                        {
                            NombreComercial = rd["NOMBRE_COMERCIAL"].ToString(),
                            VentaLibre = rd["ES_VENTA_LIBRE"].ToString(),
                            PrecioVenta = decimal.Parse(rd["STOCK"].ToString()),
                            StockActual = int.Parse(rd["STOCK"].ToString()),
                            stockMinimo = int.Parse(rd["STOCK_MINIMO"].ToString()),
                            monodroga = RepositorioMonodrogas.Instancia.ListarMonodrogas().FirstOrDefault(dro => dro.Nombre == rd["NOMBRE_MONODROGA"].ToString())
};
                    medicamentos.Add(medicamento);
                    
                    using var commandDrog = new SqlCommand();
                        commandDrog.Connection = connection;
                        commandDrog.CommandType = System.Data.CommandType.StoredProcedure;
                        commandDrog.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS ";
                        commandDrog.Parameters.Add("@NombreComercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    var drDroguerias = commandDrog.ExecuteReader();
                    while (drDroguerias.Read())
                    {

                            Drogueria drogeria = new Drogueria()
                            {
                                Cuit = long.Parse(drDroguerias["CUIT"].ToString()),
                                RazonSocial = drDroguerias["RAZON_SOCIAL"].ToString(),
                                Direccion = drDroguerias["DIRECCION"].ToString(),
                                Email = drDroguerias["EMAIl"].ToString()
    };
                        medicamento.AgregarDrogueria(drogeria);
                    };

                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                connection.Close();
            }
        }

        public bool Agregar(Medicamento medicamento)
        {

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    connection.Open();
                    var transction = connection.BeginTransaction();
                    using var cmd = new SqlCommand();
                    try
                    {
                        cmd.Connection = connection;
                        cmd.Transaction = transction;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "SP_AGREGARMEDICAMENTO";
                        cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        cmd.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        cmd.Parameters.Add("@STOCK", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        cmd.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        cmd.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                        cmd.ExecuteNonQuery();

                        var cmdDroguerias = new SqlCommand();
                        cmdDroguerias.Connection = connection;
                        cmdDroguerias.Transaction = transction;
                        cmdDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdDroguerias.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                        foreach (Drogueria dro in medicamento.LeerDroguerias())
                        {
                            cmdDroguerias.Parameters.Add("@NombreComercial",System.Data.SqlDbType.NVarChar,50).Value=medicamento.NombreComercial;
                            cmdDroguerias.Parameters.Add("@Cuit",System.Data.SqlDbType.BigInt).Value=dro.Cuit;
                        }
                        cmdDroguerias.ExecuteNonQuery();
                        transction.Commit();
                        connection.Close();
                        medicamentos.Add(medicamento);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transction.Rollback();
                        connection.Close();
                        Console.WriteLine(ex.ToString());
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.ToString());
                    return false;
                }
           
        }

        public bool Eliminar(Medicamento medicamento)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    connection.Open();
                    var transactio = connection.BeginTransaction();
                    using var cmd = new SqlCommand();
                    try
                    {
                        cmd.Connection = connection;
                        cmd.Transaction = transactio;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "SP_ELIMINARMEDICAMENTO";
                        cmd.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                        transactio.Commit();
                        connection.Close();
                        medicamentos.Remove(medicamento);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transactio.Rollback();
                        connection.Close();
                        Console.WriteLine(ex.ToString());
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.ToString);
                    return false;
                }
        }

        public bool Modificar(Medicamento medicamento, Medicamento medicamentoNuevo)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                using var cmd = new SqlCommand();

                try
                {
                    cmd.Transaction = transaction;
                    cmd.Connection = connection;
                    cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar,50).Value=medicamento.NombreComercial;
                    cmd.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoNuevo.VentaLibre;
                    cmd.Parameters.Add("@PRECIO_VENTA DECIMAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoNuevo.PrecioVenta;
                    cmd.Parameters.Add("@STOCK", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoNuevo.StockActual;
                    cmd.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoNuevo.stockMinimo;
                    cmd.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoNuevo.monodroga.Nombre;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    return true;
                     
                }
                catch (SqlException ex)
                {
                    
                    Console.Write(ex.ToString());
                    connection.Close();
                    return false;
                }
            }
        }
    }
}
