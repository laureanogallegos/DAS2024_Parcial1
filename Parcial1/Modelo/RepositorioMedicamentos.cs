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

        private RepositorioMedicamentos()
        {
            medicamentos = new List<Medicamento>();
            var connectionString = ConnectionString.GetConnectionString();
            connection = new SqlConnection(connectionString);
            Recuperar();



        }

        private static readonly Lazy<RepositorioMedicamentos> instance = new(() => new RepositorioMedicamentos());

        // Step 3: Provide a public static method to get the instance of the class
        public static RepositorioMedicamentos Instance => instance.Value;
        public ReadOnlyCollection<Medicamento> Listar()
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
                        VentaLibre = Convert.ToBoolean(dr["ES_VENTA_LIBRE"]),
                        PrecioVenta = Convert.ToDecimal(dr["PRECIO_VENTA"]),
                        StockActual = Convert.ToInt32(dr["STOCK"]),
                        StockMinimo = Convert.ToInt32(dr["STOCK_MINIMO"]),
                        monodroga = RepositorioMonodrogas.Instance.Listar().FirstOrDefault(m => m.Nombre == dr["NOMBRE_MONODROGA"].ToString())
                    };

                    using var commandDroguerias = new SqlCommand();

                    commandDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                    commandDroguerias.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                    commandDroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    commandDroguerias.Connection = connection;

                    var readerDrogueriasMedicamento = commandDroguerias.ExecuteReader();
                    while (readerDrogueriasMedicamento.Read())
                    {
                        var cuitDrogueria = Convert.ToInt64(readerDrogueriasMedicamento["CUIT"].ToString());
                        var drogueria = RepositorioDroguerias.Instance.Listar().FirstOrDefault(d => d.Cuit == cuitDrogueria);
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
            var estaInsertado = false;
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
                SqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                SqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                SqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                SqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                SqlCommand.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.monodroga.Nombre;
                SqlCommand.ExecuteNonQuery();


                using var SqlCommandMD = new SqlCommand();
                SqlCommandMD.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommandMD.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                SqlCommandMD.Transaction = transaction;
                SqlCommandMD.Connection = connection;

                SqlCommandMD.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;//NOMBRE DEL MEDICAMENTO QUE MANDO AL SP AGREGAR MEDICAMENTODROGUERIA
                SqlCommandMD.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                //ahora vamos a insertar las lineas de factura
                foreach (var drogueria in medicamento.ListaDroguerias)
                {

                    SqlCommandMD.Parameters["@CUIT"].Value = drogueria.Cuit;

                    SqlCommandMD.ExecuteNonQuery();

                }
                SqlCommandMD.Parameters.Clear();
                transaction.Commit();
                connection.Close();

                medicamentos.Add(medicamento);
                estaInsertado = true;
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }
        public void Modificar(Medicamento medicamento)
        {
            var estaInsertado = false;
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
                SqlCommand.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                SqlCommand.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                SqlCommand.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                SqlCommand.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                SqlCommand.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.monodroga.Nombre;
                SqlCommand.ExecuteNonQuery();


                using var SqlCommandMD = new SqlCommand();
                SqlCommandMD.Transaction = transaction;
                SqlCommandMD.Connection = connection;
                SqlCommandMD.CommandType = System.Data.CommandType.StoredProcedure;
                SqlCommandMD.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                SqlCommandMD.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 15);//NOMBRE DEL MEDICAMENTO QUE MANDO AL SP AGREGAR MEDICAMENTODROGUERIA
                SqlCommandMD.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                //ahora vamos a insertar las lineas de factura
                foreach (var drogueria in medicamento.ListaDroguerias)
                {

                    SqlCommandMD.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;



                    SqlCommandMD.ExecuteNonQuery();
                    SqlCommandMD.Parameters.Clear();
                }

                transaction.Commit();
                connection.Close();

                medicamentos.Add(medicamento);
                estaInsertado = true;
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }
        public void Eliminar(Medicamento medicamento)
        {
            var estaInsertado = false;
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
                estaInsertado = true;
            }
            catch (Exception ex)
            {
                connection.Close();
            }

        }
    }
}
