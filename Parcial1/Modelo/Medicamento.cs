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
        public decimal PrecioVenta {  get; set; }   
        public bool VentaLibre { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }

        private List<Drogueria> droguerias;
        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }
        public ReadOnlyCollection<Drogueria>Droguerias
        {
            get => droguerias.AsReadOnly();
        }
        public string AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = Droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada == null)
            {
                droguerias.Add(drogueria);
                return null;
            }
            else return "Droguería ya existente";

        }
        public string QuitarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = Droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada != null)
            {
                droguerias.Remove(drogueria);
                return null;
            }
            else return "Droguería no existente";
        }
    }
}
