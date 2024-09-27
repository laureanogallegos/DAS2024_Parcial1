using Controladora;
using Modelo.Objetos;
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
            ActualizarCMB();
        }
        Medicamento medicamento;
        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            ActualizarCMB();
            ActualizarGrillas();
        }

        private void ActualizarCMB()
        {
            cmbMedicamentos.DataSource = null;
            cmbMedicamentos.DataSource = ControladoraMedicamentos.Instancia.LsitarMedicamentos();
        }

        private void cmbMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarGrillas();
        }

        private void btnModificarMedicamento_Click(object sender, EventArgs e)
        {
            ModificarMedicamento formModificarMedicamento = new ModificarMedicamento(medicamento);
            formModificarMedicamento.ShowDialog();
            ActualizarGrillas();
        }

        private void ActualizarGrillas()
        {
            List<Medicamento> medicamentoSeleccionado = new List<Medicamento>();
            medicamento = ControladoraMedicamentos.Instancia.LsitarMedicamentos().FirstOrDefault(me => me.NombreComercial == cmbMedicamentos.Text);
            medicamentoSeleccionado.Add(medicamento);
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = medicamentoSeleccionado.AsReadOnly();

            if (medicamento != null)
            {
                dgvDroguerias.DataSource = null;
                dgvDroguerias.DataSource = medicamento.ListarDroguerias();
            }
        }

        private void btnEliminarMedicamento_Click(object sender, EventArgs e)
        {
            if (ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamento))
            {
                lblLeyenda.Text = "Medicamento eliminado con éxito.";
                ActualizarCMB();
                ActualizarGrillas();
            }
            else
            {
                lblLeyenda.Text = "Medicamento no enconrado.";
            }
            lblLeyenda.Visible = true;
        }
    }
}
