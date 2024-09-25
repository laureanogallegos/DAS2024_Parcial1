
using Microsoft.Extensions.Configuration;
using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;

    namespace Modelo
    {
        public class RepositorioMedicamentos
        {
            private readonly List<Medicamento> medicamentos;
            private readonly SqlConnection connection;
        private IConfigurationRoot configuration;
        private RepositorioMedicamentos()
            {
                medicamentos = new List<Medicamento>();
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");

                Recuperar();
            }

            // Singleton
            private static readonly Lazy<RepositorioMedicamentos> instance = new(() => new RepositorioMedicamentos());

            public static RepositorioMedicamentos Instance => instance.Value;

        public static object Instancia { get; set; }

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
                    sqlCommand.CommandText = "SP_AGREGARMEDICAMENTO"; // Cambia el nombre según tu SP

                    sqlCommand.Parameters.Add("@NombreComercial", System.Data.SqlDbType.NVarChar).Value = medicamento.NombreComercial;
                    sqlCommand.Parameters.Add("@Es_Venta_Libre", System.Data.SqlDbType.Bit).Value = medicamento.Es_Venta_Libre;
                    sqlCommand.Parameters.Add("@Precio_Venta", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_Venta;
                    sqlCommand.Parameters.Add("@Stock", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    sqlCommand.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Int).Value = medicamento.Stock_Minimo;
                    sqlCommand.Parameters.Add("@Monodroga", System.Data.SqlDbType.Int).Value = medicamento.Monodroga; 

                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();
                    medicamentos.Add(medicamento);
                    estaInsertado = true;
                }
                catch (Exception)
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
                    sqlCommand.CommandText = "SP_ELIMINARMEDICAMENTO"; // Cambia el nombre según tu SP

                    sqlCommand.Parameters.Add("@NombreComercial", System.Data.SqlDbType.NVarChar).Value = medicamento.NombreComercial;
                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();

                    medicamentos.Remove(medicamento);
                    estaEliminado = true;
                }
                catch (Exception)
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
                    sqlCommand.CommandText = "SP_MODIFICARMEDICAMENTO"; // Cambia el nombre según tu SP

                    sqlCommand.Parameters.Add("@NombreComercial", System.Data.SqlDbType.NVarChar).Value = medicamento.NombreComercial;
                    sqlCommand.Parameters.Add("@Es_Venta_Libre", System.Data.SqlDbType.Bit).Value = medicamento.Es_Venta_Libre;
                    sqlCommand.Parameters.Add("@Precio_Venta", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_Venta;
                    sqlCommand.Parameters.Add("@Stock", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    sqlCommand.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Int).Value = medicamento.Stock_Minimo;
                    sqlCommand.Parameters.Add("@Monodroga", System.Data.SqlDbType.Int).Value = medicamento.Monodroga;

                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();

                    medicamentos.Remove(medicamento);
                    medicamentos.Add(medicamento);
                    estaModificado = true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    connection.Close();
                }
                return estaModificado;
            }

            public ReadOnlyCollection<Medicamento> Listar()
            {
                return medicamentos.AsReadOnly();
            }

        private void Recuperar()
        {
            connection.Open();
            try
            {
                using var sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "SP_RECUPERARMEDICAMENTOS";
                using var dr = sqlCommand.ExecuteReader();

                while (dr.Read())
                {
                    var medicamento = new Medicamento
                    {
                        NombreComercial = dr["NombreComercial"].ToString(),
                        Es_Venta_Libre = Convert.ToBoolean(dr["Es_Venta_Libre"]),
                        Precio_Venta = Convert.ToDecimal(dr["Precio_Venta"]),
                        Stock = Convert.ToInt32(dr["Stock"]),
                        Stock_Minimo = Convert.ToInt32(dr["Stock_Minimo"]),
                        Monodroga = new Monodroga // Crear una nueva instancia de Monodroga
                        {
                            Nombre = dr["NOMBRE_MONODROGA"].ToString() // Asignar el nombre de la monodroga
                        }
                    };

                    // Recuperar las droguerías relacionadas
                    RecuperarDrogueriasMedicamentos(medicamento);

                    medicamentos.Add(medicamento);
                }
            }
            catch (Exception ex)
            {
                // Puedes agregar un manejo de errores más específico aquí, si lo deseas
                Console.WriteLine("Error al recuperar medicamentos: " + ex.Message);
            }
            finally
            {
                connection.Close(); // Asegúrate de cerrar la conexión en el bloque finally
            }
        }

        private void RecuperarDrogueriasMedicamentos(Medicamento medicamento)
        {
            using var sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
            sqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar).Value = medicamento.NombreComercial;

            var drDroguerias = sqlCommand.ExecuteReader();
            while (drDroguerias.Read())
            {
                var drogueriaMedicamento = new DrogueriasMedicamentos
                {
                    NombreComercial = medicamento.NombreComercial,
                    Cuit = Convert.ToInt64(drDroguerias["Cuit"])
                };

                // Aquí podrías guardar en una lista o manejar la relación como desees
            }
        }
    }
}