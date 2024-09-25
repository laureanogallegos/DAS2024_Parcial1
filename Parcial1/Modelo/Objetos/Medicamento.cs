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
        public string NombreComercial { get; set; }
        public string VentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int stockMinimo { get; set; }
        public Monodroga monodroga { get; set; }
        private List<Drogueria> droguerias;

            public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }

        public ReadOnlyCollection<Drogueria> LeerDroguerias()
        {
            return droguerias.AsReadOnly();
        }
        public void AgregarDrogueria(Drogueria dro)
        {
            var drogueria = droguerias.FirstOrDefault(drog=> drog.Cuit == dro.Cuit);
            if (drogueria == null)
            {
                droguerias.Add(dro);
            }
            
        }
    }
}
