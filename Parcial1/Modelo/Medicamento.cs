using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        private List<Drogueria> droguerias;

        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }
        public Monodroga Monodroga { get; set; } 
        public string NombreComercial { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool EsVentaLibre { get; set; }
        public ReadOnlyCollection<Drogueria> Droguerias { get => droguerias.AsReadOnly();  }
        public bool AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada == null)
            {
                droguerias.Add(drogueria);
                return true;
            }
            else
                return false;
        }
        public void QuitarDrogueria(Drogueria drogueria)
        {
            droguerias.Remove(drogueria);
        }
    }
}
