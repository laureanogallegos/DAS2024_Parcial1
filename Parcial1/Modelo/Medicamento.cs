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
        public bool VentaLibre {  get; set; }
        public decimal PrecioVenta {  get; set; }
        public int Stock {  get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }
        private List<Drogueria> droguerias;

        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }

        public bool AgregarDrogueria(Drogueria drogueria)
        {
            if(droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit) == null)
            {
                droguerias.Add(drogueria);
                return true;
            }
            return false;
        }
        public bool EliminarDrogueria(Drogueria drogueria)
        {
            if (droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit) != null)
            {
                droguerias.Remove(drogueria);
                return true;
            }
            return false;
        }

        public ReadOnlyCollection<Drogueria> ListarDrogueria()
        {
            return droguerias.AsReadOnly();
        }
    }
}
