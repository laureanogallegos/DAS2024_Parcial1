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
        public bool EsVentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }
        public List<Drogueria> Droguerias { get; set; }

        public Medicamento()
        {
            Droguerias = new List<Drogueria>();
        }

        public bool AgregarDrogueria(Drogueria drogueria)
        {
            try
            {
                var drogueriaEncontrada = Droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
                if (drogueriaEncontrada != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
