using Modelo.Objetos;
using Modelo.Repositorios;
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
        private static readonly Lazy<ControladoraMedicamentos> instancia = new Lazy<ControladoraMedicamentos>(()=> new ControladoraMedicamentos());
        public static ControladoraMedicamentos Instancia=> instancia.Value;
        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            return RepositorioDroguerias.Instancia.ListarDroguerias();
        }
        public ReadOnlyCollection<Monodroga> LsitarMonodrogas()
        {
            return RepositorioMonodrogas.Instancia.Monodrogas;
        }
        public ReadOnlyCollection<Medicamento> LsitarMedicamentos()
        {
            return RepositorioMedicamentos.Instancia.Medicamentos;
        }
        public bool AgregarMedicamento(Medicamento medicamento, List<Drogueria> droguerias, string monodroga)
        {
            var buscarMonodroga = LsitarMonodrogas().FirstOrDefault(mn=>mn.Nombre == monodroga);
            if (buscarMonodroga!=null)
            {
                medicamento.MonodrogaMedicamento = buscarMonodroga;
                foreach (Drogueria drog in droguerias)
                {
                    medicamento.AgregarDrogueria(drog);
                }
                return RepositorioMedicamentos.Instancia.Agregar(medicamento);
            }
            else
            {
                return false;
            }
            
        }
        public bool ModificarMedicamento(Medicamento medicamento, Medicamento medicamentoActualizado)
        {
            return RepositorioMedicamentos.Instancia.Modificar(medicamento,medicamentoActualizado);
        }
        public bool EliminarMedicamento(Medicamento medicamento)
        {
            return RepositorioMedicamentos.Instancia.Eliminar(medicamento);
        }
        public Drogueria BuscarDrogueria(string cuit)
        {
            return ListarDroguerias().FirstOrDefault(drog=>drog.Cuit==long.Parse(cuit));
        }
    }
}
