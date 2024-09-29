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
        private static readonly Lazy<ControladoraMedicamentos> instancia = new(() => new ControladoraMedicamentos());
        public static ControladoraMedicamentos Instancia = instancia.Value;
        public List<Drogueria> droguerias = new List<Drogueria>();

        public void ActualizarListaAModificar(Medicamento medicamento)
        {
            var medicamentoEncontrado = RecuperarMedicamentos().FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
            foreach (Drogueria droga in medicamentoEncontrado.ListarDrogueria())
            {
                droguerias.Add(droga);
            }
        }
        public void LimpiarDroguerias()
        {
            droguerias.Clear();
        }

        public ReadOnlyCollection<Drogueria> RecuperarDroguerias()
        {
            return RepositorioDroguerias.Instancia.Droguerias;
        }
        public ReadOnlyCollection<Monodroga> RecuperarMonodrogras()
        {
            return RepositorioMonodrogas.Instancia.Monodrogas;
        }
        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return RepositorioMedicamentos.Instancia.Listar();
        }
        public bool Agregar(Medicamento medicamento)
        {
            if (RecuperarMedicamentos().FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial) == null)
            {
                foreach (var drogueria in droguerias)
                {
                    medicamento.AgregarDrogueria(drogueria);
                }
                RepositorioMedicamentos.Instancia.Agregar(medicamento);
                droguerias.Clear();
                return true;
            }
            return false;
        }
        public bool Modificar(Medicamento medicamentoViejo, Medicamento medicamentoNuevo)
        {
            var medicamentoEncontrado = RecuperarMedicamentos().FirstOrDefault(x => x.NombreComercial == medicamentoViejo.NombreComercial);
            if (medicamentoEncontrado != null)
            {
                foreach (var drogueria in droguerias)
                {
                    medicamentoNuevo.AgregarDrogueria(drogueria);
                }
                RepositorioMedicamentos.Instancia.Modificar(medicamentoViejo, medicamentoNuevo);
                return true;
            }
            return false;
        }
        public bool Eliminar(Medicamento medicamento)
        {
            if (RecuperarMedicamentos().FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial) != null)
            {
                RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                return true;
            }
            return false;
        }
        public bool AgregarDrogueria(Drogueria drogueria)
        {
            if (droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit) == null)
            {
                droguerias.Add(drogueria);
                return true;
            }
            return false;
        }
        public bool EliminarDrogueria(Drogueria drogueria)
        {
            if (droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit) != null)
            {
                droguerias.Remove(drogueria);
                return true;
            }
            return false;
        }

        public ReadOnlyCollection<Drogueria> ListarDrogueriasMedicamento()
        {
            return droguerias.AsReadOnly();
        }
    }
}
