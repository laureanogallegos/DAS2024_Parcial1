using Microsoft.Extensions.Configuration;
using Modelo;

using System.Collections.ObjectModel;
using System.Data.SqlClient;
namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private static RepositorioMedicamentos instancia;
        private List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;

        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            Recuperar();
        }

        

        public static RepositorioMedicamentos Instancia
        {
            get
            {
                instancia ??= new RepositorioMedicamentos();
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> Medicamentos
        {
            get => medicamentos.AsReadOnly();
        }

        public bool Agregar(Medicamento medicamento)
        {
            var estaInsertado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;
                        command.CommandText = "SP_AGREGARMEDICAMENTO";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                        command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                        command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                        command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                        command.Parameters.Add("@NOMBRE_MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;

                        command.ExecuteNonQuery();

                        foreach (var drogueria in medicamento.Droguerias)
                        {
                            using (var cmdDrogueria = new SqlCommand())
                            {
                                cmdDrogueria.Connection = connection;
                                cmdDrogueria.Transaction = transaction;
                                cmdDrogueria.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                                cmdDrogueria.CommandType = System.Data.CommandType.StoredProcedure;

                                cmdDrogueria.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                                cmdDrogueria.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;

                                cmdDrogueria.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        estaInsertado = true;
                        medicamentos.Add(medicamento);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                connection.Close();
            }
            return estaInsertado;
        }

        public bool Modificar(Medicamento medicamento)
        {
            var estaModificado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;
                        command.CommandText = "SP_MODIFICARMEDICAMENTO";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                        command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                        command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                        command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                        command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;

                        command.ExecuteNonQuery();

                        foreach (var drogueria in medicamento.Droguerias)
                        {
                            using (var cmdDrogueria = new SqlCommand())
                            {
                                cmdDrogueria.Connection = connection;
                                cmdDrogueria.Transaction = transaction;
                                cmdDrogueria.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                                cmdDrogueria.CommandType = System.Data.CommandType.StoredProcedure;

                                cmdDrogueria.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                                cmdDrogueria.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;

                                cmdDrogueria.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        estaModificado = true;

                        var medicamentoExistente = medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                        if (medicamentoExistente != null)
                        {
                            medicamentos.Remove(medicamentoExistente);
                        }
                        medicamentos.Add(medicamento);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                connection.Close();
            }
            return estaModificado;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            var estaEliminado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;
                        command.CommandText = "SP_ELIMINARMEDICAMENTO";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                        command.ExecuteNonQuery();

                        transaction.Commit();
                        estaEliminado = true;
                        medicamentos.Remove(medicamento);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                connection.Close();
            }
            return estaEliminado;
        }
        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Connection = connection;
                        command.Connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var medicamento = new Medicamento();
                            medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                            medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"]);
                            medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"]);
                            medicamento.Stock = Convert.ToInt32(reader["STOCK"]);
                            medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"]);
                            var nombreMonodroga = reader["NOMBRE_MONODROGA"].ToString();

                            medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(m => m.Nombre == nombreMonodroga);

                            medicamentos.Add(medicamento);
                        }
                        reader.Close();

                        foreach (var medicamento in medicamentos)
                        {
                            using (var cmdDroguerias = new SqlCommand())
                            {
                                cmdDroguerias.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                                cmdDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                                cmdDroguerias.Connection = connection;
                                cmdDroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                                var readerDroguerias = cmdDroguerias.ExecuteReader();
                                while (readerDroguerias.Read())
                                {
                                    var cuit = Convert.ToInt64(readerDroguerias["CUIT"]);
                                    var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(d => d.Cuit == cuit);
                                    if (drogueria != null)
                                    {
                                        medicamento.Droguerias.Add(drogueria);
                                    }
                                }
                                readerDroguerias.Close();
                            }
                        }
                        command.Connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
            }
        }
    }

}

