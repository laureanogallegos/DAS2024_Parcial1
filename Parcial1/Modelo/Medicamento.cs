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
        private List<Drogueria> listaDroguerias;

        public Medicamento()
        {
            listaDroguerias = new List<Drogueria>();
        }

        public bool AgregarDrogueria(Drogueria drogueria)
        {
            var existeDrogueria = listaDroguerias.FirstOrDefault(c => c.Cuit == drogueria.Cuit);
            if (existeDrogueria == null)
            {
                listaDroguerias.Add(drogueria);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarDrogueria(Drogueria drogueria)
        {
            var existeDrogueria = listaDroguerias.FirstOrDefault(c => c.Cuit == drogueria.Cuit);
            if (existeDrogueria != null)
            {
                listaDroguerias.Remove(drogueria);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ReadOnlyCollection<Drogueria> Droguerias
        {
            get => listaDroguerias.AsReadOnly();
        }
    }
}
