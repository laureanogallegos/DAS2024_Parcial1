using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public Monodroga Monodroga { get; set; }
        public string NombreComercial { get; set; }

        public bool TipoVenta {  get; set; }

        public decimal PrecioDeVenta { get; set; }

        public int StockActual {  get; set; }

        public int StockMinimo { get; set; }

        public List<Drogueria> droguerias { get; set; }

        public void AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaExistente = droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
            if(drogueriaExistente == null)
            {
                droguerias.Add(drogueria);
            }
            

        }
    }
}
