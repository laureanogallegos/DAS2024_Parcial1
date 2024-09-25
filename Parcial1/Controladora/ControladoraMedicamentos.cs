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

        public ReadOnlyCollection<Drogueria> ListarDroguerias()
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

        public ReadOnlyCollection<Monodroga> ListarMonodroga()
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

        public bool AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoEncontrada = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoEncontrada == null)
                    return RepositorioMedicamentos.Instancia.Agregar(medicamento);
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
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente != null)
                    return RepositorioMedicamentos.Instancia.Modificar(medicamento);
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarMedicamento(string nombreComercial)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == nombreComercial);
                if (medicamentoExistente != null)
                    return RepositorioMedicamentos.Instancia.Eliminar(medicamentoExistente);
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
