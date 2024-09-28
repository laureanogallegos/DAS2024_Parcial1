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
        public string NombreComercial { get; set; }
        public Boolean EsVentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }

        private readonly List<Drogueria> droguerias;

        public ReadOnlyCollection<Drogueria> Droguerias => droguerias.AsReadOnly();

        public Medicamento() {
            droguerias = new List<Drogueria>();
        }

        public bool AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaExiste = droguerias.FirstOrDefault(dr => dr.Cuit == drogueria.Cuit);
            if (drogueriaExiste == null)
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
            var drogueriaExiste = droguerias.FirstOrDefault(dr => dr.Cuit == drogueria.Cuit);
            if (drogueriaExiste != null)
            {
                droguerias.Remove(drogueriaExiste);
                return true;
            }
            else 
            { 
                return false; 
            }
        }
    }
}
