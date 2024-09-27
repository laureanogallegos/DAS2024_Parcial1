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
            ActualizarVista();
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
                    Monodroga = (Monodroga)cmbMonodroga.SelectedItem
                };

                Drogueria drogueria = (Drogueria)cmbDrogueria.SelectedItem;

                if (medicamento.AgregarDrogueria(drogueria))
                {
                    if (AgregarMedicamentoController.Instancia.AgregarMedicamento(medicamento))
                    {
                        dgvMedicamentos.AutoGenerateColumns = false;
                        dgvMedicamentos.DataSource = RepositorioMedicamentos.Instancia.Medicamentos;
                        MessageBox.Show("Medicamento agregado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido agregar el medicamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se ha podido asignar una droguería al medicamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un medicamento para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidarDatos())
            {
                var medicamentoSeleccionado = (Medicamento)dgvMedicamentos.SelectedRows[0].DataBoundItem;
                
                Medicamento medicamento = new Medicamento
                {
                    NombreComercial = txtNombreComercial.Text,
                    EsVentaLibre = Convert.ToBoolean(chkEsVentaLibre.Checked),
                    PrecioDeVenta = Convert.ToDecimal(txtPrecioDeVenta.Text),
                    StockActual = Convert.ToInt32(txtStockActual.Text),
                    StockMinimo = Convert.ToInt32(txtStockMinimo.Text),
                    Monodroga = (Monodroga)cmbMonodroga.SelectedItem
                };

                Drogueria drogueria = (Drogueria)cmbDrogueria.SelectedItem;

                if (medicamento.AgregarDrogueria(drogueria))
                {
                    if (ModificarMedicamentoController.Instancia.ModificarMedicamento(medicamento, medicamentoSeleccionado))
                    {
                        dgvMedicamentos.AutoGenerateColumns = false;
                        dgvMedicamentos.DataSource = RepositorioMedicamentos.Instancia.Medicamentos;
                        MessageBox.Show("Medicamento modificado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido modificar el medicamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se ha podido asignar una droguería al medicamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un medicamento para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Medicamento medicamento = dgvMedicamentos.SelectedRows[0].DataBoundItem as Medicamento;

            if (EliminarMedicamentoController.Instancia.EliminarMedicamento(medicamento))
            {
                dgvMedicamentos.AutoGenerateColumns = false;
                dgvMedicamentos.DataSource = RepositorioMedicamentos.Instancia.Medicamentos;
                MessageBox.Show("Medicamento eliminado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("El nombre comercial no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(txtPrecioDeVenta.Text, out decimal precioDeVenta) || precioDeVenta <= 0)
            {
                MessageBox.Show("El precio de venta debe ser un número decimal positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtStockActual.Text, out int stockActual) || stockActual < 0)
            {
                MessageBox.Show("El stock actual debe ser un número entero no negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtStockMinimo.Text, out int stockMinimo) || stockMinimo < 0)
            {
                MessageBox.Show("El stock mínimo debe ser un número entero no negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (stockActual < stockMinimo)
            {
                MessageBox.Show("El stock actual no puede ser menor que el stock mínimo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbMonodroga.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una monodroga.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbDrogueria.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una droguería.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ActualizarVista()
        {
            cmbMonodroga.DataSource = RepositorioMonodrogas.Instancia.Monodrogas;
            cmbMonodroga.DisplayMember = "Nombre";

            cmbDrogueria.DataSource = RepositorioDroguerias.Instancia.Droguerias;
            cmbDrogueria.DisplayMember = "Cuit";

            dgvMedicamentos.AutoGenerateColumns = false;
            dgvMedicamentos.DataSource = RepositorioMedicamentos.Instancia.Medicamentos;

            dgvMedicamentos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre Comercial", DataPropertyName = "NombreComercial" });
            dgvMedicamentos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Es Venta Libre", DataPropertyName = "EsVentaLibre" });
            dgvMedicamentos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio de Venta", DataPropertyName = "PrecioDeVenta" });
            dgvMedicamentos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Stock Minimo", DataPropertyName = "StockMinimo" });
            dgvMedicamentos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Stock Actual", DataPropertyName = "StockActual" });

            dgvMedicamentos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cuit Droguería", DataPropertyName = "CuitDrogueria" });
            dgvMedicamentos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre Monodroga", DataPropertyName = "NombreMonodroga" });
        }
    }
}