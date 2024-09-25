using Controladora;
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
    public partial class FormMedicamentos : Form
    {
        public FormMedicamentos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form formAgregar = new FormMedicamento();
            formAgregar.ShowDialog();
            ActualizarVista();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                Form formModificar = new FormMedicamento(medicamento);
                formModificar.ShowDialog();
                ActualizarVista();
            }
            else
            {
                MessageBox.Show("No hay ningun medicamento para modificar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var eliminado = ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamento);
                if (eliminado)
                {
                    MessageBox.Show("Medicamento eliminado correctamente");
                }
                else
                {
                    MessageBox.Show("Error: no se pudo eliminar el medicamento");
                }
                ActualizarVista();
            }
            else
            {
                MessageBox.Show("No hay ningun medicamento para eliminar");
            }
        }

        private void ActualizarVista()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            ActualizarVista();
        }
    }
}
