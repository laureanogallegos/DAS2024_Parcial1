using System;
using System.Collections.Generic;
using System.ComponentModel;
using Controladora;
using Modelo;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            ActualizarVista();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new AgregarMedicamentos();
            frm.ShowDialog();
            ActualizarVista();

        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            var medicSeleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
            var frm = new AgregarMedicamentos(medicSeleccionado);
            frm.ShowDialog();
            ActualizarVista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.SelectedRows.Count == 1) 
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;

                var elim = ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamento);
                if (elim)
                {
                    ActualizarVista();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el medicamento seleccionado");
                }
            }
        }

        private void dgvMedicamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var nombreComercial = dgvMedicamentos.Rows[i].Cells[0].Value.ToString();
                var medicSeleccionado = ControladoraMedicamentos.Instancia.ListarMedicamentos().FirstOrDefault(x => x.NombreComercial == nombreComercial);
                if (medicSeleccionado != null)
                {
                    dgvDroguerias.DataSource = null;
                    dgvDroguerias.DataSource = medicSeleccionado.ListarDroguerias();
                }
            }
        }
        private void ActualizarVista()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = ControladoraMedicamentos.Instancia.ListarMedicamentos();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            ActualizarVista();
        }
    }
}
