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
        public bool EsVentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        private List<Drogueria> droguerias;
        public Medicamento()
        {
           droguerias = new List<Drogueria>();
        }
        public ReadOnlyCollection<Drogueria> Droguerias
        {
            get => droguerias.AsReadOnly();
        }
        public string AgregarDrogueria(Drogueria drogueria)
        {
            var x = droguerias.FirstOrDefault(x => x.Cuit.ToString() == drogueria.Cuit.ToString());
            if (x == null)
            {
                droguerias.Add(drogueria);
                return "drogueria agregada con existo";
            }
            else
                return "drogueria no existente";
        }
        public string EliminarDrogueria(Drogueria drogueria)
        {
            var x = droguerias.FirstOrDefault(x => x.Cuit.ToString() == drogueria.Cuit.ToString());
            if (x != null)
            {
                droguerias.Remove(drogueria);
                return "drogueria removido correctamente";
            }
            else
                return "drogueria no existente";
        }
    }
}
