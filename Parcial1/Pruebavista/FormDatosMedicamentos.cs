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

namespace Pruebavista
{
    public partial class FormDatosMedicamentos : Form
    {
        private Medicamento medicamento;
        private bool modifica = false;
        public FormDatosMedicamentos()
        {
            InitializeComponent();
            medicamento = new Medicamento();

        }

        public FormDatosMedicamentos(Medicamento medicamento)
        {
            InitializeComponent();
            this.medicamento = medicamento;
            modifica = true;
           

        }
    
        

        private void FormDatosMedicamentos_Load(object sender, EventArgs e)
        {
            if (modifica)
            {
                this.Text = "Modificar medicamento";
                txtNombreComercial.Text = medicamento.NombreComercial;
                txtNombreComercial.Enabled = false;
                chkVentaLibre.Checked = medicamento.VentaLibre;
                txtPrecioVenta.Text = medicamento.PrecioVenta.ToString();
                txtStock.Text = medicamento.StockActual.ToString();
                txtStockMinimo.Text = medicamento.StockMinimo.ToString();
                cmbMonodroga.Text = medicamento.monodroga.Nombre.ToString();

            }
            else
            {
                cmbDrogueria.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarDroguerias();
                cmbDrogueria.DisplayMember = "CUIT";
                cmbMonodroga.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarMonodrogas();
                cmbMonodroga.DisplayMember = "NOMBRE";
                this.Text = "Agregar medicamento";
            }
        }

        private void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {
            if (modifica)
            {
                medicamento.NombreComercial = txtNombreComercial.Text;
                medicamento.VentaLibre = chkVentaLibre.Checked;
                medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                medicamento.StockActual = Convert.ToInt32(txtStockMinimo.Text);
                medicamento.StockMinimo = Convert.ToInt32(txtStock.Text);
                medicamento.monodroga.Nombre = cmbMonodroga.Text;

                var mensaje = Controladora.ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);

            }
            else
            {
                medicamento.NombreComercial = txtNombreComercial.Text;
                var nombreMonodroga = cmbMonodroga.Text;
                var monodrogas = Controladora.ControladoraMedicamentos.Instancia.ListarMonodrogas();
                var monodrogaEncontrada = monodrogas.FirstOrDefault(m => m.Nombre.ToLower() == nombreMonodroga.ToLower());
                medicamento.monodroga = monodrogaEncontrada;
                medicamento.NombreComercial = txtNombreComercial.Text;
                medicamento.VentaLibre = chkVentaLibre.Checked;
                medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                medicamento.StockActual = Convert.ToInt32(txtStock.Text);
                medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);

                var mensaje = Controladora.ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);

            }
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarDrogueria_Click(object sender, EventArgs e)
        {
            medicamento.AgregarDrogueria((Drogueria)cmbDrogueria.SelectedItem);
            dgvAgregarDrogueria.DataSource = null;
            dgvAgregarDrogueria.DataSource = medicamento.ListaDroguerias;
        }
    }
}
