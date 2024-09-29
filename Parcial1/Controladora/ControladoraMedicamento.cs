using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraMedicamento
    {
        private static readonly Lazy<ControladoraMedicamento> instancia = new(() => new ControladoraMedicamento());
        private ControladoraMedicamento() { }

        public static ControladoraMedicamento Instancia => instancia.Value;

        public ReadOnlyCollection<Medicamento> RecuperarMedicamento()
        {
            try
            {
                return RepositorioMedicamento.Instancia.Listar();
            }
            catch
            {
                return new ReadOnlyCollection<Medicamento>(new List<Medicamento>());
            }
        }

        public string AgregarMedicamento (Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamento.Instancia.Listar().FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial /*&& m.VentaLibre == medicamento.VentaLibre && m.PrecioVenta == medicamento.PrecioVenta && m.StockAcual == medicamento.StockAcual && m.StockMinimo == medicamento.StockMinimo && m.Monodroga == medicamento.Monodroga*/);
                if (medicamentoExistente == null)
                {
                    var ok = RepositorioMedicamento.Instancia.AgregarMedicamento(medicamento);
                    if (ok)
                    {
                        return "El medicamento se agrego correctamente";
                    }
                    else
                    {
                        return "El medicamento no se pudo agregar";
                    }
                }
                else
                {
                    return "El medicamento ya existe";
                }
            }
            catch 
            {
                return "Error";
            }
        }

        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamento.Instancia.Listar().FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial /*&& m.VentaLibre == medicamento.VentaLibre && m.PrecioVenta == medicamento.PrecioVenta && m.StockAcual == medicamento.StockAcual && m.StockMinimo == medicamento.StockMinimo && m.Monodroga == medicamento.Monodroga*/);
                if (medicamentoExistente != null)
                {
                    var ok = RepositorioMedicamento.Instancia.AgregarMedicamento(medicamento);
                    if (ok)
                    {
                        return "El medicamento se elimino correctamente";
                    }
                    else
                    {
                        return "El medicamento no se pudo eliminar";
                    }
                }
                else
                {
                    return "El medicamento no existe";
                }
            }
            catch
            {
                return "Error";
            }
        }

        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamento.Instancia.Listar().FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial /*&& m.VentaLibre == medicamento.VentaLibre && m.PrecioVenta == medicamento.PrecioVenta && m.StockAcual == medicamento.StockAcual && m.StockMinimo == medicamento.StockMinimo && m.Monodroga == medicamento.Monodroga*/);
                if (medicamentoExistente != null)
                {
                    var ok = RepositorioMedicamento.Instancia.AgregarMedicamento(medicamento);
                    if (ok)
                    {
                        return "El medicamento se modifico correctamente";
                    }
                    else
                    {
                        return "El medicamento no se pudo modificar";
                    }
                }
                else
                {
                    return "El medicamento no existe";
                }
            }
            catch
            {
                return "Error";
            }
        }
    }
}