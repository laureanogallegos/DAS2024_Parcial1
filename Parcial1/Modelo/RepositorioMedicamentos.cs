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
                    connection.Open();
                    var sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    var dr = sqlCommand.ExecuteReader();
                    while (dr.Read()) 
                    {
                        var medicamento = new Medicamento
                        {
                            NombreComercial = dr["NOMBRE_COMERCIAL"].ToString(),
                            EsVentaLibre = Convert.ToBoolean(dr["ES_VENTA_LIBRE"].ToString()),
                            PrecioVenta = Convert.ToDecimal(dr["PRECIO_VENTA"].ToString()),
                            Stock = Convert.ToInt32(dr["STOCK"].ToString()),
                            StockMinimo = Convert.ToInt32(dr["STOCK_MINIMO"].ToString()),
                            Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(c => c.Nombre == dr["NOMBRE_MONODROGA"].ToString())
                        };

                        using var sqlCommand2 = new SqlCommand();
                        sqlCommand2.Connection = connection;
                        sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand2.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        sqlCommand2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        var drLinea = sqlCommand2.ExecuteReader();
                        while (drLinea.Read()) 
                        {
                            var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(d => d.Cuit == Convert.ToInt64(drLinea["CUIT"].ToString()));
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
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var isOk = false;
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                var sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.Transaction = transaction;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "SP_AGREGARMEDICAMENTO";
                sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                sqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                sqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                sqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                sqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                sqlCommand.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                sqlCommand.ExecuteNonQuery();

                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                sqlCommand.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                foreach(var droguerias in medicamento.Droguerias)
                {
                    sqlCommand.Parameters["@CUIT"].Value = droguerias.Cuit;
                    sqlCommand.ExecuteNonQuery();
                }
                transaction.Commit();
                connection.Close();
                isOk = true;
                medicamentos.Add(medicamento);
            }
            catch (SqlException ex)
            {
                transaction.Rollback(); 
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return isOk;
        }

        public bool Modificar(Medicamento medicamento)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var isOk = false;
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                var sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.Transaction = transaction;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "SP_MODIFICARMEDICAMENTO";
                sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                sqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                sqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                sqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                sqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                sqlCommand.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                sqlCommand.ExecuteNonQuery();

                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                sqlCommand.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                foreach (var droguerias in medicamento.Droguerias)
                {
                    sqlCommand.Parameters["@CUIT"].Value = droguerias.Cuit;
                    sqlCommand.ExecuteNonQuery();
                }
                transaction.Commit();
                connection.Close();
                isOk = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return isOk;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var isOk = false;
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                var sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.Transaction = transaction;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "SP_ELIMINARMEDICAMENTO";
                sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                sqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                medicamentos.Remove(medicamento);
                isOk = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return isOk;
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
