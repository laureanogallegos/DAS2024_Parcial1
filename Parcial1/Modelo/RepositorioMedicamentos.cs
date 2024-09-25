using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private static RepositorioMedicamentos instancia;
        private List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;

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

        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            RecuperarMedicamentos();
        }

        private void RecuperarMedicamentos()
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
                        medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.Precio = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt16(reader["STOCK"].ToString());
                        medicamento.StockMin = Convert.ToInt16(reader["STOCK_MINIMO"].ToString());

                        var nombreMonodroga = reader["NOMBRE_MONODROGA"].ToString();
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(monodroga => monodroga.Nombre.Equals(nombreMonodroga));

                        using var commandDroguerias = new SqlCommand();
                        commandDroguerias.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        commandDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                        commandDroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        commandDroguerias.Connection = connection;
                        var readerDrogueriasMedicamento = commandDroguerias.ExecuteReader();
                        while (readerDrogueriasMedicamento.Read())
                        {
                            var cuit = Convert.ToInt64(reader["CUIT"].ToString());
                            var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(drogueria => drogueria.Cuit.Equals(cuit));
                            if (drogueria != null)
                            {
                                medicamento.AgregarDrogueria(drogueria);
                            }
                        }
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

        public bool Agregar(Medicamento medicamento)
        {
            if (AgregarMedicamento(medicamento))
            {
                medicamentos.Add(medicamento);
                return true;
            }

            return false;
        }

        private bool AgregarMedicamento(Medicamento medicamento)
        {
            var exito = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
                try
                {
                    using var command = new SqlCommand();
                    command.CommandText = "SP_AGREGARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = Convert.ToByte(medicamento.EsVentaLibre);
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMin;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;

                    foreach (var drogueria in medicamento.Droguerias)
                    {
                        using var commandDrogueria = new SqlCommand();
                        commandDrogueria.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                        commandDrogueria.CommandType = System.Data.CommandType.StoredProcedure;
                        commandDrogueria.Connection = connection;
                    commandDrogueria.Transaction = sqlTransaction;
                        commandDrogueria.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        commandDrogueria.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;
                    }

                sqlTransaction.Commit();
                    exito = true;

                }
                catch (SqlException ex)
                {
                sqlTransaction.Rollback();
                    connection.Close();
                    connection.Dispose();

                }
                catch (Exception ex)
                {
                sqlTransaction.Rollback();
                connection.Close();
                    connection.Dispose();
                }

            return exito;
        }

        public bool Modificar(Medicamento medicamento)
        {
            return ModificarMedicamento(medicamento);
        }

        private bool ModificarMedicamento(Medicamento medicamento)
        {
            var exito = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                command.CommandText = "SP_MODIFICARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = Convert.ToByte(medicamento.EsVentaLibre);
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMin;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;

                foreach (var drogueria in medicamento.Droguerias)
                {
                    using var commandDrogueria = new SqlCommand();
                    commandDrogueria.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    commandDrogueria.CommandType = System.Data.CommandType.StoredProcedure;
                    commandDrogueria.Connection = connection;
                    commandDrogueria.Transaction = sqlTransaction;
                    commandDrogueria.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    commandDrogueria.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;
                }

                sqlTransaction.Commit();
                exito = true;
                connection.Close();
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }

            return exito;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            if (EliminarMedicamento(medicamento))
            {
                medicamentos.Remove(medicamento);
                return true;
            }

            return false;
        }

        private bool EliminarMedicamento(Medicamento medicamento)
        {
            {
                var exito = false;
                var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
                connection.Open();
                var sqlTransaction = connection.BeginTransaction();
                try
                {
                    using var command = new SqlCommand();
                    command.CommandText = "SP_ELIMINARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    exito = true;
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    sqlTransaction.Rollback();
                    connection.Close();
                    connection.Dispose();

                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    connection.Close();
                    connection.Dispose();
                }

                return exito;
            }
        }
    }
}
