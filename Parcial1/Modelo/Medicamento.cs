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
        public string Nombre { get; set; }
        public bool EsVentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }

        private List<Drogueria> drogueriasMedicamento;

        public Medicamento()
        {
            drogueriasMedicamento = new List<Drogueria>();
        }

        public bool AgregarDrogueria(Drogueria drogueria)
        {
            var filtrarDrogueria = drogueriasMedicamento.FirstOrDefault(dr => dr.Cuit == drogueria.Cuit);
            if (filtrarDrogueria == null)
            {
                drogueriasMedicamento.Add(drogueria);
                return true;
            }
            return false;
        }
        public bool EliminarDrogueria(Drogueria drogueria)
        {
            var filtrarDrogueria = drogueriasMedicamento.FirstOrDefault(dr => dr.Cuit == drogueria.Cuit);
            if (filtrarDrogueria != null)
            {
                drogueriasMedicamento.Remove(drogueria);
                return true;
            }
            return false;
        }
        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            return drogueriasMedicamento.AsReadOnly();
        }

    }
}
