using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public ReadOnlyCollection<Modelo.Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return Modelo.RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarMedicamento(Medicamento medicamentos)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.nombreComercial.ToLower() == medicamento.nombreComercial.ToLower());
                if (medicamentoEncontrado == null)
                {
                    var ok = RepositorioMedicamentos.Instancia.AgregarMedicamento(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.nombreComercial} se agregó correctamente";
                    }
                    else return $"El medicamento {medicamento.nombreComercial} no se ha podido agregar";
                }
                else
                {
                    return $"El medicamento {medicamento.nombreComercial} ya existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.nombreComercial.ToLower() == medicamento.nombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.EliminarMedicamento(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se agregó correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido agregar";
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.nombreComercial.ToLower() == medicamento.nombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.ModificarMedicamento(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se agregó correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido agregar";
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }

        }
    }
}
