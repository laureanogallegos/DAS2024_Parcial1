using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    internal class Medicamento
    {
        public long Nombre_commercial { get; set; }
        public string Es_Venta_Libre { get; set; }
        public string Precio_Venta { get; set; }
        public string Stock { get; set; }
        public string Stock_Minimo { get; set; }

        public Monodroga Monodroga { get; set; }
        public DrogueriaMedicamento DrogueriaMedicamento { get; set; }
    }
}
