namespace Modelo
{
    public class Medicamento
    {
        public string NombreComercial { get; set; }
        public bool EsVentaLibre { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }

        private List<Drogueria> droguerias;

        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }

        
        public string CuitDroguerias()
        {
            var drogueria = droguerias.FirstOrDefault();

            return drogueria != null ? drogueria.Cuit.ToString() : "error en drogueria";
        }
        
        public string CuitDrogueria
        {
            get => CuitDroguerias();
        }

        public IReadOnlyCollection<Drogueria> Droguerias
        {
            get => droguerias.AsReadOnly();
        }

        public bool AgregarDrogueria(Drogueria drogueria)
        {
            try
            {
                var drogueriaExistente = droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
                if (drogueriaExistente == null)
                {
                    droguerias.Add(drogueria);
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public string NombreMonodroga
        {
            get { return Monodroga != null ? Monodroga.Nombre : "error en monodroga"; }
        }
    }
}
