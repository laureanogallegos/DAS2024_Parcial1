using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraMedicamento
    {
        private static readonly Lazy<ControladoraMedicamento> instancia = new(() => new ControladoraMedicamento());
        public ControladoraMedicamento() { }

        public static ControladoraMedicamento Instancia = new ControladoraMedicamento();

        public ReadOnlyCollection<Medicamento> RecuperarMedicamento()
        {
            try
            {
                return RepositorioMedicamento.Instacia.Listar().AsReadOnly();
            }
            catch
            {
                return ReadOnlyCollection<Medicamento>(new List<Medicamento>());
            }

        }

        public string RegistarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = new RepositorioMedicamento.Instancia.Listar().FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);             
                if (medicamento == null)
                {
                    var ok = new RepositorioMedicamento.Instancia.AgregarMedicamento(medicamento);
                    return "El medicamento se ha registrado correctamente";
                    if (ok)
                    {
                        return "El medicamento no se ha podido registar correctamente";
                    }
                    else
                    {
                        return "El medicamento ya existe";
                    }
                }                
            }
            catch
            {
                return "Error";
            }
        }

        public string



           

    }
}