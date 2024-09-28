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
    public partial class FMedicamento : Form
    {
        private readonly Medicamento medicamento;
        private readonly bool modifica = false;
        public FMedicamento()
        {
            InitializeComponent();
            medicamento = new Medicamento();
            cbDroguerias.Items.Clear();
            cbMonodrogas.Items.Clear();
            CargarDroguerias();
            CargarMonodrogas();
        }
        public FMedicamento(Medicamento medicamento)
        {
            InitializeComponent();
            this.medicamento = medicamento;
            modifica = true;
            cbDroguerias.Items.Clear();
            cbMonodrogas.Items.Clear();
            CargarDroguerias();
            CargarMonodrogas();
        }
        private void CargarDroguerias()
        {
            var droguerias = Controladora.ControladoraMedicamentos.Instancia.RecuperarDroguerias();
            //Cargo las droguerias que recupero en la controladora de Medicamentos en el comboBox
            foreach (var drogueria in droguerias)
            {
                cbDroguerias.Items.Add(drogueria.Cuit);
            }
        }
        private void CargarMonodrogas()
        {
            var monodrogas = Controladora.ControladoraMedicamentos.Instancia.RecuperarMonodrogas();
            //agrego el nombre las monodrogas al comboBox
            foreach (var monodroga in monodrogas)
            {
                cbMonodrogas.Items.Add(monodroga.Nombre);
            }
        }
        private void ActualizaGrillaDroguerias()
        {
            dgvDroguerias.DataSource = null;
            dgvDroguerias.DataSource = medicamento.Droguerias;
        }
        private void ActualizarCbDroguerias()
        {
            cbDroguerias.Items.Clear(); // Limpio el ComboBox
            var droguerias = Controladora.ControladoraMedicamentos.Instancia.RecuperarDroguerias();
            // Agrego todas las droguerias al comboBox, sin importar si ya están asignadas
            foreach (Drogueria drogueria in droguerias)
            {
                cbDroguerias.Items.Add(drogueria.Cuit);
            }
            cbDroguerias.Text = "";
        }
        private bool ValidaDatos()
        {
            if (string.IsNullOrEmpty(txtNombreComercial.Text))
            {
                MessageBox.Show("Debe ingresar el nombre comercial del medicamento");
                return false;
            }
            if (string.IsNullOrEmpty(cbMonodrogas.Text))
            {
                MessageBox.Show("Debe ingresar la monodroga del medicamento");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                MessageBox.Show("Debe ingresar el precio de venta del medicamento");
                return false;
            }
            if (Convert.ToDecimal(txtPrecioVenta.Text) < 0)
            {
                MessageBox.Show("El precio de venta no puede ser negativo");
                return false;
            }
            if (string.IsNullOrEmpty(txtStockActual.Text))
            {
                MessageBox.Show("Debe ingresar el stock actual del medicamento");
                return false;
            }
            if (Convert.ToInt32(txtStockActual.Text) < 0)
            {
                MessageBox.Show("El stock actual debe ser mayor o igual a cero");
                return false;
            }
            if (string.IsNullOrEmpty(txtStockMinimo.Text))
            {
                MessageBox.Show("Debe ingresar stock mínimo del medicamento");
                return false;
            }
            if (Convert.ToInt32(txtStockMinimo.Text) < 0)
            {
                MessageBox.Show("El stock mínimo debe ser mayor o igual a cero");
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                var nombreMonodroga = cbMonodrogas.Text;
                var monodrogas = ControladoraMedicamentos.Instancia.RecuperarMonodrogas();
                var monodrogaEncontrada = monodrogas.FirstOrDefault(m => m.Nombre == nombreMonodroga);

                if (monodrogaEncontrada == null)
                {
                    MessageBox.Show("Monodroga no encontrada", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (dgvDroguerias.Rows.Count == 0)
                {
                    MessageBox.Show("Debe asignarle al menos una droguería al medicamento");
                    cbDroguerias.Focus();
                    return;
                }

                if (modifica)
                {
                    medicamento.NombreComercial = txtNombreComercial.Text;
                    medicamento.Monodroga = monodrogaEncontrada;
                    medicamento.VentaLibre = cbVentaLibre.Checked;
                    medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    medicamento.Stock = Convert.ToInt32(txtStockActual.Text);
                    medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                    var mensaje = Controladora.ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);
                    MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK);
                }
                else
                {
                    medicamento.NombreComercial = txtNombreComercial.Text;
                    medicamento.Monodroga = monodrogaEncontrada;
                    medicamento.VentaLibre = cbVentaLibre.Checked;
                    medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    medicamento.Stock = Convert.ToInt32(txtStockActual.Text);
                    medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                    var mensaje = Controladora.ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);
                    if (mensaje != null)
                    {
                        MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK);
                    }
                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FMedicamento_Load(object sender, EventArgs e)
        {
            cbDroguerias.Items.Clear();
            cbMonodrogas.Items.Clear();
            CargarDroguerias();
            CargarMonodrogas();
            if (modifica)
            {
                this.Text = "Modificar medicamento";
                txtNombreComercial.Text = medicamento.NombreComercial;
                txtNombreComercial.Enabled = false;
                cbMonodrogas.Text = medicamento.Monodroga.Nombre;
                cbVentaLibre.Checked = medicamento.VentaLibre;
                txtStockActual.Text = medicamento.Stock.ToString();
                txtStockMinimo.Text = medicamento.StockMinimo.ToString();
                txtPrecioVenta.Text = medicamento.PrecioVenta.ToString();
                ActualizaGrillaDroguerias();
                ActualizarCbDroguerias();
            }
            else
            {
                this.Text = "Agregar medicamento";
            }
        }

        private void btnAgregarDrogueria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cbDroguerias.Text))
            {
                MessageBox.Show("Debe ingresar un cuit de droguería", "Atención", MessageBoxButtons.OK);
                return;
            }
            // convierto el cuit del comboBox a un número entero
            var cuitDrogueria = Convert.ToInt64(cbDroguerias.Text);

            // busco la drogueria en la lista de droguerias 
            var drogueriaEncontrada = Controladora.ControladoraMedicamentos.Instancia.RecuperarDroguerias().FirstOrDefault(d => d.Cuit == cuitDrogueria);

            // verifico si la drogueria ya está asignada al medicamento
            var drogueriaYaAsignada = medicamento.Droguerias.FirstOrDefault(d => d.Cuit == cuitDrogueria);

            // si ya está asignada muestra un mensaje y no la agrega
            if (drogueriaYaAsignada != null)
            {
                MessageBox.Show("La drogueria ya está asignada a este medicamento", "Atención", MessageBoxButtons.OK);
                return;
            }
            // si no está asignada se asigna al medicamento
            var respuesta = medicamento.AgregarDrogueria(drogueriaEncontrada);
            if (respuesta != null)
            {
                MessageBox.Show(respuesta, "Atención", MessageBoxButtons.OK);
            }
            ActualizarCbDroguerias();
            ActualizaGrillaDroguerias();
        }
        private void btnQuitarDrogueria_Click(object sender, EventArgs e)
        {
            if (dgvDroguerias.Rows.Count > 0)
            {
                var drogueriaSeleccionada = (Drogueria)dgvDroguerias.CurrentRow.DataBoundItem;
                var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar esta droguería?", "Confirmación", MessageBoxButtons.YesNo);

                // si el usuario pone que si se elimina a la drogueria
                if (confirmacion == DialogResult.Yes)
                {
                    var respuesta = medicamento.QuitarDrogueria(drogueriaSeleccionada);
                    if (respuesta != null)
                    {
                        MessageBox.Show(respuesta, "Atención", MessageBoxButtons.OK);
                    }

                    ActualizarCbDroguerias();
                    ActualizaGrillaDroguerias();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una droguería para eliminarla de la lista", "Atención", MessageBoxButtons.OK);
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtStockActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
