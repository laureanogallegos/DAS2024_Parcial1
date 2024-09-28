using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private static RepositorioMedicamentos instancia;
        private List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;
        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appSettings.json");
            medicamentos = new List<Medicamento>();
            Recuperar();
        }

        public bool Agregar(Medicamento medicamento)
        {
            var estaInsertado = false;

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction; 
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.CommandText = "SP_AGREGARMEDICAMENTO";
                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                        command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                        command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                        command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                        command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;

                        command.ExecuteNonQuery();
                        command.Parameters.Clear(); 

                        // Insertar las droguerías asociadas al medicamento
                        foreach (var drogueria in medicamento.Droguerias)
                        {
                            command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                            command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                            command.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;

                            command.ExecuteNonQuery();
                            command.Parameters.Clear(); 
                        }
                    }
                    transaction.Commit();
                    medicamentos.Add(medicamento);
                    estaInsertado = true;
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return estaInsertado;
        }

        public bool Modificar(Medicamento medicamento)
        {
            var estaModificado = false;

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.CommandText = "SP_MODIFICARMEDICAMENTO";
                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                        command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                        command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                        command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                        command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;

                        command.ExecuteNonQuery();
                        command.Parameters.Clear();

                        // Insertar las droguerías asociadas al medicamento
                        foreach (var drogueria in medicamento.Droguerias)
                        {
                            command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                            command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                            command.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;

                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                    }
                    transaction.Commit(); 
                    var medicamentoExistente = medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                    if (medicamentoExistente != null)
                    {
                        medicamentos.Remove(medicamentoExistente);
                    }
                    medicamentos.Add(medicamento);
                    estaModificado = true;
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return estaModificado;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            var estaEliminado = false;

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    using (var sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = connection;
                        sqlCommand.Transaction = transaction; 
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.CommandText = "SP_ELIMINARMEDICAMENTO";

                        sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                        sqlCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    medicamentos.Remove(medicamento);
                    estaEliminado = true;
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return estaEliminado;
        }

        public void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
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
                        medicamento.StockActual = Convert.ToInt32(reader["STOCK"]);
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"]);
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(mono => mono.Nombre == reader["NOMBRE_MONODROGA"].ToString());

                        using var commandDroguerias = new SqlCommand();
                        commandDroguerias.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        commandDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                        commandDroguerias.Connection = connection;

                        commandDroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NChar, 50).Value = medicamento.NombreComercial;

                        using var drL = commandDroguerias.ExecuteReader();
                        while (drL.Read())
                        {
                            if (drL["CUIT"] != DBNull.Value && long.TryParse(drL["CUIT"].ToString(), out long cuit))
                            {
                                var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(d => Convert.ToInt64(d.Cuit) == cuit);
                                if (drogueria != null)
                                {
                                    medicamento.AgregarDrogueria(drogueria);
                                }
                            }
                        }
                        medicamentos.Add(medicamento);
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
    }
}
