using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioDrogueriaMedicamentos
    {
        private static RepositorioDrogueriaMedicamentos instancia;
        private List<DrogueriaMedicamento> drogueriaMedicamentos;
        private IConfigurationRoot configuration;
    }

    private RepositorioDrogueriaMedicamentos()
    {
        configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
        DrogueriaMedicamento = new List<DrogueriaMedicamento>();
        Recuperar();
    }
    private static readonly Lazy<RepositorioDrogueriaMedicamentos> _instance = new(() => new RepositorioDrogueriaMedicamentos());
    public static RepositorioDrogueriaMedicamentos Instance => _instance.Value;
    public bool Agregar(RepositorioDroguerias repositorioDroguerias)
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
            sqlCommand.CommandText = "sp_InsertarDrogueriaMedicamento";
            Medicamento = RepositorioMedicamentos.Instance.Listar().FirstOrDefault(Medicamento => Medicamento.Nombre == dr["Nombre_commercial"].ToString());
            Drogueria = RepositorioDroguerias.Instance.Listar().FirstOrDefault(Drogueria => Drogueria.Nombre == dr["Cuit"].ToString());
            sqlCommand.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();

            DrogueriaMedicamento.Add(DrogueriaMedicamento);
            estaInsertado = true;
        }
            {
            transaction.Rollback();
            connection.Close();
        }
        return estaInsertado;
    }
