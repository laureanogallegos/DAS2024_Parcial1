using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class Form1 : Form
    {
        private readonly Medicamento medicamento;
        public Form1()
        {
            InitializeComponent();
            var datosCombo = ControladoraMedicamentos.Instancia.RecuperarMonodrogas();
            foreach (Monodroga monodroga in datosCombo)
            {
                cmbNombreMono.Items.Add(monodroga.Nombre);
            }
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = Controladora.ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Medicamento medicamento = new Medicamento();
            if (txtNombreCom.Text != "" && txtPrecio.Text != "" && txtStock.Text != "" && txtStockMin.Text != "" && cmbNombreMono.Text != "")
            {
                medicamento.Nombre_comercial = txtNombreCom.Text;
                medicamento.Venta_libre = ckbVentaLib.Checked;
                medicamento.Precio_venta = Convert.ToInt32(txtPrecio.Text);
                medicamento.Stock = Convert.ToInt32(txtStock.Text);
                medicamento.Stock_minimo = Convert.ToInt32(txtStockMin.Text);
                medicamento.Nombre_monodroga = cmbNombreMono.Text;
                ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);
                ActualizarGrilla();
            }
        }

        private void dgvMedicamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count == 1)
            {
                var medicamentoSeleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var respuesta = ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamentoSeleccionado);
                ActualizarGrilla();
            }
            else
            {
                dgvMedicamentos.SelectedRows.Clear();
            }
        }
    }
}