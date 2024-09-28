using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Transactions;

namespace Modelo
{
    public class RepositorioDroguerias
    {
        private static RepositorioDroguerias instancia;
        private List<Drogueria> droguerias;
        private IConfigurationRoot configuration;
        private RepositorioDroguerias()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            droguerias = new List<Drogueria>();
            Recuperar();
        }

        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

            try
            {
                using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARDROGUERIAS";
                /////////////////////////
                command.Connection = connection;
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())//lee a traves de todas las filas que existen en la tabla
                {
                    //por cada fila que creo tengo que asignar manualmente cada columna con cada propiedad
                    var drogueria = new Drogueria();
                    drogueria.Cuit = (reader["CUIT"].ToString());
                    drogueria.RazonSocial = reader["RAZON_SOCIAL"].ToString();
                    drogueria.Direccion = reader["DIRECCION"].ToString();
                    drogueria.Email = reader["EMAIL"].ToString();
                    droguerias.Add(drogueria);
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

        public static RepositorioDroguerias Instancia
        {
            get
            {
                instancia ??= new RepositorioDroguerias();
                return instancia;
            }
        }

        public ReadOnlyCollection<Drogueria> ListaDroguerias
        {
            get => droguerias.AsReadOnly();
        }

        public bool Agregar(Drogueria drogueria)
        {
            var fueAgregado = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                
                using var SqlCommand = new SqlCommand();
                SqlCommand.Transaction = transaction;
                SqlCommand.Connection = connection;
                SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommand.CommandText = "@SP_AGREGAR_DROGUERIA";
                SqlCommand.Parameters.Add("@CUIT", System.Data.SqlDbType.NVarChar,20).Value = drogueria.Cuit;
                SqlCommand.Parameters.Add("@RAZONSOCIAL", System.Data.SqlDbType.NVarChar, 20).Value = drogueria.RazonSocial;
                SqlCommand.Parameters.Add("@DIRECCION", System.Data.SqlDbType.NVarChar, 20).Value = drogueria.Direccion;
                SqlCommand.Parameters.Add("@EMAIL", System.Data.SqlDbType.NVarChar, 20).Value = drogueria.Email;
                SqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                droguerias.Add(drogueria);
                fueAgregado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return fueAgregado;
        }

        public bool Modificar(Drogueria drogueria)
        {
            var fueModificado = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {

                using var SqlCommand = new SqlCommand();
                SqlCommand.Transaction = transaction;
                SqlCommand.Connection = connection;
                SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommand.CommandText = "@SP_MODIFICAR_DROGUERIA";
                SqlCommand.Parameters.Add("@CUIT", System.Data.SqlDbType.NVarChar, 20).Value = drogueria.Cuit;
                SqlCommand.Parameters.Add("@RAZONSOCIAL", System.Data.SqlDbType.NVarChar, 20).Value = drogueria.RazonSocial;
                SqlCommand.Parameters.Add("@DIRECCION", System.Data.SqlDbType.NVarChar, 20).Value = drogueria.Direccion;
                SqlCommand.Parameters.Add("@EMAIL", System.Data.SqlDbType.NVarChar, 20).Value = drogueria.Email;
                SqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                droguerias.Remove(drogueria);
                droguerias.Add(drogueria);
                fueModificado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return fueModificado;
        }
        public bool Eliminar(Drogueria drogueria)
        {
            var fueEliminado = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();

            try
            {

                using var SqlCommand = new SqlCommand();
                SqlCommand.Transaction = transaction;
                SqlCommand.Connection = connection;
                SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommand.CommandText = "@SP_ELIMINAR_DROGUERIA";
                SqlCommand.Parameters.Add("@CUIT", System.Data.SqlDbType.NVarChar, 20).Value = drogueria.Cuit;

                SqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                droguerias.Remove(drogueria);
                fueEliminado = true;
            }
            catch (Exception ex)
            {
               transaction.Rollback();
                connection.Close();
            }
            return fueEliminado;
        }

    }
}
