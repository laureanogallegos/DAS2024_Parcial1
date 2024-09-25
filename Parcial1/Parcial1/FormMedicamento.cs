using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class FormMedicamento : Form
    {
        bool modifica = false;
        Medicamento medicamentoMod;
        public FormMedicamento()
        {
            InitializeComponent();
        }

        public FormMedicamento(Medicamento medicamento)
        {
            medicamentoMod = medicamento;
            modifica = true;
            InitializeComponent();
            txtNombreComercial.Enabled = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!modifica)
            {
                if (ValidarDatos())
                {
                    var nuevoMedicamento = new Medicamento();
                    nuevoMedicamento.NombreComercial = txtNombreComercial.Text;
                    nuevoMedicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    nuevoMedicamento.StockActual = Convert.ToInt32(txtStock.Text);
                    nuevoMedicamento.StockMinimo = Convert.ToInt32(txtStock.Text);
                    nuevoMedicamento.VentaLibre = chBoxVentaLibre.Checked;
                    nuevoMedicamento.Monodroga = ControladoraMedicamentos.Instancia.ListarMonodrogas().FirstOrDefault(x => x.Nombre == cmbMonodroga.Text);

                    if (dgvDroguerias.Rows.Count != 0)
                    {
                        if (ControladoraMedicamentos.Instancia.AgregarMedicamento(nuevoMedicamento))
                        {
                            MessageBox.Show("Medicamento ingresado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido agregar el medicamento.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe agregar una drogueria.");

                    }
                }
                else
                {
                    medicamentoMod.NombreComercial = txtNombreComercial.Text;
                    medicamentoMod.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    medicamentoMod.StockActual = Convert.ToInt32(txtStock.Text);
                    medicamentoMod.StockMinimo = Convert.ToInt32(txtStock.Text);
                    medicamentoMod.VentaLibre = chBoxVentaLibre.Checked;
                    medicamentoMod.Monodroga = ControladoraMedicamentos.Instancia.ListarMonodrogas().FirstOrDefault(x => x.Nombre == cmbMonodroga.Text);

                    var ok = ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamentoMod);
                    if (ok)
                    {
                        MessageBox.Show("Se ha modificado el producto.");
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido modificar el producto.");

                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarDrogueria_Click(object sender, EventArgs e)
        {
            if (cmbDrogueria.Text != "")
            {
                if (ControladoraMedicamentos.Instancia.AgregarDrogueriaAlMedicamento(Convert.ToInt64(cmbDrogueria.Text)))
                {
                    ActualizarGrillaDrogueriasDelMedicamento();
                    MessageBox.Show("Drogueria agregada con éxito.");

                }
                else
                {
                    MessageBox.Show("No se ha podido agregar la drogueria.");

                }
            }
            else
            {
                MessageBox.Show("Seleccione una drogueria.");

            }
        }

        private bool ValidarDatos()
        {
            if (txtNombreComercial.Text != "" && txtStock.Text != "" && txtStockMinimo.Text != "" && txtPrecioVenta.Text != "" && cmbDrogueria.Text != "" && cmbMonodroga.Text != "")
            {
                return true;
            }
            return false;
        }

        public void ActualizarGrillaDrogueriasDelMedicamento()
        {
            dgvDroguerias.DataSource = null;
            dgvDroguerias.DataSource = ControladoraMedicamentos.Instancia.ListarDrogueriasDelMedicamento();
        }

        private void RellenarCmbDrogueria()
        {
            cmbDrogueria.DataSource = null;
            cmbDrogueria.DataSource = ControladoraMedicamentos.Instancia.ListarDroguerias();
        }

        private void RellenarCmbMonodroga()
        {
            cmbMonodroga.DataSource = null;
            cmbMonodroga.DataSource = ControladoraMedicamentos.Instancia.ListarMonodrogas();
        }

        private void btnEliminarDrogueria_Click(object sender, EventArgs e)
        {
            if (dgvDroguerias.SelectedRows.Count == 1)
            {
                Drogueria drogSeleccionada = (Drogueria)dgvDroguerias.CurrentRow.DataBoundItem;
                ControladoraMedicamentos.Instancia.EliminarDrogueriaDelMedicamento(drogSeleccionada);
                ActualizarGrillaDrogueriasDelMedicamento();
            }
        }

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            ActualizarGrillaDrogueriasDelMedicamento();
            RellenarCmbDrogueria();
            RellenarCmbMonodroga();
        }
    }
}
