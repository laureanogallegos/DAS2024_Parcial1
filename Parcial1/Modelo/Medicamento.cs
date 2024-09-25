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
        public string NombreComercial { get; set; }
        public bool VentaLibre { get; set; }
        public decimal PrecioVenta {  get; set; }
        public int StockActual {  get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }
        public List<Drogueria> droguerias { get; set; }

        public ReadOnlyCollection<Drogueria> ListadoDroguerias => droguerias.AsReadOnly();

        public bool AgregarDrogueria(Drogueria drogueria)
        {
           
            var drog = droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (drog == null)
            {
                droguerias.Add(drogueria);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool QuitarDrogueria(Drogueria drogueria)
        {
            var drog = droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (drog != null)
            {
                droguerias.Remove(drogueria);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
