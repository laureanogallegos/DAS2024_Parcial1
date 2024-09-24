using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Repositorio
{
    public class RepositorioMedicamento
    {
        private static readonly Lazy<RepositorioMedicamento> instancia = new Lazy<RepositorioMedicamento>(() => new RepositorioMedicamento());
        public static RepositorioMedicamento Instancia => instancia.Value;

        private readonly List<Medicamento> medicamentos;
        
        private readonly SqlConnection connection;

        private RepositorioMedicamento()
        {
            medicamentos = [];
            var connectionString = ConnectionString.GetConnectionString();
            connection = new SqlConnection(connectionString);
            Recuperar();
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
                using var command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                var rd = command.ExecuteReader();
                while (rd.Read())
                {
                    Medicamento medicamento = new Medicamento()
                    {
                        NombreComercial = rd["NombreComercial"].ToString(),
                        VentaLibre = bool.Parse(rd["VentaLibre"].ToString()),
                        PrecioVenta = decimal.Parse(rd["PrecioVenta"].ToString()),
                        StockActual = int.Parse(rd["StockActual"].ToString()),
                        StockMinimo = int.Parse(rd["StockMinimo"].ToString()),
                       
                    };
                    medicamentos.Add(medicamento);
                    //command.Parameters.Clear();
                    using var commandProve = new SqlCommand();
                    commandProve.Connection = connection;
                    commandProve.CommandType = System.Data.CommandType.StoredProcedure;
                    commandProve.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTO";
                    commandProve.Parameters.Add("@NombreComercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    var drDroguerias = commandProve.ExecuteReader();
                    while (drDroguerias.Read())
                    {

                        Drogueria drogueria = new Drogueria
                        {
                            
                            Cuit = int.Parse(drDroguerias["Cuit"].ToString()),
                            RazonSocial = drDroguerias["NombreProveedor"].ToString(),
                            Direccion = drDroguerias["Direccion"].ToString(),
                            Email = drDroguerias["Email"].ToString()
                        };
                        medicamento.AgregarDrogueria(drogueria);
                    };

                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                connection.Close();
            }
        }

        public bool Agregar(Medicamento medicamento)
        {
            bool insertado = false;
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                command.Transaction = transaction;
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARMEDICAMENTO";

                command.Parameters.Add("@NombreComercial", System.Data.SqlDbType.NVarChar, 15).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ventaLibre", System.Data.SqlDbType.NVarChar, 150).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PrecioVenta", System.Data.SqlDbType.Decimal, 18).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@StockActual", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                command.Parameters.Add("@StockMinimo", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
              

                command.ExecuteNonQuery();

                using var commandProv = new SqlCommand();
                commandProv.Transaction = transaction;
                commandProv.Connection = connection;
                commandProv.CommandType = System.Data.CommandType.StoredProcedure;
                commandProv.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                commandProv.Parameters.Add("@CodigoProducto", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                commandProv.Parameters.Add("@CuitDrogueria", System.Data.SqlDbType.NVarChar, 50);
                foreach (Drogueria drog in medicamento.ListarDroguerias())
                {
                    commandProv.Parameters["@CuitDrogueria"].Value = drog.Cuit;
                    commandProv.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();
                medicamentos.Add(medicamento);
                insertado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                connection.Close();
                insertado = false;
            }
            return insertado;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {

                using var command = new SqlCommand();
                command.Transaction = transaction;
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.Parameters.Add("@NombreComercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();
                medicamentos.Remove(medicamento);
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                connection.Close();
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool Modificar(Medicamento medicamento, Medicamento medicamentoNuevo)
        {
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var cmd = new SqlCommand();
                cmd.Transaction = transaction;
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_MODIFICARMEDICAMENTO";
                cmd.Parameters.Add("@NombreComercial", System.Data.SqlDbType.NVarChar, 15).Value = medicamento.NombreComercial;
                cmd.Parameters.Add("@ventaLibre", System.Data.SqlDbType.NVarChar, 150).Value = medicamento.VentaLibre;
                cmd.Parameters.Add("@PrecioVenta", System.Data.SqlDbType.Decimal, 18).Value = medicamento.PrecioVenta;
                cmd.Parameters.Add("@StockActual", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                cmd.Parameters.Add("@StockMinimo", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                ActualizarListaModificada(medicamento, medicamentoNuevo);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                connection.Close();
                return false;
            }
        }

        private void ActualizarListaModificada(Medicamento medicamentoViejo, Medicamento nuevoMedicamento)
        {
            var medicamentoFiltrado = medicamentos.FirstOrDefault(med => med.NombreComercial == medicamentoViejo.NombreComercial);
            if (medicamentoFiltrado != null)
            {
                medicamentoFiltrado.NombreComercial = nuevoMedicamento.NombreComercial;
                medicamentoFiltrado.VentaLibre = nuevoMedicamento.VentaLibre;
                medicamentoFiltrado.PrecioVenta = nuevoMedicamento.PrecioVenta;
                medicamentoFiltrado.StockActual = nuevoMedicamento.StockActual;
                medicamentoFiltrado.StockMinimo = nuevoMedicamento.StockMinimo;
            }
        }
    }
}

 
