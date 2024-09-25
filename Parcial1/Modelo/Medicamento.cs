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
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int StockMin { get; set; }

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
            var drogueriaEncontrada = droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada == null)
            {
                droguerias.Add(drogueria);
                return $"La drogueria {drogueria.Cuit} fue agregada exitosamente.";
            }

            return $"La drogueria {drogueria.Cuit} ya fue registrada para este medicamento.";
        }

        public string QuitarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada == null)
            {
                droguerias.Remove(drogueria);
                return $"La drogueria {drogueria.Cuit} fue quitada exitosamente.";
            }

            return $"La drogueria {drogueria.Cuit} no está registrada para este medicamento.";
        }
    }
}
