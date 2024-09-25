using Modelo;
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
            private ControladoraMedicamentos() { }

            private static ControladoraMedicamentos instancia;
            public static ControladoraMedicamentos Instancia
            {
                get
                {
                    if (instancia == null)
                        instancia = new ControladoraMedicamentos();
                    return instancia;
                }
            }

            public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
            {
                try
                {
                    return RepositorioMedicamentos.Instance.Listar();
                }
                catch (Exception)
                {
                    throw; // Re-lanzar la excepción para manejarla en otro lugar si es necesario
                }
            }

            public string AgregarMedicamento(Medicamento medicamento)
            {
                try
                {
                    var listaMedicamentos = RepositorioMedicamentos.Instance.Listar();
                    var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());

                    if (medicamentoEncontrado == null)
                    {
                        var ok = RepositorioMedicamentos.Instance.Agregar(medicamento);
                        return ok ? $"El medicamento {medicamento.NombreComercial} se agregó correctamente" : $"El medicamento {medicamento.NombreComercial} no se ha podido agregar";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} ya existe.";
                    }
                }
                catch (Exception)
                {
                    return "Error desconocido al agregar el medicamento.";
                }
            }

            public string EliminarMedicamento(Medicamento medicamento)
            {
                try
                {
                    var listaMedicamentos = RepositorioMedicamentos.Instance.Listar();
                    var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());

                    if (medicamentoEncontrado != null)
                    {
                        var ok = RepositorioMedicamentos.Instance.Eliminar(medicamento);
                        return ok ? $"El medicamento {medicamento.NombreComercial} se eliminó correctamente" : $"El medicamento {medicamento.NombreComercial} no se ha podido eliminar";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} no existe.";
                    }
                }
                catch (Exception)
                {
                    return "Error desconocido al eliminar el medicamento.";
                }
            }

            public string ModificarMedicamento(Medicamento medicamento)
            {
                try
                {
                    var listaMedicamentos = RepositorioMedicamentos.Instance.Listar();
                    var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());

                    if (medicamentoEncontrado != null)
                    {
                        var ok = RepositorioMedicamentos.Instance.Modificar(medicamento);
                        return ok ? $"El medicamento {medicamento.NombreComercial} se modificó correctamente" : $"El medicamento {medicamento.NombreComercial} no se ha podido modificar";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} no existe.";
                    }
                }
                catch (Exception)
                {
                    return "Error desconocido al modificar el medicamento.";
                }
            }
        }
    }
