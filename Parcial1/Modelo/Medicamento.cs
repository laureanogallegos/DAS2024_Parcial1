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
        public byte EsVentaLibre {  get; set; }
        public int PrecioVenta {  get; set; }
        public int Stock {  get; set; }
        public int StockMinimo { get; set; }
        
    }
}
