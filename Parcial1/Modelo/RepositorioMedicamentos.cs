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
                    command.Connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    /////////////////////////
                    command.Connection = connection;

                    var dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        var medicamento = new Medicamento
                        {

                            NombreComercial = dr["NOMBRE_COMERCIAL"].ToString(),
                            PrecioDeVenta = Convert.ToDecimal(dr["PPRECIO_VENTA"].ToString()),
                            StockActual = Convert.ToInt32(dr["STOCK"].ToString()),
                            StockMinimo = Convert.ToInt32(dr["STOCK_MINIMO"].ToString()),
                            TipoVenta = Convert.ToBoolean(dr["ES_VENTA_LIBRE"].ToString()),
                            Monodroga = RepositorioMonodrogas.Instancia.Listar().FirstOrDefault(mn => mn.Nombre == dr["NOMBRE_MONODROGA"].ToString()),
                        };

                        medicamentos.Add(medicamento);

                        command.Parameters.Clear();
                        command.CommandText = "sp_RECUPERARDROGUERIAS";
                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                        var drDroguerias = command.ExecuteReader();
                        while (drDroguerias.Read())
                        {
                                var drogueria = new Drogueria();
                                drogueria.Cuit = Convert.ToInt64(drDroguerias["CUIT"].ToString());
                                drogueria.RazonSocial = drDroguerias["RAZON_SOCIAL"].ToString();
                                drogueria.Direccion = drDroguerias["DIRECCION"].ToString();
                                drogueria.Email = drDroguerias["EMAIL"].ToString();
                                medicamento.AgregarDrogueria(drogueria);
                            
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
                    
                
        }


            
        public bool Agregar(Medicamento medicamento)
        {
            var estaInsertado = false;

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    var transaction = connection.BeginTransaction();

                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.Connection.Open();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_AGREGARMEDICAMENTO";
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@NOMBRE_MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.TipoVenta;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioDeVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    command.CommandText = "sp_AGREGARDROGUERIAMECIDAMENTO";
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);


                    foreach (var drogueria in medicamento.droguerias)
                    {
                        command.Parameters["@CUIT"].Value = drogueria.Cuit;
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    connection.Close();

                    medicamentos.Add(medicamento);
                    estaInsertado = true;
                }
                catch
                {
                    connection.Close();
                    estaInsertado = false;
                }
                
            
            return estaInsertado;
        }
        public bool Modificar(Medicamento medicamento)
        {
            var estaModificado = false;

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    var transaction = connection.BeginTransaction();

                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.Connection.Open();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@NOMBRE_MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.TipoVenta;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioDeVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.ExecuteNonQuery();
            
                    transaction.Commit();
                    connection.Close();
                    medicamentos.Remove(medicamento);
                    medicamentos.Add(medicamento);
                    estaModificado = true;
                }
                catch
                {
                    connection.Close();
                    estaModificado = false;
                }


            return estaModificado;
        }
        public bool Eliminar(Medicamento medicamento)
        {
            var estaEliminado = false;

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    var transaction = connection.BeginTransaction();

                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.Connection.Open();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ELIMINARMEDICAMENTO";
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                   
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();
                   
                    estaEliminado = true;
                }
                catch
                {
                    connection.Close();
                    estaEliminado = false;
                }


            return estaEliminado;
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

        public ReadOnlyCollection<Medicamento> Listar()
        {
            return medicamentos.AsReadOnly();
        }
    }
}

