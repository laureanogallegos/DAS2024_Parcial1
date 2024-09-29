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
        private static readonly Lazy<ControladoraMedicamentos> instancia = new(()=> new ControladoraMedicamentos());
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
            return RepositorioMedicamentos.Instancia.Medicamentos();
        }
        public bool AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExiste = ListarMedicamentos().FirstOrDefault(X => X.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExiste == null)
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
                var medExistente = RepositorioMedicamentos.Instancia.Medicamentos().FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if(medExistente != null)
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
                var medicamentoSelec = RepositorioMedicamentos.Instancia.Medicamentos().FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (medicamentoSelec != null)
                {
                    RepositorioMedicamentos.Instancia.Eliminar(medicamentoSelec);
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

        public bool AgregarDrogueriasAlMedicamento(long cuitDrogueria)
        {
            var drogueriaExiste = ListarDroguerias().FirstOrDefault(x => x.Cuit == cuitDrogueria);
            var drogueriaFaltante = ListarDrogueriasDelMedicamento().FirstOrDefault(x => x.Cuit == drogueriaExiste.Cuit);

            if (drogueriaFaltante == null)
            {
                droguerias.Add(drogueriaExiste);
                return true;
            }
            return false;
        }

        public void EliminarDrogueriaDelMedicamento(Drogueria drogueriaSelec)
        {
            droguerias.Remove(drogueriaSelec);
        }
    }
}