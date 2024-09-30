using Modelo;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private static readonly Lazy<ControladoraMedicamentos> instancia = new(() => new ControladoraMedicamentos());
        public static ControladoraMedicamentos Instancia => instancia.Value;

        public List<Drogueria> droguerias = new List<Drogueria>();

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return RepositorioMedicamentos.Instance.Medicamentos;
        }

        public ReadOnlyCollection<Monodroga> RecuperarMonodroga()
        {
            return RepositorioMonodrogas.Instancia.Monodrogas;
        }

        public ReadOnlyCollection<Drogueria> Droguerias()
        {
            return RepositorioDroguerias.Instancia.Droguerias;
        }

        public bool AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instance.Listar().FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente == null)
                {
                    foreach (var drogueria in droguerias)
                    {
                        medicamento.AgregarDrogueria(drogueria);
                    }
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
                var medicamentoExistente = RepositorioMedicamentos.Instance.Listar().FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente != null)
                {
                    foreach (var drogueria in droguerias)
                    {
                        medicamento.AgregarDrogueria(drogueria);
                    }
                    RepositorioMedicamentos.Instance.Modificar(medicamentoExistente);

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
                var medicamentoExistente = RepositorioMedicamentos.Instance.Listar().FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente != null)
                {
                    RepositorioMedicamentos.Instance.Eliminar(medicamentoExistente);
                    return true;
                }

                else return false;
            }
            catch
            {
                return false;
            }
        }

        public void AgregarDrogueria(Drogueria drogueria)
        {
            if (droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit) == null)
            {
                droguerias.Add(drogueria);
            }
        }

        public void EliminarDrogueria(Drogueria drogueria)
        {
            if (droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit) != null)
            {
                droguerias.Remove(drogueria);
            }
        }

        public ReadOnlyCollection<Drogueria> ListaMedicamentoDroguerias()
        {
            return droguerias.AsReadOnly();
        }
    }

}
