using Controladora;
using Modelo;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Parcial1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formMedicamento = new FormMain(); 
            if (formMedicamento.ShowDialog() == DialogResult.OK)
            {
                // Si se aceptaron los cambios, actualizamos la grilla
                ActualizarGrilla();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0) 
            {
                var medicamentoSeleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem; 
                var respuesta = ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamentoSeleccionado); 
            }
            else
            {
                MessageBox.Show("Seleccione un medicamento para eliminarlo"); 
            }
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentoSeleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var formMedicamento = new FormMain(medicamentoSeleccionado);

                if (formMedicamento.ShowDialog() == DialogResult.OK)
                {
                    
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un medicamento para modificarlo");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
