using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;

        public RepositorioMedicamentos()
        {
            medicamentos = new List<Medicamento>();
            var connectionString = ConfigurationHelper.GetConfiguration("appSettings.json");
            
            Recuperar();
        }

        private static readonly Lazy<RepositorioMedicamentos> instancia = new(() => new RepositorioMedicamentos());
        public static RepositorioMedicamentos Instancia = instancia.Value;


        public ReadOnlyCollection<Medicamento> ListarMedicamento()
        {
            return medicamentos.AsReadOnly();
        }

        public bool Agregar(Medicamento medicamento)
        {
            var isOk = false;
            
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var transaccion = connection.BeginTransaction();
            try
            {
                using var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.Transaction = transaccion;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_AGREGARMEDICAMENTO";
                cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.VarChar, 50).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.TipoVenta;
                cmd.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                cmd.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                cmd.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                cmd.Parameters.Add("@MONODROGA ", System.Data.SqlDbType.VarChar).Value = medicamento.Monodroga;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                using var cmr = new SqlCommand();
                cmr.Connection = connection;
                cmr.Transaction = transaccion;
                cmr.CommandType = System.Data.CommandType.StoredProcedure;
                cmr.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO ";
                cmr.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.VarChar, 50).Value = medicamento.NombreComercial;
                cmr.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                foreach (var drogueria in medicamento.Droguerias)
                {
                    cmr.Parameters["CUIT"].Value = drogueria.Cuit;
                    cmr.ExecuteNonQuery();
                }
                transaccion.Commit();


                medicamentos.Add(medicamento);
                isOk = true;

            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                return isOk;
            }
            finally
            {
                connection.Close();
            }
            return isOk;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            var isOk = false;

            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var transaccion = connection.BeginTransaction();
            try
            {
                using var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.Transaction = transaccion;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_ELIMINARMEDICAMENTO";
                cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.VarChar, 50).Value = medicamento.NombreComercial;
        
                cmd.ExecuteNonQuery();
                
                transaccion.Commit();


                medicamentos.Remove(medicamento);
                isOk = true;

            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                return isOk;
            }
            finally
            {
                connection.Close();
            }
            return isOk;
        }

        public bool Modificar(Medicamento medicamento)
        {
            var isOk = false;

            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var transaccion = connection.BeginTransaction();
            try
            {
                using var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.Transaction = transaccion;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_MODIFICARMEDICAMENTO";
                cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.VarChar, 50).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.TipoVenta;
                cmd.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                cmd.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                cmd.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                cmd.Parameters.Add("@MONODROGA ", System.Data.SqlDbType.VarChar).Value = medicamento.Monodroga;
                cmd.ExecuteNonQuery();


                using var cmr = new SqlCommand();
                cmr.Connection = connection;
                cmr.Transaction = transaccion;
                cmr.CommandType = System.Data.CommandType.StoredProcedure;
                cmr.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO ";
                cmr.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.VarChar, 50).Value = medicamento.NombreComercial;
                cmr.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                foreach (var drogueria in medicamento.Droguerias)
                {
                    cmr.Parameters["CUIT"].Value = drogueria.Cuit;
                    cmr.ExecuteNonQuery();
                }
                transaccion.Commit();

                medicamentos.Remove(medicamento);
                medicamentos.Add(medicamento);
                isOk = true;

            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                return isOk;
            }
            finally
            {
                connection.Close();
            }
            return isOk;
        }

        public void Recuperar()
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand();
            try
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_RECUPERARMEDICAMENTOS";
                var dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    var medicamento = new Medicamento();
                    medicamento.NombreComercial = dr["NOMBRE_COMERCIAL"].ToString();
                    medicamento.TipoVenta = dr["ES_VENTA_LIBRE"].ToString();
                    medicamento.PrecioVenta = Convert.ToDecimal(dr["PRECIO_VENTA"].ToString());
                    medicamento.StockActual = Convert.ToInt32(dr["STOCK"].ToString());
                    medicamento.StockMinimo = Convert.ToInt32(dr["STOCK_MINIMO"].ToString());
                    var nombMonodroga = dr["NOMBRE_MONODROGA"].ToString();
                    medicamento.Monodroga =  RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(c => c.Nombre == nombMonodroga);

                    using var cmr = new SqlCommand();
                    cmr.CommandType = System.Data.CommandType.StoredProcedure;
                    cmr.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                    cmr.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.VarChar, 50).Value = medicamento.NombreComercial;
                    cmr.Connection = connection;
                    var readerMedicamentos = cmr.ExecuteReader();
                    while (readerMedicamentos.Read())
                    {
                        var cuit = Convert.ToInt64(readerMedicamentos["CUIT"].ToString());
                        var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == cuit );
                        medicamento.Agregar(drogueria);
                    }
                    medicamentos.Add(medicamento);
                }
            }
            catch(SqlException ex)
            {
                connection.Close();
                connection.Dispose();
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
