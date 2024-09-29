using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class Form1 : Form
    {
        Medicamento medicamento;
        public Form1()
        {
            InitializeComponent();
            ActualizarDGV();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormMedicamento formAgregar = new FormMedicamento();
            formAgregar.ShowDialog();
            ActualizarDGV();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.SelectedRows.Count == 1)
            {
                Medicamento medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                FormMedicamento formModificar = new FormMedicamento(medicamento);
                formModificar.ShowDialog();
                ActualizarDGV();
            }
            else
            {
                MessageBox.Show("Seleccione el medicamento a Modificar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.SelectedRows.Count == 1)
            {
                Medicamento medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                if (medicamento != null)
                {
                    ControladoraMedicamentos.Instancia.Eliminar(medicamento);
                    ActualizarDGV();
                }
            }
            else
            {
                MessageBox.Show("Seleccione el medicamento a eliminar");
            }
        }
        private void ActualizarDGV()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }
        private void dgvMedicamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
            dgvDroguerias.DataSource = null;
            dgvDroguerias.DataSource = medicamento.ListarDrogueria();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}