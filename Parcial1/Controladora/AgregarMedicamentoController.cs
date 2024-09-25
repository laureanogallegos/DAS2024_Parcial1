using Modelo;

namespace Controladora
{
    public class AgregarMedicamentoController
    {
        private static readonly Lazy<AgregarMedicamentoController> instancia = new(() => new AgregarMedicamentoController());

        private AgregarMedicamentoController()
        {

        }

        public static AgregarMedicamentoController Instancia => instancia.Value;

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
    }
}
