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
        public string AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                
                if (medicamentoExistente == null)
                {
                    var resultado = RepositorioMedicamentos.Instancia.AgregarMedicamento(medicamento);
                    if(resultado)
                    {
                        return null;
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} no se pudo registrar";
                    }
                }
                else
                {
                    return "El medicamento ya está registrado";
                }
            }
            catch
            {
                return "Error";
            }
        }
        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                if (medicamentoExistente != null)
                {
                    var resultado = RepositorioMedicamentos.Instancia.ModificarMedicamento(medicamento);
                    if(resultado)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se modificó correctamente";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} no se pudo modificar";
                    }
                }
                else
                {
                    return "El medicamento no existe";
                }
            }
            catch
            {
                return "Error";
            }
        }
        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                var resultado = RepositorioMedicamentos.Instancia.EliminarMedicamento(medicamento);
                if (medicamentoExistente != null)
                {
                    if (resultado)
                    {
                        return null;
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} no se pudo eliminar";
                    }
                }
                else
                {
                    return "El medicamento no existe";
                }
            }
            catch
            {
                return "Error";
            }
        }
    }
}
