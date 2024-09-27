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
        private ControladoraMedicamentos()
        {
            // Private constructor prevents direct instantiation
        }
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




        public ReadOnlyCollection<Modelo.Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return Modelo.RepositorioMedicamentos.Instancia.Medicamentos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReadOnlyCollection<Monodroga> RecuperarMonodroga()
        {
            try
            {
                return RepositorioMonodrogas.Instancia.Monodrogas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReadOnlyCollection<Drogueria> RecuperarDrogueria()
        {
            try
            {
                return RepositorioDroguerias.Instancia.Droguerias;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Monodroga? BuscarMonodrogaPorNombre(string nombre)
        {
            try
            {
                var monodrogaExistente = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(m => m.Nombre == nombre);
                if (monodrogaExistente != null)
                    return monodrogaExistente;
                else return null;
            }
            catch
            {
                return null;
            }
        }

        public Drogueria? BuscarDrogueriaPorRazonSocial(string razonSocial)
        {
            try
            {
                var razonSocialExistente = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(d => d.RazonSocial == razonSocial);
                if (razonSocialExistente != null)
                    return razonSocialExistente;
                else return null;
            }
            catch
            {
                return null;
            }
        }
        public string AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
  
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos().FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial );

                if (medicamentoExistente != null)
                {

                    return $"El medicamento {medicamento.NombreComercial} ya existe.";
                }
                else
                {
                    var ok = RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se agregó correctamente.";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} no se ha podido agregar.";
                    }
                }
            }
            catch (Exception)
            {
                return "Error desconocido al agregar el medicamento.";
            }
        }

        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos().FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente!= null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se modificó correctamente.";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido modificar.";
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos().FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se modificó correctamente.";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido modificar.";
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
    }

}
