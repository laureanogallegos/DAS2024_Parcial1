using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RepositorioMedicamento
    {
        private static List<Medicamento> medicamentos;
        private static SqlConnection connection;

        public RepositorioMedicamento()
        {
            medicamentos = new List<Medicamento>();
            var connectionString = ConnectionString.GetConnectonString;
            connection = new SqlConnection(connectionString);
           // RecuperarMedicamento();
        }
        private static readonly Lazy<RepositorioMedicamento> instancia = new (() => new RepositorioMedicamento());

        public static RepositorioMedicamento Instancia = instancia.Value;

        public ReadOnlyCollection<Medicamento> Listar()
        {
            return medicamentos.AsReadOnly();
        }


        public bool AgregarMedicamento (Medicamento medicamento)
        {
            var seAgrego = false;
            using var cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.Transaction = cmd.Connection.BeginTransaction();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarMedicamento";
                cmd.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@Es_Venta_Libre", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                cmd.Parameters.Add("@Precio_Venta", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                cmd.Parameters.Add("@Stock", System.Data.SqlDbType.Int).Value = medicamento.StockAcual;
                cmd.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                cmd.Parameters.Add("@Monodroga", System.Data.SqlDbType.NVarChar, 50);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AgregarsMedicamentoMonodroga";
                cmd.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 20).Value = medicamento.Monodroga.Nombre;
                foreach(var drogueria in medicamento.droguerias)
                {
                    cmd.Parameters["NombreComercial"].Value = medicamento.NombreComercial;
                    cmd.Parameters["Cuit"].Value = drogueria.Cuit;
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
                medicamentos.Add(medicamento);
                seAgrego = true;
            }
            catch(Exception ex) 
            {
                cmd.Transaction.Rollback();
                connection.Close();
            }
            return seAgrego;
        }

        public bool ModificarMedicamento(Medicamento medicamento)
        {
            var seModifico = false;
            using var cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.Transaction = cmd.Connection.BeginTransaction();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_ModificarMedicamento";
                cmd.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@Es_Venta_Libre", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                cmd.Parameters.Add("@Precio_Venta", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                cmd.Parameters.Add("@Stock", System.Data.SqlDbType.Int).Value = medicamento.StockAcual;
                cmd.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                cmd.Parameters.Add("@Monodroga", System.Data.SqlDbType.NVarChar, 50);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_ModificarMedicamentoMonodroga";
                cmd.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 20).Value = medicamento.Monodroga.Nombre;
                cmd.Transaction.Commit();
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                medicamentos.Remove(medicamento);
                medicamentos.Add(medicamento);
                return seModifico = true;
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                connection.Close();
            }
            return seModifico;
        }

        public bool EliminarMedicamento(Medicamento medicamento)
        {
            var seElimino = false;
            using var cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.Transaction = cmd.Connection.BeginTransaction();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_EliminarMedicamento";
                cmd.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;             
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_EliminarMedicamentoMonodroga";
                cmd.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 20).Value = medicamento.Monodroga.Nombre;
                cmd.Transaction.Commit();
                cmd.ExecuteNonQuery();
                medicamentos.Remove(medicamento);
                return seElimino = true;
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                connection.Close();
            }
            return seElimino;
        }

        public void RecuperarMedicamento()
        {
            using var cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_RecuperarMedicamentos";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var medicamento = new Medicamento
                    {
                        NombreComercial = (dr["NombreComercial"]).ToString(),
                        VentaLibre = Convert.ToBoolean(dr["VentaLibre"]),
                        PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                        StockAcual = Convert.ToInt32(dr["StockAcual"]),
                        StockMinimo = Convert.ToInt32(dr["StockMinimo"]),
                    };

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_RecuperarDrogueriaMedicamentos";
                    cmd.Parameters.Add("@NombreComercial", System.Data.SqlDbType.NVarChar, 50);
                    var drDrogueria = cmd.ExecuteReader();
                    while(drDrogueria.Read())
                    {                      
                        var drogueria = new Drogueria
                        {                          
                            Cuit = Convert.ToInt64(drDrogueria["Cuit"]),
                        };
                    }
                }
            }
            catch 
            {
               connection.Close();
            }

        }
    }
}
