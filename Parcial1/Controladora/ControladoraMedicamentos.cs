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
        }

        public static ControladoraMedicamentos Instancia => instancia.Value;

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return RepositorioMedicamentos.Instancia.Listar();
            }
            catch
            {
                return new ReadOnlyCollection<Medicamento>(new List<Medicamento>());
            }

        }

        public ReadOnlyCollection<Monodroga> RecuperarMonodrogas()
        {
            try
            {
                return RepositorioMonodrogas.Instancia.Listar();
            }
            catch
            {
                return new ReadOnlyCollection<Monodroga>(new List<Monodroga>());
            }

        }

        public bool AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var productoExistente = RepositorioMedicamentos.Instancia.Listar().FirstOrDefault(c => c.Nombre_comercial == medicamento.Nombre_comercial);
                if (productoExistente == null)
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
                var productoExistente = RepositorioMedicamentos.Instancia.Listar().FirstOrDefault(c => c.Nombre_comercial == medicamento.Nombre_comercial);
                if (productoExistente != null)
                    return RepositorioMedicamentos.Instancia.Modificar(medicamento);
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
                var productoExistente = RepositorioMedicamentos.Instancia.Listar().FirstOrDefault(c => c.Nombre_comercial == medicamento.Nombre_comercial);
                if (productoExistente != null)
                    return RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                else return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
