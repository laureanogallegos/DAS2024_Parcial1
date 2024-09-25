using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
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
            try
            {
                using var command = new SqlCommand();
                command.Connection = connection;
                command.Connection.Open();
                //otra forma de hacerlo es usando Store Procedures
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                /////////////////////////connection.Open();
                var transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;

                command.ExecuteNonQuery();

                command.Parameters.Clear();

                //ahora vamos a insertar las droguerias
                foreach (var drogueria in medicamento.Droguerias)
                {
                    command.Parameters.Clear();
                    command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;

                    command.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();

                medicamentos.Add(medicamento);
                estaInsertado = true;
            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                connection.Close();
            }
            return estaInsertado;
        }

        public bool Modificar(Medicamento medicamento)
        {
            var estaInsertado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
                    command.Connection = connection;
                    command.Connection.Open();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////connection.Open();
                    var transaction = connection.BeginTransaction();
                    command.Transaction = transaction;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    //ahora vamos a insertar las droguerias
                    foreach (var drogueria in medicamento.Droguerias)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        command.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    connection.Close();
                    medicamentos.Remove(medicamento);
                    medicamentos.Add(medicamento);
                    estaInsertado = true;
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    connection.Close();
                }
            return estaInsertado;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            var estaEliminado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            try
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                using var sqlCommand = new SqlCommand();
                sqlCommand.Transaction = transaction;
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "SP_ELIMINARMEDICAMENTO";
                sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                sqlCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                medicamentos.Remove(medicamento);
                estaEliminado = true;
            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                connection.Close();
            }
            return estaEliminado;
        }

        public void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())//lee a traves de todas las filas que existen en la tabla
                    {
                        //por cada fila que creo tengo que asignar manualmente cada columna con cada propiedad
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"]);
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"]);
                        medicamento.StockActual = Convert.ToInt32(reader["STOCK"]);
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"]);
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(mono => mono.Nombre == reader["MONODROGA"].ToString());

                        command.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NChar, 50).Value = medicamento.NombreComercial;

                        var drL = command.ExecuteReader();
                        while (drL.Read())
                        {
                            var drogueria = new Drogueria
                            {
                                Cuit = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(d => d.Cuit == drL["CUIT"].ToString())
                                
                            };
                            medicamento.AgregarDrogueria(drogueria);
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
