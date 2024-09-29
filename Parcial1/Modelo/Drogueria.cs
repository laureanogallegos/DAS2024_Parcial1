namespace Modelo
{
    public class Drogueria
    {
        public long Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Cuit.ToString();
        }
    }
}
