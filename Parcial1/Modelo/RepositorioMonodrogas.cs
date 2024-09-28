using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioMonodrogas
    {
        private static RepositorioMonodrogas instancia;
        private List<Monodroga> monodrogas;
        private IConfigurationRoot configuration;
        private RepositorioMonodrogas()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            monodrogas = new List<Monodroga>();
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
                    command.CommandText = "SP_RECUPERARMONODROGAS";
                /////////////////////////
                command.Connection = connection;
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var monodroga = new Monodroga();
                    monodroga.Nombre = reader["NOMBRE"].ToString();
                    monodrogas.Add(monodroga);
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

        public static RepositorioMonodrogas Instancia
        { 
            get 
            {
                instancia ??= new RepositorioMonodrogas();
                return instancia;
            }
        }

        public ReadOnlyCollection<Monodroga> Monodrogas
        { 
            get => monodrogas.AsReadOnly(); 
        }

        public bool Agregar(Monodroga monodroga)
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
                SqlCommand.CommandText = "@SP_AGREGAR_MONODROGA";
                SqlCommand.Parameters.Add("@NOMBRE", System.Data.SqlDbType.NVarChar, 20).Value = monodroga.Nombre;
                SqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                monodrogas.Add(monodroga);
                fueAgregado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return fueAgregado;
        }

        public bool Modificar(Monodroga monodroga)
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
                SqlCommand.CommandText = "@SP_MODIFICAR_MONODROGA";
                SqlCommand.Parameters.Add("@NOMBRE", System.Data.SqlDbType.NVarChar, 20).Value = monodroga.Nombre;
                SqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                monodrogas.Remove(monodroga);
                monodrogas.Add(monodroga);
                fueModificado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return fueModificado;
        }

        public bool Eliminar(Monodroga monodroga)
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
                SqlCommand.CommandText = "@SP_ELIMINAR_MONODROGA";
                SqlCommand.Parameters.Add("@NOMBRE", System.Data.SqlDbType.NVarChar, 20).Value = monodroga.Nombre;
                SqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                monodrogas.Remove(monodroga);
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
