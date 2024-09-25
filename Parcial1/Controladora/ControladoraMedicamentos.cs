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
        public static ControladoraMedicamentos Instancia => instancia.Value;

        private ControladoraMedicamentos() { }

        public bool AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var existeMedicamento = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                if (existeMedicamento == null)
                {
                    return RepositorioMedicamentos.Instancia.Agregar(medicamento);
                }
                else
                {
                    return false;
                }
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
                var existeMedicamento = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                if (existeMedicamento != null)
                {
                    return RepositorioMedicamentos.Instancia.Modificar(medicamento);
                }
                else
                {
                    return false;
                }
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
                var existeMedicamento = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                if (existeMedicamento != null)
                {
                    return RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return RepositorioMedicamentos.Instancia.Medicamentos;
            }
            catch
            {
                return new ReadOnlyCollection<Medicamento>(new List<Medicamento>());
            }
        }

        public ReadOnlyCollection<Drogueria> RecuperarDroguerias()
        {
            try
            {
                return RepositorioDroguerias.Instancia.Droguerias;
            }
            catch
            {
                return new ReadOnlyCollection<Drogueria>(new List<Drogueria>());
            }
        }

        public ReadOnlyCollection<Monodroga> RecuperarMonodrogas()
        {
            try
            {
                return RepositorioMonodrogas.Instancia.Monodrogas;
            }
            catch
            {
                return new ReadOnlyCollection<Monodroga>(new List<Monodroga>());
            }
        }
    }
}
