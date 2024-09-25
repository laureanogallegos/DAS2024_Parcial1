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

        public string AgregarMonodroga(Monodroga drogueria)
        {
           
        }

        public string EliminarDrogueria(Drogueria drogueria)
        {

        }
       

    }
}
