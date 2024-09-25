using Controladora;
using Modelo;


namespace Parcial1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ActualizarVista()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos .DataSource = ControladoraMedicamentos.Instancia.ListarMedicamentos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formMedicamentos = new FormMedicamento();
            formMedicamentos.ShowDialog();
            ActualizarVista();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var medicametoSeleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
            var formMedicamento = new FormMedicamento(medicametoSeleccionado);
            formMedicamento.ShowDialog();
            ActualizarVista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.SelectedRows.Count == 1)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;

                var ok = ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamento);
                if (ok) ActualizarVista();
                else MessageBox.Show("No se pudo eliminar el medicamento.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}