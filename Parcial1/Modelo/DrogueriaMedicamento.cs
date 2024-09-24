using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    internal class DrogueriaMedicamento
    {
        public long Nombre_commercial { get; set; }
        public string Es_Venta_Libre { get; set; }
        public string Precio_Venta { get; set; }
        public string Stock { get; set; }
        public string Stock_Minimo { get; set; }

        public Monodroga Monodroga { get; set; }
    }
}
