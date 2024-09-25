using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private static readonly Lazy<ControladoraMedicamentos> instancia = new(() => new ControladoraMedicamentos());


        private ControladoraMedicamentos()
        {
           
        }

        public static ControladoraMedicamentos Instancia => instancia.Value;

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return RepositorioMedicamentos.Instance.Listar().AsReadOnly();
            }
            catch
            {
                return new ReadOnlyCollection<Medicamento>(new List<Medicamento>());
            }

        }

        public ReadOnlyCollection<Monodroga> RecuperarMonodroga()
        {
            try
            {
                return RepositorioMonodrogas.Instance.Listar().AsReadOnly();
            }
            catch
            {
                return new ReadOnlyCollection<Monodroga>(new List<Monodroga>());
            }

        }

        public bool AgregarProducto(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instance.Listar().FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente == null)
                    return RepositorioMedicamentos.Instance.Agregar(medicamento);
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ModificarProducto(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instance.Listar().FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente != null)
                    return RepositorioMedicamentos.Instance.Modificar(medicamento);
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarProducto(Medicamento medicamento)
        { 
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instance.Listar().FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente != null)
                    return RepositorioMedicamentos.Instance.Eliminar(medicamento);
                else return false;
            }
            catch
            {
                return false;
            }
        }

    }

}
}