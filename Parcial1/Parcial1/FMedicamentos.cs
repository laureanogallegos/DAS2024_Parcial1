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
    public partial class FMedicamentos : Form
    {
        public FMedicamentos()
        {
            InitializeComponent();
        }

        private void FMedicamentos_Load(object sender, EventArgs e)
        {
            ActualizaGrilla();
        }

        private void ActualizaGrilla()
        {
            var listaMedicamentos = Controladora.ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = listaMedicamentos;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var medicamentoForm = new FMedicamento();
            medicamentoForm.ShowDialog();
            ActualizaGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentoSeleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var medicamentoForm = new FMedicamento(medicamentoSeleccionado);
                medicamentoForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un medicamento para modificarlo");
            }
            ActualizaGrilla();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var respuesta = MessageBox.Show("¿Está seguro que desea eliminarlo?", "Atención", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    var medicamentoSeleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                    var elimina = ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamentoSeleccionado);
                    if(elimina != null)
                    {
                        MessageBox.Show(elimina, "Atención", MessageBoxButtons.OK);
                    }
                }
                else return;
            }
            else
            {
                MessageBox.Show("Seleccione un medicamento para eliminarlo");
            }
            ActualizaGrilla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
