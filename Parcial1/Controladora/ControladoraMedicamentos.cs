using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private static ControladoraMedicamentos instancia;

        private ControladoraMedicamentos()
        {
        }

        public static ControladoraMedicamentos Instancia
        {
            get
            {
                instancia ??= new ControladoraMedicamentos();
                return instancia;
            }
        }

        public ReadOnlyCollection<Monodroga> ListarMonodrogas()
        {
            try
            {
                return RepositorioMonodrogas.Instancia.Monodrogas;
            }
            catch
            {
                return new ReadOnlyCollection<Monodroga>(new List<Monodroga>());
            }
        }

        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            try
            {
                return RepositorioDroguerias.Instancia.Droguerias;
            }
            catch
            {
                return new ReadOnlyCollection<Drogueria>(new List<Drogueria>());
            }
        }

        public ReadOnlyCollection<Medicamento> ListarMedicamentos()
        {
            try
            {
                return RepositorioMedicamentos.Instancia.Medicamentos;
            }
            catch
            {
                return new ReadOnlyCollection<Medicamento>(new List<Medicamento>());
            }
        }

        public bool RegistrarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoEncontrado = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoEncontrado == null)
                {
                    return RepositorioMedicamentos.Instancia.Agregar(medicamento);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                return RepositorioMedicamentos.Instancia.Modificar(medicamento);
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                return RepositorioMedicamentos.Instancia.Eliminar(medicamento);
            }
            catch
            {
                return false;
            }
        }
    }

}