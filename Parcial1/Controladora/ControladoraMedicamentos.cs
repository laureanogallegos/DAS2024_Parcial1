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
        private RepositorioMedicamentos repositorioMedicamentos;

        private static readonly Lazy<ControladoraMedicamentos> instance = new(() => new ControladoraMedicamentos());

        public static ControladoraMedicamentos Instance = instance.Value;

        public ControladoraMedicamentos()
        {
            repositorioMedicamentos = new RepositorioMedicamentos();
        }

        public ReadOnlyCollection<Medicamento> ListarMedicamento()
        {
            return RepositorioMedicamentos.Instancia.ListarMedicamento();
        }

        public ReadOnlyCollection<Drogueria> ListarDrogueria()
        {
            return RepositorioDroguerias.Instancia.ListarDrogueria();
        }

        public ReadOnlyCollection<Monodroga> ListarMonodroga() 
        {
            return RepositorioMonodrogas.Instancia.ListarMonodroga();
        }

        public bool Agregar(Medicamento medicamento)
        {
            try
            {
                var agregarMedicamento = RepositorioMedicamentos.Instancia.ListarMedicamento();
                var agMed = agregarMedicamento.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (agMed == null)
                {
                    RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    return true;
                }
                else
                {
                    return false;
                }
                return false;
            }

            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Eliminar(Medicamento medicamento)
        {
            try
            {
                var aMedicamento = RepositorioMedicamentos.Instancia.ListarMedicamento();
                var agMed = aMedicamento.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (agMed != null)
                {
                    RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    return true;
                }
                else
                {
                    return false;
                }
                return false;
            }

            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Modificar(Medicamento medicamento)
        {
            try
            {
                var agregarMedicamento = RepositorioMedicamentos.Instancia.ListarMedicamento();
                var agMed = agregarMedicamento.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (agMed == null)
                {
                    RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    return true;
                }
                else
                {
                    return false;
                }
                return false;
            }

            catch (Exception ex)
            {
                return false;
            }

        }
    }

}
