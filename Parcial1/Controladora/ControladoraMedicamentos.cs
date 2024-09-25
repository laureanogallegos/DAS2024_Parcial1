using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    class ControladoraMedicamentos
    {
        private static readonly Lazy<ControladoraMedicamentos> instance = new(() => new ControladoraMedicamentos());
        public ControladoraMedicamentos Instance = new ControladoraMedicamentos();
        public List<Drogueria> droguerias = new List<Drogueria>();

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
                RepositorioMedicamentos.Instancia.Agregar(medicamento);
                foreach (var drogueria in droguerias) 
                {
                    medicamento.AgregarDrogueria(drogueria);
                }
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
        public bool Modificar(Medicamento medicamentoViejo, Medicamento medicamentoNuevo)
        {
            if (RecuperarMedicamentos().FirstOrDefault(x => x.NombreComercial == medicamentoViejo.NombreComercial) == null)
            {
                RepositorioMedicamentos.Instancia.Modificar(medicamentoViejo,medicamentoNuevo);
                return true;
            }
            return false;
        }
        public void AgregarDrogueria(Drogueria drogueria)
        {
            if (droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit) != null)
            {
                droguerias.Add(drogueria);
            }
        }
        public void EliminarDrogueria(Drogueria drogueria)
        {
            if (droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit) == null)
            {
                droguerias.Remove(drogueria);
            }
        }
    }
}
