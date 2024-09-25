using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ActualizarVista();
        }
        private void ActualizarVista()
        {
            var list = Controladora.ControladoraMedicamentos.Instance.ListarMedicamento();
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = list;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = new FormMedicamento();
            form.ShowDialog();
            ActualizarVista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var ok = Controladora.ControladoraMedicamentos.Instance.Eliminar(medicamento);
                if (ok) ActualizarVista();
                else MessageBox.Show("No se pudo eliminar el medicamento");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentos = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var form = new FormMedicamento(medicamentos);
                form.ShowDialog();
                ActualizarVista();

            }
        }
    }
}
