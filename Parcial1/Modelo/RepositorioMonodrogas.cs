using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioMonodrogas
    {
        private readonly List<Monodroga> monodrogas;
        private readonly SqlConnection connection;

        private RepositorioMonodrogas()
        {
            monodrogas = new List<Monodroga>();
            var connectionString = ConnectionString.GetConnectionString();
            connection = new SqlConnection(connectionString);
            Recuperar();



        }

        private static readonly Lazy<RepositorioMonodrogas> instance = new(() => new RepositorioMonodrogas());

       
        public static RepositorioMonodrogas Instance => instance.Value;
        public ReadOnlyCollection<Monodroga> Listar()
        {
            return monodrogas.AsReadOnly();
        }

        private void Recuperar()
        {
            connection.Open();
            try
            {
                using var sqlcommand = new SqlCommand();
                sqlcommand.Connection = connection;
                sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcommand.CommandText = "SP_RECUPERARMONODROGAS";
                var dr = sqlcommand.ExecuteReader();
                while (dr.Read())
                {
                    var monodroga = new Monodroga();
                    monodroga.Nombre = dr["NOMBRE"].ToString();
                    monodrogas.Add(monodroga);

                }
                sqlcommand.Connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }

    }
}
