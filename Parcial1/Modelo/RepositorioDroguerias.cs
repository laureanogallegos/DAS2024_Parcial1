using Microsoft.Extensions.Configuration;
using Modelo.Objetos;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioDroguerias
    {
        private static readonly Lazy<RepositorioDroguerias> instancia = new Lazy<RepositorioDroguerias>(()=>new RepositorioDroguerias());
        public static RepositorioDroguerias Instancia => instancia.Value;
        private readonly List<Drogueria> droguerias;
        private IConfigurationRoot configuration;

        private RepositorioDroguerias()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            droguerias = new List<Drogueria>();
            Recuperar();
        }

        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            return droguerias.AsReadOnly();
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
                command.CommandText = "SP_RECUPERARDROGUERIAS";
                
                /////////////////////////

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
                Console.WriteLine(ex.ToString());
                connection.Close();
            }

        }

    }
}
