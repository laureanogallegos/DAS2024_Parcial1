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
        public bool AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente == null)
                {
                    return RepositorioMedicamentos.Instancia.AgregarMedicamento(medicamento);
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
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente != null)
                {
                    return RepositorioMedicamentos.Instancia.ModificarMedicamento(medicamento);
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
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente == null)
                {
                    return RepositorioMedicamentos.Instancia.EliminarMedicamento(medicamento);
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
    }
}
