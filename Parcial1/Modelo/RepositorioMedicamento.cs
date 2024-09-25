using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioMedicamento
    {
        private static RepositorioMedicamento instancia;
        private List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;
        private SqlConnection connection;
        private RepositorioMedicamento()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            Recuperar();
        }

        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
                    command.CommandText = "SP_RECUPERARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE"].ToString();
                        medicamentos.Add(medicamento);
                    }
                    command.Connection.Close();
                }
                catch(SqlException ex)
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
        private bool AgregarMedicameno(Medicamento medicamento)
        {
            var estaAgregado = false;
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using SqlCommand command = new SqlCommand();
                command.Transaction = transaction;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.Parameters.Add("@NombreComercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@EsVentaLibre", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                command.Parameters.Add("@PrecioVenta", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@Stock", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@StockMinimo", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                medicamentos.Add(medicamento);
                estaAgregado = true;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return estaAgregado;
        }

        private bool Eliminar(Medicamento medicamento)
        {
            var estaEliminado = false;
            connection.Open();
            var transaction = connection.BeginTransaction();

            try
            {
                using SqlCommand command = new SqlCommand();
                command.Transaction = transaction;
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.Parameters.Add("@NombreComercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                medicamentos.Remove(medicamento);
                estaEliminado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return estaEliminado;
        }

    }
}



