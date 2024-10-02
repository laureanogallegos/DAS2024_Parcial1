using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public List<Drogueria> droguerias;

        public Medicamento() 
        { 
            droguerias = new List<Drogueria>();
        }
        public Monodroga Monodroga { get; set; }
        public string Nombre_comercial { get; set; }

        public bool Es_venta_libre {  get; set; }

        public decimal Precio_venta {  get; set; }

        public int Stock {  get; set; }

        public int Stock_minimo { get; set; }
        
        public IReadOnlyCollection<Drogueria> Droguerias { get => droguerias.AsReadOnly(); }

        public void AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada == null)
                droguerias.Add(drogueria);
        }

        public void EliminarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada == null)
            droguerias.Remove(drogueria);

        }
    }
}
