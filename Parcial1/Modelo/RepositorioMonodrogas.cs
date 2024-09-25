using Microsoft.Extensions.Configuration;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Transactions;

namespace Modelo
{
    public class RepositorioMonodrogas
    {
        private static readonly Lazy<RepositorioMonodrogas> instancia = new Lazy<RepositorioMonodrogas>(() => new RepositorioMonodrogas());
        public static RepositorioMonodrogas Instancia => instancia.Value;

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
                command.CommandText = "SP_RECUPERARMONODROGAS";
                command.CommandType = System.Data.CommandType.StoredProcedure;
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

        public ReadOnlyCollection<Monodroga> Monodrogas
        { 
            get => monodrogas.AsReadOnly(); 
        }
    }
}
