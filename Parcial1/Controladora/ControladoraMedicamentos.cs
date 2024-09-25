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

        private ControladoraMedicamentos() { }

        public static ControladoraMedicamentos Instance => instancia.Value;

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return RepositorioMedicamentos.Instancia.Medicamentos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public ReadOnlyCollection<Monodroga> RecuperarMondrogas()
        {
            try
            {
                return RepositorioMonodrogas.Instancia.Monodrogas;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public ReadOnlyCollection<Drogueria> RecuperarDroguerias()
        {
            try
            {
                return RepositorioDroguerias.Instancia.ListaDroguerias;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public bool AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var existeMedicamento = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(a => a.NombreComercial == medicamento.NombreComercial);
                if (existeMedicamento == null)
                {
                    RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var existeMedicamento = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(a => a.NombreComercial == medicamento.NombreComercial);
                if (existeMedicamento == null)
                {
                    RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                var existeMedicamento = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(a => a.NombreComercial == medicamento.NombreComercial);
                if (existeMedicamento == null)
                {
                    RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
