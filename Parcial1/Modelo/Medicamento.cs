using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public Monodroga Monodroga { get; set; }

        public string NombreComercial { get; set; }

        public bool VentaLibre { get; set; }

        public decimal PrecioVenta { get; set; }

        public int StockActual { get; set; }

        public int StockMinimo { get; set; }

        public List<Drogueria> droguerias;

        public Medicamento()
        {
            droguerias = [];
        }

        public bool AgregarDrogueria(Drogueria drogueria)
        {
            var filtrarProveedor = droguerias.FirstOrDefault(pr => pr.Cuit == drogueria.Cuit);
            if (filtrarProveedor == null)
            {
                droguerias.Add(drogueria);
                return true;
            }
            return false;
        }
       
        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            return droguerias.AsReadOnly();
        }
    }
}
}
