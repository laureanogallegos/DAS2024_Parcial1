using Controladora;
using Modelo;
using System.Drawing.Text;

namespace Parcial1
{
    public partial class AgregarMedicamentos : Form
    {
        Medicamento medModificado;     
        public AgregarMedicamentos()
        {
            InitializeComponent();
        }
        public AgregarMedicamentos(Medicamento medicamento)
        {
            InitializeComponent();
            RellenarCampos(medicamento);
            medModificado = medicamento;        
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            if (ValidarDatos())
            {
                var nuevoMedicamento = new Medicamento
                {
                    NombreComercial = txtNombreComercial.Text,
                    EsVentaLibre = cBoxVentaLibre.Checked,
                    PrecioVenta = Convert.ToDecimal(txtPrecioDeVenta.Text),
                    Stock = Convert.ToInt32(txtStock.Text),
                    StockMinimo = Convert.ToInt32(txtStockMinimo.Text),
                    Monodroga = ControladoraMedicamentos.Instancia.ListarMonodrogas().FirstOrDefault(x => x.Nombre == cBoxMonodrogas.Text)
                };
                if (ControladoraMedicamentos.Instancia.AgregarMedicamento(nuevoMedicamento))
                {
                    MessageBox.Show("Medicamento ingresado correctamente.");
                }
                else
                {
                    MessageBox.Show("No se ha podido agregar el medicamento.");
                }
            }
            ActualizarGrillaDrogueriasMedicamento();
        }
        private void RellenarCampos(Medicamento med)
        {
            txtNombreComercial.Text = med.NombreComercial;
            txtPrecioDeVenta.Text = med.PrecioVenta.ToString();
            txtStock.Text = med.Stock.ToString();
            txtStockMinimo.Text = med.StockMinimo.ToString();
            cBoxVentaLibre.Enabled = med.EsVentaLibre;
            cBoxMonodrogas.Text = med.Monodroga.Nombre.ToString();
            var list = med.ListarDroguerias();
            dgvDrogueriasMedicamento.DataSource = null;
            dgvDrogueriasMedicamento.DataSource = list;
        }

        private void btnAgregarDrog_Click(object sender, EventArgs e)
        {
            if (ControladoraMedicamentos.Instancia.AgregarDrogueriasAlMedicamento(Convert.ToInt64(cBoxDroguerias.Text)))
            {
                ActualizarGrillaDrogueriasMedicamento();
                MessageBox.Show("Droguería agregada con éxito.");
            }
            else
            {
                MessageBox.Show("No se ha podido agregar la droguería.");
            }
           
        }
        private bool ValidarDatos()
        {
            return !string.IsNullOrWhiteSpace(txtNombreComercial.Text) &&
                   !string.IsNullOrWhiteSpace(txtStock.Text) &&
                   !string.IsNullOrWhiteSpace(txtStockMinimo.Text) &&
                   !string.IsNullOrWhiteSpace(txtPrecioDeVenta.Text) &&
                   !string.IsNullOrWhiteSpace(cBoxDroguerias.Text) &&
                   !string.IsNullOrWhiteSpace(cBoxMonodrogas.Text);
        }
        public void ActualizarGrillaDrogueriasMedicamento()
        {
            dgvDrogueriasMedicamento.DataSource = null;
            dgvDrogueriasMedicamento.DataSource = ControladoraMedicamentos.Instancia.ListarDrogueriasDelMedicamento();
        }
        private void LlenarCBoxDrogueria()
        {
            cBoxDroguerias.DataSource = null;
            cBoxDroguerias.DataSource = ControladoraMedicamentos.Instancia.ListarDroguerias();
        }

        private void LlenarCBoxMonodroga()
        {
            cBoxMonodrogas.DataSource = null;
            cBoxMonodrogas.DataSource = ControladoraMedicamentos.Instancia.ListarMonodrogas();
        }

        private void AgregarMedicamentos_Load(object sender, EventArgs e)
        {
            LlenarCBoxDrogueria();
            LlenarCBoxMonodroga();
        }

        private void btnEliminarDroguerias_Click(object sender, EventArgs e)
        {
            if (dgvDrogueriasMedicamento.SelectedRows.Count == 1)
            {
                Drogueria drogueriaSelec = (Drogueria)dgvDrogueriasMedicamento.CurrentRow.DataBoundItem;
                ControladoraMedicamentos.Instancia.EliminarDrogueriaDelMedicamento(drogueriaSelec);
                ActualizarGrillaDrogueriasMedicamento();
            }
        }

        private void btnModifMedicamento_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                medModificado.NombreComercial = txtNombreComercial.Text;
                medModificado.EsVentaLibre = cBoxVentaLibre.Checked;
                medModificado.PrecioVenta = Convert.ToDecimal(txtPrecioDeVenta.Text);
                medModificado.Stock = Convert.ToInt32(txtStock.Text);
                medModificado.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                medModificado.Monodroga = ControladoraMedicamentos.Instancia.ListarMonodrogas().FirstOrDefault(x => x.Nombre == cBoxMonodrogas.Text);

                if (ControladoraMedicamentos.Instancia.ModificarMedicamento(medModificado))
                {
                    MessageBox.Show("Se modifico correctamente el medicamento");
                }
                else
                {
                    MessageBox.Show("No se ha podido modificar el medicamento");
                }
            }
        }
    }
}
