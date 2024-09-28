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

        private void Listado()
        {
            var list = ControladoraMedicamentos.Instance.RecuperarMedicamentos();
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = list;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formMedicamentos = new FormMedicamento();
            formMedicamentos.ShowDialog();
            Listado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var formMedicamento = new FormMedicamento(medicamento);
                formMedicamento.ShowDialog();
                Listado();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var ok = ControladoraMedicamentos.Instance.EliminarMedicamento(medicamento);
                if (ok)
                {
                    MessageBox.Show("Medicamento eliminado");
                    Listado();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el medicamento");
                }
            }
        }
    }
}
