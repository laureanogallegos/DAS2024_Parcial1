using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvMedicamentos.DataSource = RepositorioMedicamentos.Instancia.Medicamentos;

            cmbDrogueria.DataSource = RepositorioDroguerias.Instancia.Droguerias;
            cmbDrogueria.DisplayMember = "NombreComercial";

            cmbMonodroga.DataSource = RepositorioMonodrogas.Instancia.Monodrogas;
            cmbMonodroga.DisplayMember = "Nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Medicamento medicamento = new Medicamento
                {
                    NombreComercial = txtNombreComercial.Text,
                    EsVentaLibre = Convert.ToBoolean(chkEsVentaLibre.Checked),
                    PrecioDeVenta = Convert.ToDecimal(txtPrecioDeVenta.Text),
                    StockActual = Convert.ToInt32(txtStockActual.Text),
                    StockMinimo = Convert.ToInt32(txtStockMinimo.Text),
                    Monodroga = (Monodroga)cmbMonodroga.SelectedItem,
                    Drogueria = (Drogueria)cmbDrogueria.SelectedItem
                };

                if (AgregarMedicamentoController.Instancia.AgregarMedicamento(medicamento))
                {
                    dgvMedicamentos.DataSource = RepositorioMedicamentos.Instancia.Medicamentos;
                    MessageBox.Show("Medicamento agregado con �xito.", "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha podido agregar el medicamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Medicamento medicamento = new Medicamento
                {
                    NombreComercial = txtNombreComercial.Text,
                    EsVentaLibre = Convert.ToBoolean(chkEsVentaLibre.Checked),
                    PrecioDeVenta = Convert.ToDecimal(txtPrecioDeVenta.Text),
                    StockActual = Convert.ToInt32(txtStockActual.Text),
                    StockMinimo = Convert.ToInt32(txtStockMinimo.Text),
                    Monodroga = (Monodroga)cmbMonodroga.SelectedItem,
                    Drogueria = (Drogueria)cmbDrogueria.SelectedItem
                };

                if (ModificarMedicamentoController.Instancia.ModificarMedicamento(medicamento))
                {
                    dgvMedicamentos.DataSource = RepositorioMedicamentos.Instancia.Medicamentos;
                    MessageBox.Show("Medicamento modificado con �xito.", "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se ha podido modificar el medicamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Medicamento medicamento = dgvMedicamentos.SelectedRows[0].DataBoundItem as Medicamento;

            if (EliminarMedicamentoController.Instancia.EliminarMedicamento(medicamento))
            { 
                dgvMedicamentos.DataSource = RepositorioMedicamentos.Instancia.Medicamentos;
                MessageBox.Show("Medicamento eliminado con �xito.", "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El medicamento no se ha podido eliminar de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreComercial.Text))
            {
                MessageBox.Show("El nombre comercial no puede estar vac�o.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(txtPrecioDeVenta.Text, out decimal precioDeVenta) || precioDeVenta <= 0)
            {
                MessageBox.Show("El precio de venta debe ser un n�mero decimal positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtStockActual.Text, out int stockActual) || stockActual < 0)
            {
                MessageBox.Show("El stock actual debe ser un n�mero entero no negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtStockMinimo.Text, out int stockMinimo) || stockMinimo < 0)
            {
                MessageBox.Show("El stock m�nimo debe ser un n�mero entero no negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (stockActual < stockMinimo)
            {
                MessageBox.Show("El stock actual no puede ser menor que el stock m�nimo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbMonodroga.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una monodroga.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbDrogueria.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una droguer�a.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}