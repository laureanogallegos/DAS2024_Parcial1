using Microsoft.Extensions.Configuration;
using Modelo.Objetos;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioMonodrogas
    {
        private static readonly Lazy<RepositorioMonodrogas> instancia = new Lazy<RepositorioMonodrogas>(()=> new RepositorioMonodrogas());
        public static RepositorioMonodrogas Instancia => instancia.Value;
        private readonly List<Monodroga> monodrogas;
        private IConfigurationRoot configuration;

        private RepositorioMonodrogas()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            monodrogas = new List<Monodroga>();
            Recuperar();
        }

        public ReadOnlyCollection<Monodroga> ListarMonodrogas()
        {
            return monodrogas.AsReadOnly();
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
                command.CommandText = "SP_RECUPERARMONODROGAS";
                
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                        var monodroga = new Monodroga()
                        {
                            Nombre = reader["NOMBRE"].ToString()
                        };
                    monodrogas.Add(monodroga);
                }
                command.Connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                connection.Close();
            }
        }

    }
}
