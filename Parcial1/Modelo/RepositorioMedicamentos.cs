using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    internal class RepositorioMedicamentos
    {
        public class RepositorioMedicamentos
        {
            private static RepositorioMedicamentos instancia;
            private List<Medicamento> monodrogas;
            private IConfigurationRoot configuration;
        }

        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            Recuperar();
        }


        private static readonly Lazy<RepositorioMedicamentos> _instance = new(() => new RepositorioMedicamentos());
        public static RepositorioMedicamentos Instance => _instance.Value;
        public bool Agregar(Medicamento medicamento)
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
                sqlCommand.CommandText = "sp_InsertarMedicamento";
                sqlCommand.Parameters.Add("@Nombre_commercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_commercial;
                sqlCommand.Parameters.Add("@Es_Venta_Libre", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Es_Venta_Libre;
                sqlCommand.Parameters.Add("@Precio_Venta", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Precio_Venta;
                sqlCommand.Parameters.Add("@Stock", System.Data.SqlDbType.Decimal).Value = medicamento.Stock;
                sqlCommand.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Decimal).Value = medicamento.Stock_Minimo;
                Monodroga = RepositorioMonodrogas.Instance.Listar().FirstOrDefault(Monodroga => Monodroga.Nombre == dr["Nombre"].ToString())
                sqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                medicamento.Add(Medicamento);
                estaInsertado = true;
            }
            {
                transaction.Rollback();
                connection.Close();
            }
            return estaInsertado;
        }
        public bool Eliminar(Medicamento medicamento)
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
                sqlCommand.CommandText = "sp_EliminarMedicamento";
                sqlCommand.Parameters.Add("@Nombre_commercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_commercial;
                sqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                medicamento.Remove(medicamento);
                estaEliminado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return estaEliminado;
        }
        public bool Modificar(Medicamento medicamento)
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
                sqlCommand.Parameters.Add("@Es_Venta_Libre", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Es_Venta_Libre;
                sqlCommand.Parameters.Add("@Precio_Venta", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Precio_Venta;
                sqlCommand.Parameters.Add("@Stock", System.Data.SqlDbType.Decimal).Value = medicamento.Stock;
                sqlCommand.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Decimal).Value = medicamento.Stock_Minimo;
                Monodroga = RepositorioMonodrogas.Instance.Listar().FirstOrDefault(Monodroga => Monodroga.Nombre == dr["Nombre"].ToString());
                DrogueriaMedicamento = RepositorioDrogueriaMedicamentos.Instance.Listar().FirstOrDefault(DrogueriaMedicamento => DrogueriaMedicamento.Nombre == dr["Nombre_commercial"].ToString());
                sqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                medicamento.Remove(Medicamento);
                medicamento.Add(Medicamento);
                estaModificado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return estaModificado;
        }
        public ReadOnlyCollection<Medicamento> Listar()
        {
            return Medicamento.AsReadOnly();
        }

        public static RepositorioMedicamentos Instancia
        {
            get
            {
                instancia ??= new RepositorioMedicamentos();
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> Medicamento
        {
            get => Medicamento.AsReadOnly();
        }
    }
}

    }
