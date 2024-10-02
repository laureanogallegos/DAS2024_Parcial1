using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Modelo
{
    internal class RepositorioMedicamentos
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


        private readonly SqlConnection connection;
        public bool Agregar(Medicamento medicamento)
        {
            var insertado = false;
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var sqlCommand = new SqlCommand();
                sqlCommand.Transaction = transaction;
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "SP_AGREGARMEDICAMENTO";
                sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_comercial;
                sqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.Es_venta_libre;
                sqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_venta;
                sqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                sqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.Stock_minimo;
                sqlCommand.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";

                sqlCommand.Parameters.Clear();

                sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_comercial;
                sqlCommand.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                foreach (var drogueria in medicamento.Droguerias)
                {
                    sqlCommand.Parameters["@CUIT"].Value = drogueria;
                    sqlCommand.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();

                medicamentos.Add(medicamento);
                insertado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return insertado;
        }

        public bool Mdificar(Medicamento medicamento)
        {
            var insertado = false;
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var sqlCommand = new SqlCommand();
                sqlCommand.Transaction = transaction;
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "SP_MOFICARMEDICAMENTO";
                sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_comercial;
                sqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.Es_venta_libre;
                sqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_venta;
                sqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                sqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.Stock_minimo;
                sqlCommand.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";

                sqlCommand.Parameters.Clear();

                sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_comercial;
                sqlCommand.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                foreach (var drogueria in medicamento.Droguerias)
                {
                    sqlCommand.Parameters["@CUIT"].Value = drogueria;
                    sqlCommand.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();

                medicamentos.Add(medicamento);
                medicamentos.Remove(medicamento);
                insertado = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
            }
            return insertado;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            var insertado = false;
            connection.Open();
            try
            {
                using var sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "SP_ELIMINARMEDICAMENTO";
                sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_comercial;

                sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();

                connection.Close();

                medicamentos.Remove(medicamento);
                insertado = true;
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return insertado;
        }



        private void Recuperar()
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
                        medicamento.Nombre_comercial = reader["NOMBRE_COMERCIAL"].ToString();  
                        medicamento.Es_venta_libre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"]);
                        medicamento.Precio_venta = Convert.ToInt32(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.Stock_minimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(a => a.Nombre == medicamento.Monodroga.Nombre);
                        medicamentos.Add(medicamento);

                        var cmd = new SqlCommand();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = connection;
                        command.Parameters.Clear();
                        command.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_comercial;
                        var dr = command.ExecuteReader();
                       
                            while (dr.Read())
                            {
                            var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(a => a.Cuit == Convert.ToInt64(reader["CUIT"].ToString()));
                            medicamento.AgregarDrogueria(drogueria);
                            };
                       

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
