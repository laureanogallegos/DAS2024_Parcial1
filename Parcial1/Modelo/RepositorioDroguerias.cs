using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

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
        private static readonly Lazy<RepositorioDroguerias> _instance = new(() => new RepositorioDroguerias());
        public static RepositorioDroguerias Instance => _instance.Value;
        public bool Agregar(Drogueria drogueria)
        {
            var estaInsertado = false;
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var sqlCommand = new SqlCommand();
                sqlCommand.Transaction = transaction;
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_InsertarDrogueria";
                sqlCommand.Parameters.Add("@cuit", System.Data.SqlDbType.Decimal).Value = drogueria.Cuit;
                sqlCommand.Parameters.Add("@RazonSocial", System.Data.SqlDbType.NVarChar, 150).Value = drogueria.RazonSocial;
                sqlCommand.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar, 150).Value = drogueria.Direccion;
                sqlCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 150).Value = drogueria.Email;
                sqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                categorias.Add(Drogueria);
                estaInsertado = true;
            }
            {
                transaction.Rollback();
                connection.Close();
            }
            return estaInsertado;
        }

        public bool Eliminar(Drogueria drogueria)
        {
            var estaEliminado = false;
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var sqlCommand = new SqlCommand();
                sqlCommand.Transaction = transaction;
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_EliminarDrogueria";
                sqlCommand.Parameters.Add("@cuit", System.Data.SqlDbType.Decimal).Value = drogueria.Cuit;
                sqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                droguerias.Remove(drogueria);
                estaEliminado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return estaEliminado;
        }

        public bool Modificar(Drogueria drogueria)
        {
            var estaModificado = false;
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var sqlCommand = new SqlCommand();
                sqlCommand.Transaction = transaction;
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_ModificarDrogueria";
                sqlCommand.Parameters.Add("@cuit", System.Data.SqlDbType.Decimal).Value = drogueria.Cuit;
                sqlCommand.Parameters.Add("@RazonSocial", System.Data.SqlDbType.NVarChar, 150).Value = drogueria.RazonSocial;
                sqlCommand.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar, 150).Value = drogueria.Direccion;
                sqlCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 150).Value = drogueria.Email;
                sqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                droguerias.Remove(Drogueria);
                droguerias.Add(Drogueria);
                estaModificado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return estaModificado;
        }
        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

            try
            {
                using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlCommand.CommandText = "SP_RECUPERARDROGUERIAS";
                        /////////////////////////
                SqlCommand.Connection = connection;
                SqlCommand.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())//lee a traves de todas las filas que existen en la tabla
                {
                    //por cada fila que creo tengo que asignar manualmente cada columna con cada propiedad
                    var drogueria = new Drogueria();
                    drogueria.Cuit = Convert.ToInt64(reader["CUIT"].ToString());
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

        public ReadOnlyCollection<Drogueria> Listar()
        {
            return droguerias.AsReadOnly();
        }

        public static RepositorioDroguerias Instancia
        {
            get
            {
                instancia ??= new RepositorioDroguerias();
                return instancia;
            }
        }

        public ReadOnlyCollection<Drogueria> Droguerias
        {
            get => droguerias.AsReadOnly();
        }
    }
}

