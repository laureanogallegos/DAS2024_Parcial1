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
            private readonly List<Medicamento> medicamentos;
            private readonly SqlConnection connection;
            private IConfigurationRoot configuration;
            
            private RepositorioMedicamentos()

            {
                medicamentos = new List<Medicamento>();
                configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                connection = new SqlConnection(connectionString);
                Recuperar();
            }

            private static readonly Lazy<RepositorioMedicamentos> instancia = new(() => new RepositorioMedicamentos());

           
            public static RepositorioMedicamentos Instancia => instancia.Value;
            public ReadOnlyCollection<Medicamento> ListarMedicamentos()
            {
                return medicamentos.AsReadOnly();
            }
            
            
            private void Recuperar()
            {
                connection.Open();
                try
                {
                    using var sqlcommand = new SqlCommand();
                    sqlcommand.Connection = connection;
                    sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcommand.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    var dr = sqlcommand.ExecuteReader();
                   
                    while (dr.Read())
                    {
                        var medicamento = new Medicamento
                        {
                            NombreComercial = dr["NOMBRE_COMERCIAL"].ToString(),
                            EsVentaLibre = Convert.ToBoolean(dr["ES_VENTA_LIBRE"]),
                            PrecioVenta = Convert.ToDecimal(dr["PRECIO_VENTA"]),
                            Stock = Convert.ToInt32(dr["STOCK"]),
                            StockMinimo = Convert.ToInt32(dr["STOCK_MINIMO"]),
                            monodroga = RepositorioMonodrogas.Instancia.ListarMonodrogas().FirstOrDefault(x => x.Nombre == dr["NOMBRE_MONODROGA"].ToString())
                        };

                        using var commandMedDroguerias = new SqlCommand();

                        commandMedDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                        commandMedDroguerias.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        commandMedDroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        commandMedDroguerias.Connection = connection;

                        var readerDrogueriasXMedicamento = commandMedDroguerias.ExecuteReader();
                       
                        while (readerDrogueriasXMedicamento.Read())
                        {
                            var cuitDrogueria = Convert.ToInt64(readerDrogueriasXMedicamento["CUIT"].ToString());
                            var drogueria = RepositorioDroguerias.Instancia.ListarDroguerias().FirstOrDefault(d => d.Cuit == cuitDrogueria);
                            medicamento.AgregarDrogueria(drogueria);
                        }
                        medicamentos.Add(medicamento);

                    }
                    sqlcommand.Connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
            }
            public void Agregar(Medicamento medicamento)
            {
                
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    using var SqlCommand = new SqlCommand();
                    SqlCommand.Transaction = transaction;
                    SqlCommand.Connection = connection;
                    SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlCommand.CommandText = "SP_AGREGARMEDICAMENTO";

                    SqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    SqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                    SqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    SqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    SqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    SqlCommand.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.monodroga.Nombre;
                    SqlCommand.ExecuteNonQuery();


                    using var SqlCommandMedXDrog = new SqlCommand();

                    SqlCommandMedXDrog.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlCommandMedXDrog.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    SqlCommandMedXDrog.Transaction = transaction;
                    SqlCommandMedXDrog.Connection = connection;

                    SqlCommandMedXDrog.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    SqlCommandMedXDrog.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                    
                    foreach (var drogueria in medicamento.ListaDeDroguerias)
                    {
    
                        SqlCommandMedXDrog.Parameters["@CUIT"].Value = drogueria.Cuit;
                        SqlCommandMedXDrog.ExecuteNonQuery();

                    }

                    SqlCommandMedXDrog.Parameters.Clear();
                    transaction.Commit();
                    connection.Close();

                    medicamentos.Add(medicamento);
                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    connection.Close();
                }
            }
            public void Modificar(Medicamento medicamento)
            {
                
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    using var SqlCommand = new SqlCommand();
                    SqlCommand.Transaction = transaction;
                    SqlCommand.Connection = connection;
                    SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlCommand.CommandText = "SP_MODIFICARMEDICAMENTO";

                    SqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    SqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                    SqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    SqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    SqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    SqlCommand.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.monodroga.Nombre;
                    SqlCommand.ExecuteNonQuery();


                    using var SqlCommandMD = new SqlCommand();
                    SqlCommandMD.Transaction = transaction;
                    SqlCommandMD.Connection = connection;
                    SqlCommandMD.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlCommandMD.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    SqlCommandMD.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 15);
                    SqlCommandMD.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                    
                    foreach (var drogueria in medicamento.ListaDeDroguerias)

                    {
                        SqlCommandMD.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;
                        SqlCommandMD.ExecuteNonQuery();
                        SqlCommandMD.Parameters.Clear();
                    }

                    transaction.Commit();
                    connection.Close();

                    medicamentos.Add(medicamento);
                    
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    connection.Close();
                }
            }


            public void Eliminar(Medicamento medicamento)
            {
               
                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {
                    using var SqlCommand = new SqlCommand();
                    SqlCommand.Transaction = transaction;
                    SqlCommand.Connection = connection;
                    SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlCommand.CommandText = "SP_ELIMINARMEDICAMENTO";

                    SqlCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    SqlCommand.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();

                    medicamentos.Remove(medicamento);
                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    connection.Close();
                }

            }


        }
}
