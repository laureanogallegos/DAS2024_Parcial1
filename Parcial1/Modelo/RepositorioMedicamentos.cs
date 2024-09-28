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
        public List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;

        public RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            RecuperarMedicamentos();
        }
        public bool AgregarMedicamento(Medicamento medicamento)
        {
            var medicamentoAgregado = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_AGREGARMEDICAMENTO";
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                cmd.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                cmd.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                cmd.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                cmd.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                cmd.ExecuteNonQuery();

                using var commandDroguerias = new SqlCommand();
                commandDroguerias.Connection = connection;
                commandDroguerias.Transaction = transaction;
                commandDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                commandDroguerias.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                commandDroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                commandDroguerias.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                foreach (var drogueria in medicamento.Droguerias)
                {
                    commandDroguerias.Parameters["@CUIT"].Value = drogueria.Cuit;
                    commandDroguerias.ExecuteNonQuery();
                }
                transaction.Commit();
                connection.Close();
                medicamentos.Add(medicamento);
                medicamentoAgregado = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return medicamentoAgregado;
        }

        public bool ModificarMedicamento(Medicamento medicamento)
        {
            var medicamentoModificado = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_MODIFICARMEDICAMENTO";
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                cmd.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                cmd.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                cmd.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                cmd.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                cmd.ExecuteNonQuery();

                using var commandDroguerias = new SqlCommand();
                commandDroguerias.Connection = connection;
                commandDroguerias.Transaction = transaction;
                commandDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                commandDroguerias.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                commandDroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                commandDroguerias.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                foreach (var drogueria in medicamento.Droguerias)
                {
                    commandDroguerias.Parameters["@CUIT"].Value = drogueria.Cuit;
                    commandDroguerias.ExecuteNonQuery();

                }
                transaction.Commit();
                connection.Close();
                medicamentos.Remove(medicamento);
                medicamentos.Add(medicamento);
                medicamentoModificado = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return medicamentoModificado;
        }
        public bool EliminarMedicamento(Medicamento medicamento)
        {
            var medicamentoEliminado = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_ELIMINARMEDICAMENTO";
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                medicamentos.Remove(medicamento);
                medicamentoEliminado = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return medicamentoEliminado;
        }

        public void RecuperarMedicamentos()
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            try
            {
                using var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_RECUPERARMEDICAMENTOS";
                var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    var medicamento = new Medicamento()
                    {
                        NombreComercial = rd["NOMBRE_COMERCIAL"].ToString(),
                        VentaLibre = Convert.ToBoolean(rd["ES_VENTA_LIBRE"]),
                        PrecioVenta = Convert.ToDecimal(rd["PRECIO_VENTA"]),
                        Stock = Convert.ToInt32(rd["STOCK"]),
                        StockMinimo = Convert.ToInt32(rd["STOCK_MINIMO"]),
                        Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(m => m.Nombre == rd["NOMBRE_MONODROGA"].ToString()),
                    };
                    using var cmdDrogueria = new SqlCommand();
                    cmdDrogueria.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdDrogueria.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                    cmdDrogueria.Parameters.Add("@NOMBRE_COMERCIAL ", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    cmdDrogueria.Connection = connection;

                    var readerDrogueria = cmdDrogueria.ExecuteReader();
                    while (readerDrogueria.Read())
                    {
                        var cuitDrogueria = Convert.ToInt64(readerDrogueria["CUIT"]);
                        var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == cuitDrogueria);
                        medicamento.AgregarDrogueria(drogueria);
                    }
                    medicamentos.Add(medicamento);
                }
                connection.Close();
            }
            catch(Exception ex)
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

