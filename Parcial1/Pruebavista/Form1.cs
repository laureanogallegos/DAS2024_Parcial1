using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pruebavista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ActualizarGrilla();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentoSeleccionado = (Modelo.Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var formMedicamento = new FormDatosMedicamentos(medicamentoSeleccionado);
                formMedicamento.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un medicamento de la grilla para modificarlo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formMedicamento = new FormDatosMedicamentos();
            formMedicamento.ShowDialog();
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarMedicamentos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentoSeleccionado = (Modelo.Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                Controladora.ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamentoSeleccionado);

            }
            else
            {
                MessageBox.Show("Debe seleccionar un medicamento de la grilla para modificarlo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarGrilla();
        }
    }
}
