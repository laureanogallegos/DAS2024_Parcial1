using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

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
                    medicamento.NombreComercial= reader["NOMBRE_COMERCIAL"].ToString();
                    medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"]);
                    medicamento.PrecioVenta= Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                    medicamento.Stock = Convert.ToInt32( reader["STOCK"].ToString());
                    medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                    var monodroga = reader["NOMBRE_MONODROGA"].ToString();
                    medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(m => m.Nombre == monodroga);
                    medicamentos.Add(medicamento);
                    var cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTO";
                    cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar,50).Value = medicamento.NombreComercial;
                    var reader2 = cmd.ExecuteReader();
                    { 
                        while (reader2.Read())
                        {
                            var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(d => d.Cuit == Convert.ToInt64(reader2["CUIT"].ToString()));
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
            var isOk = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_AGREGARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    command.Transaction = connection.BeginTransaction();
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                    command.ExecuteNonQuery();
                    command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    command.Parameters.Clear();
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                    foreach (var drogueria in medicamento.Droguerias)
                    {
                        command.Parameters["@CUIT"].Value = drogueria.Cuit;
                        command.ExecuteNonQuery();
                    }
                    command.Transaction.Commit();
                    command.Connection.Close();
                    isOk = true;
                    medicamentos.Add(medicamento);
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
            return isOk;
        }

        public bool Modificar(Medicamento medicamento)
        {
            var isOk = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            using (var command = new SqlCommand())
                try
                {

                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    command.Transaction = connection.BeginTransaction();
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                    command.ExecuteNonQuery();
                    command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    command.Parameters.Clear();
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                    foreach (var drogueria in medicamento.Droguerias)
                    {
                        command.Parameters["@CUIT"].Value = drogueria.Cuit;
                        command.ExecuteNonQuery();
                    }
                    command.Transaction.Commit();
                    command.Connection.Close();
                    isOk = true;
                    medicamentos.Add(medicamento);
                    medicamentos.Remove(medicamento);
                }
                catch (SqlException ex)
                {
                    command.Transaction?.Rollback();
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    command.Transaction?.Rollback();
                    connection.Close();
                    connection.Dispose();
                }
            return isOk;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            var isOk = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            using (var command = new SqlCommand())
                try
                {

                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_ELIMINARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    command.Transaction = connection.BeginTransaction();
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.ExecuteNonQuery();
                    command.Transaction.Commit();
                    command.Connection.Close();
                    isOk = true;
                    medicamentos.Remove(medicamento);
                }
                catch (SqlException ex)
                {command.Transaction.Rollback();
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {command.Transaction.Rollback();
                    connection.Close();
                    connection.Dispose();
                }
            return isOk;
        }
    }
}
