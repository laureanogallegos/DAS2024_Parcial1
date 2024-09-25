using Modelo;
using Modelo.Objetos;
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
        public void AgregarMedicamento(Medicamento medicamento)
        {
            var filtrarMedi = RepositorioMedicamentos.Instancia.Listar().FirstOrDefault(m=>m.NombreComercial==medicamento.NombreComercial);

            if (filtrarMedi==null)
            {
                RepositorioMedicamentos.Instancia.Agregar(medicamento);
            }
            
        }

        public void Eliminar(Medicamento medi)
        {
            RepositorioMedicamentos.Instancia.Eliminar(medi);
        }

        public void Modificar(Medicamento medi, Medicamento mediNuevo)
        {
            RepositorioMedicamentos.Instancia.Modificar(medi, mediNuevo);
        }
        public ReadOnlyCollection<Medicamento> Listar()
        {
            return RepositorioMedicamentos.Instancia.Listar();
        }
    }
}
