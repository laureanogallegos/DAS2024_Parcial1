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
        public bool EsVentaLibre {  get; set; }
        public decimal PrecioVenta {  get; set; }
        public int Stock {  get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }

        private List<Drogueria> droguerias;

        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }
        public void AgregarDrogueria(Drogueria nuevaDrogueria)
        {
            var drogueriaExiste = droguerias.FirstOrDefault(x => x.Cuit == nuevaDrogueria.Cuit);
            if(drogueriaExiste == null)
            {
                droguerias.Add(nuevaDrogueria);
               
            }
        }
        public void EliminarDrogueria(Drogueria nuevaDrogueria)
        {
            var drogueriaExiste = droguerias.FirstOrDefault(x => x.Cuit == nuevaDrogueria.Cuit);
            if(drogueriaExiste != null)
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
