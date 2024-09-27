using Modelo;

namespace Controladora
{
    public class MedicamentoController
    {
        private static readonly Lazy<MedicamentoController> instancia = new(() => new MedicamentoController());

        private MedicamentoController()
        {

        }

        public static MedicamentoController Instancia => instancia.Value;

        public bool AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente == null)
                    return RepositorioMedicamentos.Instancia.Agregar(medicamento);
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ModificarMedicamento(Medicamento medicamento, Medicamento medicamentoSeleccionado)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente == null)
                    return RepositorioMedicamentos.Instancia.Modificar(medicamento, medicamentoSeleccionado);
                else return false;
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
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente != null)
                    return RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
