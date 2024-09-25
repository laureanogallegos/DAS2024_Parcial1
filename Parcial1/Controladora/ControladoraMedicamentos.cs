using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private ControladoraMedicamentos() { }
        private static ControladoraMedicamentos instancia;

        public static ControladoraMedicamentos Instancia
        {
            get
            {
                instancia ??= new ControladoraMedicamentos();
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            var listado = Modelo.RepositorioMedicamentos.Instancia.Medicamentos;
            return listado;
        }

        public string AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentos = Modelo.RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = medicamentos.FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado == null)
                {
                    var exito = Modelo.RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    if (exito)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se agregó correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido agregar";

                }
                else return $"El medicamento {medicamento.NombreComercial} ya existe.";
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }

        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentos = Modelo.RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = medicamentos.FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    var exito = Modelo.RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    if (exito)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se eliminó correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido eliminar";

                }
                else return $"El medicamento {medicamento.NombreComercial} no existe.";
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }

        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentos = Modelo.RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = medicamentos.FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    var exito = Modelo.RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    if (exito)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se modificó correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido modificar";

                }
                else return $"El medicamento {medicamento.NombreComercial} no existe.";
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }
    }
}