using Microsoft.Extensions.Configuration;
using System;
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
        public static RepositorioMedicamentos Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new RepositorioMedicamentos();
                }
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> Medicamentos()
        {
            return medicamentos.AsReadOnly();
        }

        public bool Agregar(Medicamento medicamento) 
        {
            if (AgregarMedicamento(medicamento))
            {
                medicamentos.Add(medicamento);
                return true;
            }
            else { return false; }

        }
        public bool Eliminar(Medicamento medicamento)
        {
            if (EliminarMedicamento(medicamento))
            {
                medicamentos.Remove(medicamento);
                return true;
            }
            else { return false; }

        }
        public bool Modificar(Medicamento medicamento)
        {
            if (ModificarMedicamento(medicamento))
            {
                return true;
            }
            return false;
        }
        public bool AgregarMedicamento(Medicamento medicamento)
        {
            var estaInsertado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))


                try
                {
                    using var command = new SqlCommand();
                    command.Connection = connection;
                    connection.Open();
                    var transaction = connection.BeginTransaction();
                    command.Transaction = transaction;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_AGREGARMEDICAMENTO";

                    ;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    using var cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                    foreach (var drogueria in medicamento.Droguerias)
                    {


                        cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    connection.Close();
                    estaInsertado = true;
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    connection.Close();
                }
            return estaInsertado;
        }
        public bool ModificarMedicamento(Medicamento medicamento)
        {
            var estaInsertado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
                    command.Connection = connection;
                    command.Connection.Open();
                    var transaction = connection.BeginTransaction();
                    command.Transaction = transaction;
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    using var cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    cmd.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                    foreach (var drogueria in medicamento.Droguerias)
                    {
                        cmd.Parameters["@CUIT"].Value = drogueria.Cuit;
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    connection.Close();

                    estaInsertado = true;
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    connection.Close();
                }
            return estaInsertado;
        }

        public bool EliminarMedicamento(Medicamento medicamento)
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
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            try
                {

                    using var cmd = new SqlCommand();
                    cmd.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    cmd.Connection = connection;
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"]);
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"]);
                        medicamento.StockActual = Convert.ToInt32(reader["STOCK"]);
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"]);
                        var cod = reader["NOMBRE_MONODROGA"].ToString();
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(c => c.Nombre == cod);

                        using var cmr = new SqlCommand();
                        cmr.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        cmr.CommandType = System.Data.CommandType.StoredProcedure;
                        cmr.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        cmr.Connection = connection;
                        var readerMedicamentos = cmr.ExecuteReader();
                        while (readerMedicamentos.Read())
                        {
                        var code = Convert.ToInt64(readerMedicamentos["CUIT"].ToString());
                            var drogueria2 = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == code);
                            medicamento.AgregarDrogueria(drogueria2);
                        }
                        medicamentos.Add(medicamento);
                    }
                    cmd.Connection.Close();
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
    }
}
