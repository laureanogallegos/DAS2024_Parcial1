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
        private string nombreComercial;
        private string tipoVenta;
        private decimal precioVenta;
        private int stockActual;
        private int stockMinimo;
        private Monodroga monodroga;



        public string NombreComercial { get => nombreComercial; set => nombreComercial = value; }
        public string TipoVenta { get => tipoVenta; set => tipoVenta = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int StockActual { get => stockActual; set => stockActual = value; }
        public int StockMinimo { get => stockMinimo; set => stockMinimo = value; }
        public Monodroga Monodroga { get => monodroga; set => monodroga = value; }

        private List<Drogueria> droguerias;

        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }

        public ReadOnlyCollection<Drogueria> Droguerias
        {
            get => droguerias.AsReadOnly();
        }


        public string Agregar(Drogueria drogueria)
        {
            var agregarDro = droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (agregarDro == null)
            {
                droguerias.Add(drogueria);
                return "Se agrego Correctamente";
            }
            else
            {
                return "No se Agrego Correctamnte";
            }
        }

        public string Eliminar(Drogueria drogueria)
        {
            var eliminarDro = droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (eliminarDro != null)
            {
                droguerias.Add(drogueria);
                return "Se elimino Correctamente";
            }
            else
            {
                return "No se elimino Correctamnte";
            }
        }
    }
}
