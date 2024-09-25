using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioDroguerias
    {
        private readonly List<Drogueria> droguerias;
        private readonly SqlConnection connection;

        private RepositorioDroguerias()
        {
            droguerias = new List<Drogueria>();
            var connectionString = ConnectionString.GetConnectionString();
            connection = new SqlConnection(connectionString);
            Recuperar();



        }

        private static readonly Lazy<RepositorioDroguerias> instance = new(() => new RepositorioDroguerias());

        // Step 3: Provide a public static method to get the instance of the class
        public static RepositorioDroguerias Instance => instance.Value;
        public ReadOnlyCollection<Drogueria> Listar()
        {
            return droguerias.AsReadOnly();
        }

        private void Recuperar()
        {
            connection.Open();
            try
            {
                using var sqlcommand = new SqlCommand();
                sqlcommand.Connection = connection;
                sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcommand.CommandText = "SP_RECUPERARDROGUERIAS";
                var dr = sqlcommand.ExecuteReader();
                while (dr.Read())
                {
                    var drogueria = new Drogueria();
                    drogueria.Cuit = Convert.ToInt64(dr["CUIT"].ToString());
                    drogueria.RazonSocial = dr["RAZON_SOCIAL"].ToString();
                    drogueria.Direccion = dr["DIRECCION"].ToString();
                    drogueria.Email = dr["EMAIL"].ToString();
                    droguerias.Add(drogueria);

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
