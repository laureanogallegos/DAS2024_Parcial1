using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modelo
{
    public class Medicamento
    { 
        public Monodroga Monodroga {  get; set; }
        public string NombreComercial {  get; set; }
        public bool VentaLibre {  get; set; }
        public decimal PrecioVenta {  get; set; }
        public int StockActual {  get; set; }
        public int StockMinimo {  get; set; }

        private List<Drogueria> droguerias;

        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }

        public void AgregarDrogueria(Drogueria nuevaDrogueria)
        {
            var drogueriaExistente = droguerias.FirstOrDefault(x => x.Cuit == nuevaDrogueria.Cuit);
            if (drogueriaExistente == null)
            {
                droguerias.Add(nuevaDrogueria);
            }
        }

        public void EliminarDrogueria(Drogueria nuevaDrogueria)
        {
            var drogueriaExistente = droguerias.FirstOrDefault(x => x.Cuit == nuevaDrogueria.Cuit);
            if (drogueriaExistente != null)
            {
                droguerias.Remove(nuevaDrogueria);
            }
        }

        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            return droguerias.AsReadOnly();
        }
    }
}
