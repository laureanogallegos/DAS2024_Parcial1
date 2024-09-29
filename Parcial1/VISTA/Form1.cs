using Controladora;
using Modelo;

namespace VISTA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ActualizarGrilla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ControladoraMedicamento.Instancia.RecuperarMedicamento();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();
            form1.ShowDialog();
            ActualizarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var mediacamentoSeleccionado = (Medicamento)dataGridView1.CurrentRow.DataBoundItem;
                var respuesta = ControladoraMedicamento.Instancia.EliminarMedicamento(mediacamentoSeleccionado);
                MessageBox.Show(respuesta, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione una categoria para eliminarla");
            }
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var mediacamentoSeleccionado = (Medicamento)dataGridView1.CurrentRow.DataBoundItem;
                var form1 = new Form1(mediacamentoSeleccionado);
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione una categoria para modificarla");
            }
            ActualizarGrilla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
