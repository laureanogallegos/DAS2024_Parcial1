using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controladora
{
    internal class ControladoraMedicamentos
    {
        private static readonly Lazy<ControladoraMedicamentos> instancia = new Lazy<ControladoraMedicamentos>(() => new ControladoraMedicamentos());
        public static ControladoraMedicamentos Instancia => instancia.Value;

        private List<Drogueria> droguerias;

        private ControladoraMedicamentos()
        {
            droguerias = [];
        }

        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            return droguerias.AsReadOnly();
        }


        public bool Agregar(Medicamento medicamento)
        {
            var filtrarMedicamentos = RepositorioMedicamento.Instancia.Listar().FirstOrDefault(med => med.Codigo == medicamento.NombreComercial);
            if (filtrarMedicamentos == null)
            {
                foreach (Drogueria drog in droguerias)
                {
                    medicamento.AgregarDrogueria(drog);
                }
                RepositorioMedicamento.Instancia.Agregar(medicamento);
                droguerias.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

      

        public ReadOnlyCollection<Medicamento> ListarMedicamentos()
        {
            return RepositorioMedicamento.Instancia.Listar().AsReadOnly();
        }

        public bool EliminarMedicamento(string nombre)
        {
            var busquedaMedicamento = RepositorioMedicamento.Instancia.Listar().FirstOrDefault(med => med.NombreComercial == nombre);
            if (busquedaMedicamento != null)
            {
                return RepositorioMedicamento.Instancia.Eliminar(busquedaMedicamento);
            }
            else
            {
                return false;
            }
        }

        public bool ModificarMedicamento(string nombre, Medicamento medicamentoNuevo)
        {
            var busquedaMedicamento = RepositorioMedicamento.Instancia.Listar().FirstOrDefault(med => med.NombreComercial == nombre);
            if (busquedaMedicamento != null)
            {
                return RepositorioMedicamento.Instancia.Modificar(busquedaMedicamento, medicamentoNuevo);
            }
            else
            {
                return false;
            }
        }
    }
}

