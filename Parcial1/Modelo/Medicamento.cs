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
        public bool VentaLibre { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }
        public List<Drogueria> Droguerias;

        public string AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = Droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada == null)
            {
                Droguerias.Add(drogueria);
                return "Drogueria agregado correctamente";
            }
            else return "Drogueria ya existente";
        }
        public string QuitarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = Droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada != null)
            {
                Droguerias.Remove(drogueria);
                return "Drogueria quitada correctamente";
            }
            else return "Drogueria no existente";
        }
    }
}
