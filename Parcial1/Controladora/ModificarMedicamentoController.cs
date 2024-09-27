using Modelo;

namespace Controladora
{
    public class ModificarMedicamentoController
    {
        private static readonly Lazy<ModificarMedicamentoController> instancia = new(() => new ModificarMedicamentoController());

        private ModificarMedicamentoController()
        {

        }

        public static ModificarMedicamentoController Instancia => instancia.Value;

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
    }
}
