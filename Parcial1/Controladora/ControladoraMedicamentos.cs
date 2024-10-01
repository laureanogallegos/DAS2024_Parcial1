using Modelo;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private ControladoraMedicamentos() { }
        private static ControladoraMedicamentos instancia;
        public static ControladoraMedicamentos Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraMedicamentos();
                return instancia;
            }
        }
        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return
                   RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string AgregarMedicamentos(Medicamento medicamento)
        {
            try
            {
                var listarMedicamento = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listarMedicamento.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado == null)
                {
                    var ok = RepositorioMedicamentos.Instancia.AgregarMedicamento(medicamento);
                    if (ok)
                    {
                        return $"el medicamento {medicamento.NombreComercial} se agrego";
                    }
                    else
                    {
                        return $"el medicamento {medicamento.NombreComercial} no se ha podido agregar";
                    }
                }
                else
                {
                    return $"el medicamento {medicamento.NombreComercial} ya existe";
                }
            }
            catch (Exception)
            {
                return "error desconocido";
            }
        }
        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                //recupero la lista 
                var listarMedicamento = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                // busco en la lista si esta el medicamento q deseo eliminar
                var medicamentoEncontrado = listarMedicamento.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                // si esta en la lista me va a devolver un valor distinto de null
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.EliminarMedicamento(medicamentoEncontrado);
                    if (ok)
                    {
                        return $"el medicamento {medicamento.NombreComercial} se elimino";
                    }
                    else
                    {
                        return $"el medicamento {medicamento.NombreComercial} no se ha podido eliminar";
                    }
                }
                else
                {
                    return $"el medicamento {medicamento.NombreComercial} no existe";
                }
            }
            catch (Exception)
            {
                return "error desconocido";
            }
        }
        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listarMedicamento = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listarMedicamento.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.ModificarMedicamento(medicamento);
                    if (ok)
                    {
                        return $"el medicamento {medicamento.NombreComercial} fue modificado";
                    }
                    else
                    {
                        return $"el medicamento {medicamento.NombreComercial} no se ha podido modifica";
                    }
                }
                else
                {
                    return $"el medicamento {medicamento.NombreComercial} no existe";
                }
            }
            catch (Exception)
            {

                return "error desconocido";
            }
        }
    }
}

        