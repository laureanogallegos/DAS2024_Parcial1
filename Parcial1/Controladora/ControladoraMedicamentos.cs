using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private static readonly Lazy<ControladoraMedicamentos> instancia = new(() => new ControladoraMedicamentos());
        public static readonly ControladoraMedicamentos Instancia = instancia.Value;
        private List<Drogueria> droguerias;

        public ControladoraMedicamentos()
        {
            droguerias = new List<Drogueria>();
        }

        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            return RepositorioDroguerias.Instancia.Droguerias;
        }

        public ReadOnlyCollection<Monodroga> ListarMonodrogas()
        {
            return RepositorioMonodrogas.Instancia.Monodrogas;
        }

        public ReadOnlyCollection<Medicamento> ListarMedicamentos()
        {
            return RepositorioMedicamentos.Instancia.Medicamentos;
        }

        public bool AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = ListarMedicamentos().FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente == null)
                {
                    foreach (var drogueria in droguerias)
                    {
                        medicamento.AgregarDrogueria(drogueria);
                    }
                    droguerias.Clear();
                    return RepositorioMedicamentos.Instancia.Agregar(medicamento);
                }
                return false;
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
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente != null)
                {
                    return RepositorioMedicamentos.Instancia.Modificar(medicamento);
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
                
                var medicamentoSeleccionado = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (medicamentoSeleccionado != null)
                {
                    RepositorioMedicamentos.Instancia.Eliminar(medicamentoSeleccionado);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ReadOnlyCollection<Drogueria> ListarDrogueriasDelMedicamento()
        {
            return droguerias.AsReadOnly();
        }

        public bool AgregarDrogueriaAlMedicamento(long cuitDrog)
        {
            var drogueriaExistente = ListarDroguerias().FirstOrDefault(x => x.Cuit == cuitDrog);
            var drogueriaFiltrada = ListarDrogueriasDelMedicamento().FirstOrDefault(x => x.Cuit == drogueriaExistente.Cuit);

            if (drogueriaFiltrada == null)
            {
                droguerias.Add(drogueriaExistente);
                return true;
            }
            return false;
        }

        public void EliminarDrogueriaDelMedicamento(Drogueria drogSeleccionada)
        {
            droguerias.Remove(drogSeleccionada);
        }
    }
}
