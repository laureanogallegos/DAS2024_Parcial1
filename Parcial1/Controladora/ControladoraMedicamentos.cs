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
        private static readonly Lazy<ControladoraMedicamentos> instancia = new(() => new ControladoraMedicamentos());


        private ControladoraMedicamentos()
        {
            // Private constructor prevents direct instantiation
        }

        public static ControladoraMedicamentos Instancia => instancia.Value;

        public ReadOnlyCollection<Monodroga> ListarMonodrogas()
        {
            try
            {
                return RepositorioMonodrogas.Instance.Listar();
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
                return RepositorioDroguerias.Instance.Listar();
            }
            catch
            {
                return new ReadOnlyCollection<Drogueria>(new List<Drogueria>());
            }

        }

        public ReadOnlyCollection<Medicamento> ListarMedicamentos()
        {
            try
            {
                return RepositorioMedicamentos.Instance.Listar();
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
                var medicamentoencontrado = RepositorioMedicamentos.Instance.Listar().FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoencontrado == null)
                {
                    RepositorioMedicamentos.Instance.Agregar(medicamento);
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
                var medicamentoencontrado = RepositorioMedicamentos.Instance.Listar().FirstOrDefault(medicamento => medicamento.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoencontrado != null)
                {
                    RepositorioMedicamentos.Instance.Modificar(medicamento);
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
                var medicamentoencontrado = RepositorioMedicamentos.Instance.Listar().FirstOrDefault(medicamento => medicamento.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoencontrado != null)
                {
                    RepositorioMedicamentos.Instance.Eliminar(medicamento);
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
