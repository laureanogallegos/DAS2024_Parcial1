using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class FormMedicamento : Form
    {
        public FormMedicamento()
        {
            InitializeComponent();
        }

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            cBMonodroga.DataSource = RepositorioMonodrogas.Instancia.Monodrogas;
            foreach (var drogueria in RepositorioDroguerias.Instancia.Droguerias)
            {
                clbDroguerias.Items.Add(drogueria.RazonSocial);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var medicamento = new Medicamento();
            medicamento.NombreComercial = tbNombreComercial.Text;
            medicamento.EsVentaLibre = cbVentaLibre.Checked;

            medicamento.PrecioVenta = Convert.ToDecimal(tbPrecioVenta);
            medicamento.Stock = Convert.ToInt32(tbStock);
            medicamento.StockMinimo = Convert.ToInt32(tbStockMinimo);

            ControladoraMedicamentos.Instancia.RegistrarMedicamento(medicamento);

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var medicamento = new Medicamento();
            medicamento.NombreComercial = tbNombreComercial.Text;
            medicamento.EsVentaLibre = cbVentaLibre.Checked;

            medicamento.PrecioVenta = Convert.ToDecimal(tbPrecioVenta);
            medicamento.Stock = Convert.ToInt32(tbStock);
            medicamento.StockMinimo = Convert.ToInt32(tbStockMinimo);

            ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var medicamento = new Medicamento();
            medicamento.NombreComercial = tbNombreComercial.Text;

            ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);

        }
    }
}