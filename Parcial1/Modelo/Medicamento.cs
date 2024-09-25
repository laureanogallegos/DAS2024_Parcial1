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


        public decimal PrecioVenta { get; set; }

        public int StockActual { get; set; }

        public int StockMinimo { get; set; }

        public bool VentaLibre { get; set; }

        public List<Drogueria> ListaDroguerias { get; set; } = new List<Drogueria>();

        public Monodroga monodroga { get; set; }

        public bool AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaencontrada = ListaDroguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
            if (drogueriaencontrada == null)
            {
                ListaDroguerias.Add(drogueria);
                return true;
            }
            else
            {
                return false;
            }



        }

        public bool EliminarDrogueria(Drogueria drogueria)
        {
            var drogueriaencontrada = ListaDroguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
            if (drogueriaencontrada != null)
            {
                ListaDroguerias.Remove(drogueria);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
