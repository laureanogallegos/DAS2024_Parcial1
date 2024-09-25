using Controladora;

namespace Vista
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            actualizargrilla();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            actualizargrilla();
        }
        private void actualizargrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarMedicamentos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DatosMedicamentos datosMedicamentos = new DatosMedicamentos();
            datosMedicamentos.ShowDialog();
            actualizargrilla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentoSeleccionado = (Modelo.Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var formMedicamento = new DatosMedicamentos(medicamentoSeleccionado);
                formMedicamento.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un medicamento de la grilla para modificarlo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            actualizargrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentoSeleccionado = (Modelo.Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var respuesta = ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamentoSeleccionado);
                MessageBox.Show("se elimino Correctamente");
               

            }
            else
            {
                MessageBox.Show("Debe seleccionar un medicamento de la grilla para eliminarlo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            actualizargrilla();
        }
    }
}
