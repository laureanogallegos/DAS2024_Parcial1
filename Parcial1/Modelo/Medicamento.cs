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
        public bool EsVentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }


        private List<Monodroga> monodrogas;

        public Medicamento()
        {
            monodrogas = new List<Monodroga>();
            droguerias = new List<Drogueria>();
        }
        public ReadOnlyCollection<Monodroga> Monodrogas
        {
            get => monodrogas.AsReadOnly();
        }
        


        private List<Drogueria> droguerias;

       
        public ReadOnlyCollection<Drogueria> Droguerias
        {
            get => droguerias.AsReadOnly();
        }

    }
}
