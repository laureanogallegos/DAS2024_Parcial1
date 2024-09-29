using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public string NombreComercial { get; set; }
        public bool VentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockAcual {  get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }

        public List<Drogueria> droguerias;

        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }

        public string AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit && d.Direccion == drogueria.Direccion && d.RazonSocial == drogueria.RazonSocial && d.Email == drogueria.Email);
            if (drogueriaEncontrada == null)
            {
                droguerias.Add(drogueria);
                return "Drogueria agregada";
            }
            else
            {
                return "La drogueria ya existe";
            }
           
        }

        public string EliminarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit && d.Direccion == drogueria.Direccion && d.RazonSocial == drogueria.RazonSocial && d.Email == drogueria.Email);
            if (drogueriaEncontrada != null)
            {
                droguerias.Remove(drogueria);
                return "Drogueria eliminada";
            }
            else
            {
                return "Drogueria no existente";
            }
        }
       

    }
}
