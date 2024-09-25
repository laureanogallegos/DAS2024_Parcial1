using Modelo;

namespace Controladora
{
    public class EliminarMedicamentoController
    {
        private static readonly Lazy<EliminarMedicamentoController> instancia = new(() => new EliminarMedicamentoController());

        private EliminarMedicamentoController()
        {

        }

        public static EliminarMedicamentoController Instancia => instancia.Value;

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
