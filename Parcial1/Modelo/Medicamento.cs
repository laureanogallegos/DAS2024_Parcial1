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
            var drogueriaExiste = droguerias.FirstOrDefault(dr => dr.Cuit == drogueria.Cuit);
            if (drogueriaExiste == null)
            {
                droguerias.Add(drogueria);
                return "Proveedor agregado correctamente";
            }
            else return "Proveedor ya existente";
        }

        public string QuitarDrogueria(Drogueria drogueria)
        {
            var drogueriaExiste = droguerias.FirstOrDefault(dr => dr.Cuit == drogueria.Cuit);
            if (drogueriaExiste != null)
            {
                droguerias.Remove(drogueriaExiste);
                return "Proveedor agregado correctamente";
            }
            else return "Proveedor no existente";
        }
    }
}
