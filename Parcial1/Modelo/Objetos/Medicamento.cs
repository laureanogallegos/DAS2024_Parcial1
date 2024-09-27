using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Objetos
{
    public class Medicamento
    {
        //nombre comercial, si es de venta libre, el precio de venta, el stock actual y el stock mínimo.
        public string NombreComercial { get; set; }
        public bool VentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga MonodrogaMedicamento { get; set; }
        
        private List<Drogueria> droguerias;

        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }

        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            return droguerias.AsReadOnly();
        }
        public void AgregarDrogueria(Drogueria drogueria)
        {
            var droFiltrada = droguerias.FirstOrDefault(drog=>drog.Cuit==drogueria.Cuit);
            if (droFiltrada==null)
            {
                droguerias.Add(drogueria);
            }
        }
        public override string ToString()
        {
            return NombreComercial;
        }
    }
}
