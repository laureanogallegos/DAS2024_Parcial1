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
        public decimal PrecioVenta {  get; set; }
        public int Stock {  get; set; }
        public int StockMinimo { get; set; }
        public string NombreMonodroga { get; set; }
        public bool EsVentaLibre { get; set; }
        public Monodroga monodroga { get; set; }
        public List<Drogueria> ListaDeDroguerias { get; set; } = new List<Drogueria>();

        
        
        
        public bool AgregarDrogueria(Drogueria drogueria)
        {
            var controldrogueria = ListaDeDroguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
            if (controldrogueria == null)
            {
                ListaDeDroguerias.Add(drogueria);
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool EliminarDrogueria(Drogueria drogueria)
        {
            var controldrogueria = ListaDeDroguerias.FirstOrDefault(e => e.Cuit == drogueria.Cuit);
            if (controldrogueria != null)
            {
                ListaDeDroguerias.Remove(drogueria);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
