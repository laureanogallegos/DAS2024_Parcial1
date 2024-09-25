using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class DatosMedicamentos : Form
    {
        private Medicamento medicamento;
        private bool modifica = false;

        public DatosMedicamentos()
        {
            InitializeComponent();
            medicamento = new Medicamento();

        }

        public DatosMedicamentos(Medicamento medicamento)
        {
            InitializeComponent();
            modifica = true;
            this.medicamento = medicamento;
        }

        private void DatosMedicamentos_Load(object sender, EventArgs e)
        {
            if (modifica)
            {
                this.Text = "Modificar medicamento";
                txtNombre.Text = medicamento.NombreComercial;
                txtNombre.Enabled = false;
                chkVentaLibre.Checked = medicamento.VentaLibre;
                txtPrecioVenta.Text = medicamento.PrecioVenta.ToString();
                txtStockActual.Text = medicamento.StockActual.ToString();
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

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (modifica)
            {
                medicamento.NombreComercial = txtNombre.Text;
                medicamento.VentaLibre = chkVentaLibre.Checked;
                medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                medicamento.StockActual = Convert.ToInt32(txtStockActual.Text);
                medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                medicamento.monodroga.Nombre = cmbMonodroga.Text;

                Controladora.ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);
                MessageBox.Show("se modifico correctamente");
            }
            else
            {
                medicamento.NombreComercial = txtNombre.Text;
                medicamento.monodroga = (Monodroga)cmbMonodroga.SelectedItem;
                medicamento.VentaLibre = chkVentaLibre.Checked;
                medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                medicamento.StockActual = Convert.ToInt32(txtStockActual.Text);
                medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);

                var mensaje = Controladora.ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);
                if (mensaje == true)
                {
                    MessageBox.Show("Se agrego correctamente");

                }
                else
                {
                    MessageBox.Show("no se agrego correctamente");
                }
            }

            this.Close();
        }
            private void btnDrogueria_Click(object sender, EventArgs e)
            {
                medicamento.AgregarDrogueria((Drogueria)cmbDrogueria.SelectedItem);
                dgvDrogueria.DataSource = null;
            dgvDrogueria.DataSource = medicamento.ListaDroguerias;



            }
    }
}
