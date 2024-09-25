using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private static RepositorioMedicamentos instancia;
        private List<Medicamento> medicamentos  ;
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
                if (instancia == null)
                {
                    instancia= new RepositorioMedicamentos();
                }
                return instancia;
            }
        }
        public bool AgregarMedicamento (Medicamento medicamento)
        {
            var estaAgregado = false;
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open ();
            var transaction = connection.BeginTransaction() ;
            try
            {
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_AGREGARMEDICAMENTO";
                cmd.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit);
                cmd.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal);
                cmd.Parameters.Add("@STOCK", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int);
                cmd.ExecuteNonQuery();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_RECUPERARDROGUERIAS";
                cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                foreach( var drogueria in medicamento.Droguerias )
                {
                    cmd.Parameters["@CUIT"].Value = drogueria.Cuit;
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                connection.Close();
                medicamentos.Add(medicamento);
                estaAgregado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return estaAgregado;
        }
        public bool ModificarMedicamento(Medicamento medicamento)
        {
            var estaModificado = false;
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_MODIFICARMEDICAMENTO";
                cmd.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit);
                cmd.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal);
                cmd.Parameters.Add("@STOCK", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int);
                cmd.ExecuteNonQuery();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_AGREGAR_DROGUERIA_MEDICAMENTO";
                cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                foreach (var drogueria in medicamento.Droguerias)
                {
                    cmd.Parameters["@CUIT"].Value = drogueria.Cuit;
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                connection.Close();
                medicamentos.Remove(medicamento);   
                medicamentos.Add(medicamento);
                estaModificado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return estaModificado;
        }
        public bool EliminarMedicamento(Medicamento medicamento)
        {
            var ok = false;
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_ELIMINARMEDICAMENTO";
                cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50);
                medicamentos.Remove(medicamento);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return ok;
        }
      
        private void Recuperar()
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            try
            {
                using var cmd = new SqlCommand();
                cmd.CommandText = "SP_RECUPERARMEDICAMENTO";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                /////////////////////////
                cmd.Connection = connection;
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var medicamento = new Medicamento();
                    medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                    medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"]);
                    medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"]);
                    medicamento.StockActual = Convert.ToInt32(reader["STOCK"]);
                    medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"]);
                    medicamento.Monogroga = reader["NOMBRE_MONODROGA"].ToString();
                    medicamentos.Add(medicamento);
                }
                cmd.Connection.Close();
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
    }
}
