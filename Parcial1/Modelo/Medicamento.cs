using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    internal class Medicamento
    {
        public string Nombre_monodroga { get; set; }
        public string Nombre_comercial { get; set; }

        public bool Es_venta_libre {  get; set; }

        public decimal Precio_venta {  get; set; }

        public int Stock {  get; set; }

        public int Stock_minimo { get; set; }

    }
}
