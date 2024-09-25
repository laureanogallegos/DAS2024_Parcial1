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
        private static readonly Lazy<RepositorioMedicamentos> instancia = new(() => new RepositorioMedicamentos());
        public static RepositorioMedicamentos Instancia = instancia.Value;
        private List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;

        public RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            Recuperar();
        }

        public bool Agregar(Medicamento medicamento)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
                    command.Connection = connection;
                    command.Transaction = connection.BeginTransaction();
                    command.Connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_AGREGARMEDICAMENTO";
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar,50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@NOMBRE_MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                    command.ExecuteNonQuery();
                    command.Transaction.Commit();
                    command.Connection.Close();
                    medicamentos.Add(medicamento);
                    using var cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.Transaction = connection.BeginTransaction();
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                    foreach (var drogueria in medicamento.ListarDrogueria())
                    {
                        cmd.Parameters["@CUIT"].Value = drogueria.Cuit;
                        command.ExecuteNonQuery();
                    }
                    command.Transaction.Commit();
                    command.Connection.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    return false;
                }
                catch (Exception ex)
                {
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
                    command.Connection = connection;
                    command.Transaction = connection.BeginTransaction();
                    command.Connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ELIMINARMEDICAMENTO";
                    command.Parameters.Add("NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.ExecuteNonQuery();
                    command.Transaction.Commit();
                    command.Connection.Close();
                    medicamentos.Remove(medicamento);
                    return true;
                }
                catch (SqlException ex)
                {

                    connection.Close();
                    connection.Dispose();
                    return false;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    return false;
                }

        }
        public bool Modificar(Medicamento medicamentoViejo,Medicamento medicamentoNuevo)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
                    command.Connection = connection;
                    command.Transaction = connection.BeginTransaction();
                    command.Connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoViejo.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamentoNuevo.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamentoNuevo.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamentoNuevo.Stock;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamentoNuevo.StockMinimo;
                    command.Parameters.Add("@NOMBRE_MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamentoNuevo.Monodroga.Nombre;
                    command.ExecuteNonQuery();
                    command.Transaction.Commit();
                    command.Connection.Close();
                    var indice = medicamentos.IndexOf(medicamentoViejo);
                    medicamentos.Remove(medicamentoViejo);
                    medicamentos.Insert(indice,medicamentoNuevo);
                    return true;
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    return false;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    return false;
                }

        }
        public void Recuperar()
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
                        medicamento.VentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x=> x.Nombre == reader["NOMBRE_MONODROGA"].ToString());
                        medicamentos.Add(medicamento);
                    }
                    command.Connection.Close();
                    using var cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                    var reader2 = command.ExecuteReader();
                    while (reader2.Read())
                    {
                        var drogueria = new Drogueria();
                        drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == Convert.ToInt32(reader2["CUIT"]));
                        medicamento.AgregarDrogueria(drogueria);
                    }
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
        public ReadOnlyCollection<Medicamento> Listar() 
        {
            return medicamentos.AsReadOnly();
        }


    }
}
