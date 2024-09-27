using Controladora;
using Modelo;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Parcial1
{
    public partial class FormMain : Form
    {
        private Medicamento medicamento;
        private bool modifica = false;
        List<Drogueria> listaDroguerias;
        List<Drogueria> listaDrogueriasSeleccionadas;

        public FormMain()
        {
            InitializeComponent();
            var droguerias = Controladora.ControladoraMedicamentos.Instancia.RecuperarDrogueria();
            foreach (Drogueria drogueria in droguerias)
            {
                cmbDrogueria.Items.Add(drogueria.Cuit);
            }
            medicamento = new Medicamento();
        }

        public FormMain(Medicamento medicamento)
        {
            InitializeComponent();
            this.medicamento = medicamento;
            modifica = true;
        }


        private void ActualizarCMB()
        {
            cmbDrogueria.Items.Clear();
            var droguerias = Controladora.ControladoraMedicamentos.Instancia.RecuperarDrogueria();
            foreach (Drogueria drogueria in droguerias)
            {
                var drogueriaEncontrada = medicamento.Droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
                if (drogueriaEncontrada == null)
                {
                    cmbDrogueria.Items.Add(drogueria.Cuit);
                }
            }
            cmbDrogueria.Text = "";
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtNombreComercial.Text))
            {
                MessageBox.Show("Debe ingresar el código", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (string.IsNullOrEmpty(this.cmbMonodroga.Text))
            {
                MessageBox.Show("Debe ingresar el código de la monodroga", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtStockMinimo.Text, out int cantidadMinima))
            {
                MessageBox.Show("Por favor, ingrese la cantidad correctamente");
                return false;
            }
            if (!decimal.TryParse(txtPrecioDeVenta.Text, out decimal precioVenta))
            {
                MessageBox.Show("Por favor, ingrese el precio de venta correctamente");
                return false;
            }
            return true;
        }



        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            if (modifica)
            {
                this.Text = "Modificar Medicamento";
                txtNombreComercial.Enabled = false;
                txtNombreComercial.Text = medicamento.NombreComercial;
                txtStockActual.Text = medicamento.StockActual.ToString();
                txtStockMinimo.Text = medicamento.StockMinimo.ToString();
                txtPrecioDeVenta.Text = medicamento.PrecioVenta.ToString();
                cmbMonodroga.Text = medicamento.Monodroga.Nombre.ToString();
                cmbDrogueria.Text = medicamento.Droguerias.ToString();
                ActualizarCMB();
            }
            else
            {
                this.Text = "Agregar Medicamento";
            }
            var monodrogas = Controladora.ControladoraMedicamentos.Instancia.RecuperarMonodroga();
            foreach (Monodroga monodroga in monodrogas)
            {
                cmbMonodroga.Items.Add(monodroga.Nombre);
            }
        }





        private void txtCantidadMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo puedes ingresar números en la casilla de cantidad mínima...", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("No puedes ingresar letras en la casilla de precio de venta...", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbDrogueria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDrogueria.DataSource != null)
            {
                var seleccion = cmbDrogueria.SelectedItem.ToString();
                int cantidadElementos = medicamento.Droguerias.Count();
                if (medicamento.Droguerias.Count() > 1)
                {
                    var seleccionExistente = medicamento.Droguerias.FirstOrDefault(ls => ls.RazonSocial == seleccion);
                    if (seleccionExistente == null)
                    {
                        medicamento.AgregarDrogueria(Controladora.ControladoraMedicamentos.Instancia.BuscarDrogueriaPorRazonSocial(seleccion));
                    }
                }
                else
                {
                    medicamento.AgregarDrogueria(Controladora.ControladoraMedicamentos.Instancia.BuscarDrogueriaPorRazonSocial(seleccion));
                }
            }
        }

        private void cmbMonodroga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonodroga.DataSource != null)
            {
                string monodrogaSeleccionada = cmbMonodroga.SelectedItem.ToString();
                if (monodrogaSeleccionada != "")
                {
                    Monodroga monodrogaExistente = Controladora.ControladoraMedicamentos.Instancia.BuscarMonodrogaPorNombre(monodrogaSeleccionada);
                    if (monodrogaExistente != null)
                    {
                        medicamento.Monodroga = monodrogaExistente;
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar la monodroga del medicamento");
                    }
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            listaDrogueriasSeleccionadas = new List<Drogueria>();
            ActualizarCMBMonodrogas();
        }
        private void ActualizarCMBMonodrogas()
        {
            cmbMonodroga.Items.Clear();
            var monodrogas = Controladora.ControladoraMedicamentos.Instancia.RecuperarMonodroga();
            foreach (Monodroga monodroga in monodrogas)
            {
                // Si el medicamento ya tiene monodroga asignada, no la mostramos en el ComboBox
                if (medicamento.Monodroga == null || medicamento.Monodroga.Nombre != monodroga.Nombre)
                {
                    cmbMonodroga.Items.Add(monodroga.Nombre);
                }
            }
            cmbMonodroga.Text = "";
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (modifica)
                {
                    // Modificar medicamento existente
                    medicamento.NombreComercial = txtNombreComercial.Text;
                    medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                    medicamento.StockActual = Convert.ToInt32(txtStockActual.Text);
                    medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioDeVenta.Text);
                    medicamento.Monodroga.Nombre = cmbMonodroga.Text;


                    var mensaje = ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Agregar nuevo medicamento
                    var Monodroga = cmbMonodroga.Text;
                    var monodrogas = Controladora.ControladoraMedicamentos.Instancia.RecuperarMonodroga();
                    var monodrogaEncontrada = monodrogas.FirstOrDefault(monodroga => monodroga.Nombre.ToLower() == Monodroga.ToLower());

                    medicamento.NombreComercial = txtNombreComercial.Text;
                    medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                    medicamento.StockActual = Convert.ToInt32(txtStockActual.Text);
                    medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioDeVenta.Text);
                    medicamento.Monodroga = monodrogaEncontrada;


                    var mensaje = ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}

