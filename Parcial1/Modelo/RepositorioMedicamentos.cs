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

        public bool Agregar(Medicamento medicamento)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var isOk = false;
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    using var sqlCommand = new SqlCommand();
                    sqlCommand.Transaction = transaction;
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandText = "SP_AGREGARMEDICAMENTO";
                    sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_comercial;
                    sqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.Venta_libre;
                    sqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_venta;
                    sqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    sqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.Stock_minimo;
                    sqlCommand.Parameters.Add("@NOMBRE_MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_monodroga;
                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    isOk = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    connection.Close();
                }
                return isOk;
            }
        }
        public bool Modificar(Medicamento medicamento)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var isOk = false;
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    using var sqlCommand = new SqlCommand();
                    sqlCommand.Transaction = transaction;
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SP_MODIFICARMEDICAMENTO";
                    sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_comercial;
                    sqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.Venta_libre;
                    sqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_venta;
                    sqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    sqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.Stock_minimo;
                    sqlCommand.Parameters.Add("@NOMBRE_MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_monodroga;
                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    isOk = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    connection.Close();
                }
                return isOk;
            }
        }

        public bool Eliminar(Medicamento medicamento)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var isOk = false;
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    using var sqlCommand = new SqlCommand();
                    sqlCommand.Transaction = transaction;
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SP_ELIMINARMEDICAMENTO";
                    sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_comercial;
                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    isOk = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    connection.Close();
                }
                return isOk;
            }
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
                        medicamento.Nombre_comercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.Venta_libre = Convert.ToBoolean(reader["VENTA_LIBRE"]);
                        medicamento.Precio_venta = Convert.ToInt32(reader["PRECIO_VENTA"]);
                        medicamento.Stock = Convert.ToInt32(reader["STOCK"]);
                        medicamento.Stock_minimo = Convert.ToInt32(reader["STOCK_MINIMO"]);
                        medicamento.Nombre_monodroga = reader["NOMBRE_MONODROGA"].ToString();
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

        public ReadOnlyCollection<Medicamento> Listar()
        {
            Recuperar();
            return medicamentos.AsReadOnly();
        }
    }
}
