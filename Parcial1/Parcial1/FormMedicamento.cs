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
    public partial class FormMedicamento : Form
    {
        private readonly Medicamento medicamentoModifica;
        private readonly Medicamento medicamentoAdd;
        private readonly bool modifica = false;
        public FormMedicamento()
        {
            InitializeComponent();
            medicamentoAdd = new Medicamento();
        }

        public FormMedicamento(Medicamento medicamento)
        {
            InitializeComponent();
            this.medicamentoModifica = medicamento;
            modifica = true;
        }

        private void btnQuitarDrogueria_Click(object sender, EventArgs e)
        {
            if (!modifica)
            {
                var seleccionDrogueria = (Drogueria)cmbDroguerias.SelectedItem;
                var ok = medicamentoAdd.QuitarDrogueria(seleccionDrogueria);
                if (ok)
                {
                    MessageBox.Show("Drogueria quitada!");
                    ListarDroguerias();
                }
                else
                {
                    MessageBox.Show("No se pudo quitar la drogueria!");
                }
            }
            else
            {
                var seleccionDrogueria = (Drogueria)cmbDroguerias.SelectedItem;
                var ok = medicamentoModifica.QuitarDrogueria(seleccionDrogueria);
                if (ok)
                {
                    MessageBox.Show("Drogueria quitada!");
                    ListarDroguerias();
                }
                else
                {
                    MessageBox.Show("No se pudo quitar la drogueria!");
                }
            }
            
        }

        private void btnAgregarDrogueria_Click(object sender, EventArgs e)
        {
            if(!modifica)
            {
                var seleccionDrogueria = (Drogueria)cmbDroguerias.SelectedItem;
                var ok = medicamentoAdd.AgregarDrogueria(seleccionDrogueria);
                if (ok)
                {
                    MessageBox.Show("Drogueria agregada!");
                    ListarDroguerias();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la drogueria!");
                }
           
            }
            else
            {
                var seleccionDrogueria = (Drogueria)cmbDroguerias.SelectedItem;
                var ok = medicamentoModifica.AgregarDrogueria(seleccionDrogueria);
                if (ok)
                {
                    MessageBox.Show("Drogueria agregada!");
                    ListarDroguerias();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la drogueria!");
                }
            }
        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            cmbMonodroga.DataSource = ControladoraMedicamentos.Instance.RecuperarMondrogas();
            cmbMonodroga.DisplayMember = "Nombre";
            cmbDroguerias.DataSource = ControladoraMedicamentos.Instance.RecuperarDroguerias();
            cmbDroguerias.DisplayMember = "RazonSocial";
        }

        public void ListarDroguerias()
        {
            if (!modifica)
            {
                var list = medicamentoAdd.ListadoDroguerias;
                dgvDroguerias.DataSource = null;
                dgvDroguerias.DataSource = list;
            }
            else
            {
                var list = medicamentoModifica.ListadoDroguerias;
                dgvDroguerias.DataSource = null;
                dgvDroguerias.DataSource = list;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!modifica)
            {
                AgregarDrogueria();
            }
            else
            {
                ModificarDrogueria();
            }
        }

        public void AgregarDrogueria()
        {
            if (ValidarCampos())
            {
                bool seleccionado = false;
                if (rbVLSi.Checked)
                {
                    seleccionado = true;
                }

                medicamentoAdd.NombreComercial = txtNombre.Text;
                medicamentoAdd.VentaLibre = seleccionado;
                medicamentoAdd.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                medicamentoAdd.StockActual = Convert.ToInt32(txtPrecioVenta.Text);
                medicamentoAdd.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                medicamentoAdd.Monodroga = (Monodroga)cmbMonodroga.SelectedItem;

                var ok = ControladoraMedicamentos.Instance.AgregarMedicamento(medicamentoAdd);
                if (ok)
                {
                    MessageBox.Show("Medicamento agregado!");
                }
                else
                {
                    MessageBox.Show("No fue agregado el medicamento!");
                }
            }
        }

        public void ModificarDrogueria()
        {
            if (ValidarCampos())
            {
                bool seleccionado = false;
                if (rbVLSi.Checked)
                {
                    seleccionado = true;
                }
                medicamentoModifica.NombreComercial = txtNombre.Text;
                medicamentoModifica.VentaLibre = seleccionado;
                medicamentoModifica.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                medicamentoModifica.StockActual = Convert.ToInt32(txtPrecioVenta.Text);
                medicamentoModifica.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                medicamentoModifica.Monodroga = (Monodroga)cmbMonodroga.SelectedItem;

                var ok = ControladoraMedicamentos.Instance.ModificarMedicamento(medicamentoModifica);
                if (ok)
                {
                    MessageBox.Show("Medicamento modificado!");
                }
                else
                {
                    MessageBox.Show("No fue modificado el medicamento!");
                }
            }
        
        }

        private bool ValidarCampos()
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo 'Nombre es obligatorio.", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrecioVenta.Text) || !decimal.TryParse(txtPrecioVenta.Text, out _))
            {
                MessageBox.Show("El campo 'Precio de venta es obligatorio.", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioVenta.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtStockActual.Text) || !int.TryParse(txtStockActual.Text, out _))
            {
                MessageBox.Show("El campo 'Stock actual es obligatorio.", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockActual.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtStockMinimo.Text) || !int.TryParse(txtStockMinimo.Text, out _))
            {
                MessageBox.Show("El campo 'Stock minimo es obligatorio.", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockMinimo.Focus();
                return false;
            }
            return true;
        }
    }
}
