using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using Modelo;

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

 
            public void AgregarMedicamento(Medicamento medicamento)
            {
                try
                {
                    var medicamentoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                    if (medicamentoExistente == null)
                        RepositorioMedicamentos.Instancia.Agregar(medicamento);
              
                }
                catch
                {
                }
            }

            public void ModificarMedicamento(Medicamento medicamento)
            {
                try
                {
                    var productoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                    if (productoExistente != null)
                        RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    
                }
                catch
                {
                }
            }

            public void EliminarMedicamento(Medicamento medicamento)
            {
                try
                {
                    var productoExistente = RepositorioMedicamentos.Instancia.Medicamentos.FirstOrDefault(c => c.NombreComercial == medicamento.NombreComercial);
                    if (productoExistente != null)
                        RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                }
                catch
                {
                }
            }

        }
}
