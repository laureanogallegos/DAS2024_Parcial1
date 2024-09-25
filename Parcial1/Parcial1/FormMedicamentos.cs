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
        public Medicamento medicamento;
        public FormMedicamentos()
        {
            InitializeComponent();
            medicamento = new Medicamento();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            var seleccionDrogueria = (Drogueria)cmbDroguerias.SelectedItem;
            medicamento.QuitarDrogueria(seleccionDrogueria);
            ListarDroguerias();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            var seleccionDrogueria = (Drogueria)cmbDroguerias.SelectedItem;
            medicamento.AgregarDrogueria(seleccionDrogueria);
            ListarDroguerias();
        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            cmbMonodroga.DataSource = ControladoraMedicamentos.Instance.RecuperarMondrogas();
            cmbMonodroga.DisplayMember = "Nombre";
            cmbDroguerias.DataSource = ControladoraMedicamentos.Instance.RecuperarDroguerias();
            cmbDroguerias.DisplayMember = "Cuit";
        }

        public void ListarDroguerias()
        {
            var list = medicamento.ListadoDroguerias;
            dgvDroguerias.DataSource = null;
            dgvDroguerias.DataSource = list;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var nuevoMedicamento = new Medicamento
            {
                NombreComercial = txtNombre.Text,
                VentaLibre = Convert.ToBoolean(txtVentaLibre.Text),
                PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text),
                StockActual = Convert.ToInt32(txtPrecioVenta.Text),
                StockMinimo = Convert.ToInt32(txtStockMinimo.Text),
                Monodroga = (Monodroga)cmbMonodroga.SelectedItem,
                droguerias = medicamento.droguerias
            };
            var ok = ControladoraMedicamentos.Instance.AgregarMedicamento(nuevoMedicamento);
            if(ok)
            {
                MessageBox.Show("Agregado!");
            }
            else
            {
                MessageBox.Show("No fue agregado!");
            }
        }
    }
}
