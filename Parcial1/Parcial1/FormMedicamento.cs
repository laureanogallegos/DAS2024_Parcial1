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
        private Medicamento medicamento;
        private readonly bool modifica = false;
        public FormMedicamento()
        {
            InitializeComponent();

        }
        public FormMedicamento(Medicamento medicamento)
        {
            InitializeComponent();
            this.medicamento = medicamento;
            modifica = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (!modifica)
                {
                    AgregarMedicamento();
                }
                else
                {
                    ModificarMedicamento();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            cmbDrogueria.DataSource = Controladora.ControladoraMedicamentos.Instance.ListarDrogueria();
            cmbDrogueria.DisplayMember = "Cuit";
            cmbMonodroga.DataSource = Controladora.ControladoraMedicamentos.Instance.ListarMonodroga();
            cmbMonodroga.DisplayMember = "Nombre";
            if (medicamento != null)
            {
                txtNomb.Text = medicamento.NombreComercial;
                txtNomb.Enabled = false;
            }
        }
        private void AgregarMedicamento()
        {
            var medicamento = new Medicamento
            {
                NombreComercial = txtNomb.Text,
                TipoVenta = txtTipo.Text,
                
                StockActual = int.Parse(txtStockActual.Text), 
                StockMinimo = int.Parse(txtStokMin.Text), 
                PrecioVenta = decimal.Parse(txtPrecio.Text), 
                Monodroga = (Monodroga)cmbMonodroga.SelectedItem,
            };


            var Seleccionada = (Drogueria)cmbDrogueria.SelectedItem;
            var resultadoAgregar = medicamento.Agregar(Seleccionada);

            if (resultadoAgregar == "Se agrego Correctamente")
            {
                var ok = Controladora.ControladoraMedicamentos.Instance.Agregar(medicamento);
                if (ok)
                {
                    MessageBox.Show("Medicamento agregado correctamente");
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el medicamento");
                }
            }
            else
            {
                MessageBox.Show(resultadoAgregar);
            }
        }

        private void ModificarMedicamento()
        {
            medicamento.NombreComercial = txtNomb.Text;
            medicamento.Monodroga = (Monodroga)cmbMonodroga.SelectedItem;

            var Seleccionada = (Drogueria)cmbDrogueria.SelectedItem;
            var resultadoAgregar = medicamento.Agregar(Seleccionada);

            if (resultadoAgregar == "Se agrego Correctamente")
            {
                var ok = Controladora.ControladoraMedicamentos.Instance.Modificar(medicamento);
                if (ok)
                {
                    MessageBox.Show("Medicamento modificado correctamente");
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el medicamento");
                }
            }
            else
            {
                MessageBox.Show(resultadoAgregar);
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtNomb.Text))
            {
                MessageBox.Show("Debe ingresar ");
                return false;
            }
            if (string.IsNullOrEmpty(txtTipo.Text))
            {
                MessageBox.Show("Debe ingresar ");
                return false;
            }

            if (string.IsNullOrEmpty(cmbDrogueria.Text))
            {
                MessageBox.Show("Debe seleccionar ");
                return false;
            }
            if (string.IsNullOrEmpty(cmbMonodroga.Text))
            {
                MessageBox.Show("Debe seleccionar ");
                return false;
            }
            if (string.IsNullOrEmpty(txtStockActual.Text) || !int.TryParse(txtStockActual.Text, out int stockActual))
            {
                MessageBox.Show("El stock actual debe ser un número entero válido.");
                return false;
            }
            if (string.IsNullOrEmpty(txtStokMin.Text) || !int.TryParse(txtStokMin.Text, out int stockMinimo))
            {
                MessageBox.Show("El stock mínimo debe ser un número entero válido.");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrecio.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precioVenta))
            {
                MessageBox.Show("El precio de venta debe ser un número decimal válido.");
                return false;
            }
            return true;
        }
    }
}
