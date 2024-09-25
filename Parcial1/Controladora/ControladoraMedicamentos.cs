using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    internal class ControladoraMedicamentos
    {
        private static readonly Lazy<ControladoraMedicamentos> instancia = new(() => new ControladoraMedicamentos());

        public static ControladoraMedicamentos Instancia => instancia.Value;

       
        public ReadOnlyCollection<Monodroga> ListarMonodrogas()
        {
            try
            {
                return RepositorioMonodrogas.Instancia.ListarMonodrogas();
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
                return RepositorioDroguerias.Instancia.ListarDroguerias();
            }
            catch
            {
                return new ReadOnlyCollection<Drogueria>(new List<Drogueria>());
            }

        }

        public ReadOnlyCollection<Medicamento> ListaDeMedicamentos()
        {
            try
            {
                return RepositorioMedicamentos.Instancia.ListarMedicamentos();
            }
            catch
            {
                return new ReadOnlyCollection<Medicamento>(new List<Medicamento>());
            }

        }

        public bool AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var busquedaMedicamento = RepositorioMedicamentos.Instancia.ListarMedicamentos().FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (busquedaMedicamento == null)
                {
                    RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    return true;
                }

                else return false;
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
                var busquedaMedicamento = RepositorioMedicamentos.Instancia.ListarMedicamentos().FirstOrDefault(medicamento => medicamento.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
               
                if (busquedaMedicamento != null)
                {
                    RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    return true;
                }

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
                var busquedaMedicamento = RepositorioMedicamentos.Instancia.ListarMedicamentos().FirstOrDefault(medicamento => medicamento.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (busquedaMedicamento != null)
                {
                    RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    return true;

                }

                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
