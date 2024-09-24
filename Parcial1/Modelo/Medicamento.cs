namespace Modelo
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string NombreComercial { get; set; }
        public Monodroga Monodroga { get; set; }
        public bool VentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public long StockActual { get; set; }
        public long StockMinimo { get; set; }
        public List<Drogueria> Droguerias { get; set; }

    }
}
