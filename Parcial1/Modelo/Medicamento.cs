using System.Collections.ObjectModel;

namespace Modelo
{
    public class Medicamento
    {
        public string NombreComercial { get; set; }
        public bool Es_Venta_Libre { get; set; }
        public decimal Precio_Venta { get; set; }
        public int Stock { get; set; }
        public int Stock_Minimo { get; set; }
        public Monodroga Monodroga { get; set; }
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
