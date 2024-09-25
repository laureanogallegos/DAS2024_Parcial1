using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public  class ControladoraMedicamentos
    {
        private static readonly Lazy<ControladoraMedicamentos> instancia = new Lazy<ControladoraMedicamentos>(() => new ControladoraMedicamentos());
        public static ControladoraMedicamentos Instancia => instancia.Value;

        private List<Drogueria> droguerias;

        private ControladoraMedicamentos()
        {
            droguerias = new List<Drogueria>();
        }

        public bool Agregar(Medicamento medicamento)
        {
            var filtrarMedicamentos = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(med => med.Nombre == medicamento.Nombre);
            if (filtrarMedicamentos == null)
            {
                foreach (Drogueria drog in droguerias)
                {
                    medicamento.AgregarDrogueria(drog);
                }
                RepositorioMedicamentos.Instancia.Agregar(medicamento);
                droguerias.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        public ReadOnlyCollection<Medicamento> ListarMedicamentos()
        {
            return RepositorioMedicamentos.Instancia.Medicamentos;
        }

        public bool EliminarMedicamento(Medicamento medicamento)
        {
            var filtrarMedicamentos = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(med => med.Nombre == medicamento.Nombre);
            if (filtrarMedicamentos != null)
            {
                return RepositorioMedicamentos.Instancia.Eliminar(medicamento);
            }
            else
            {
                return false;
            }
        }

        public bool ModificarMedicamento(Medicamento medicamentoViejo, Medicamento medicamentoNuevo)
        {
            var filtrarMedicamentos = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(med => med.Nombre == medicamentoViejo.Nombre);
            if (filtrarMedicamentos != null)
            {
                return RepositorioMedicamentos.Instancia.Modificar(medicamentoViejo, medicamentoNuevo);
            }
            else
            {
                return false;
            }
        }
    }
}
