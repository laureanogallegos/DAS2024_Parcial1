using Controladora;
using Modelo.Objetos;

namespace Parcial1
{
    public partial class Form1 : Form
    {
        private List<Drogueria> droguerias;
        Drogueria drogueriaSeleccionada;
        public Form1()
        {
            InitializeComponent();
            ActualizarCMBS();
            droguerias = new List<Drogueria>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarCMBS();
        }

        private void ActualizarCMBS()
        {
            cmbDroguerias.DataSource = null;
            cmbDroguerias.DataSource = ControladoraMedicamentos.Instancia.ListarDroguerias();
            cmbMonodrogas.DataSource = null;
            cmbMonodrogas.DataSource = ControladoraMedicamentos.Instancia.LsitarMonodrogas();
        }

        private void btnCargarDrogueria_Click(object sender, EventArgs e)
        {
            var drogueria = ControladoraMedicamentos.Instancia.BuscarDrogueria(cmbDroguerias.Text);
            if (drogueria != null)
            {
                var filtrarEnLista = droguerias.FirstOrDefault(dr => dr.Cuit == drogueria.Cuit);
                if (filtrarEnLista == null)
                {
                    droguerias.Add(drogueria);
                    ActualizarGrilla();
                    lblLeyenda.Text = "";
                }
                else
                {
                    lblLeyenda.Text = "Esta drogueria ya se encuentra registrada.";
                }
                lblLeyenda.Visible = true;
            }
        }

        private void ActualizarGrilla()
        {
            dgvDrogueriasDelMedicamento.DataSource = null;
            dgvDrogueriasDelMedicamento.DataSource = droguerias.AsReadOnly();
        }

        private void btnRegistrarMedicamento_Click(object sender, EventArgs e)
        {
            var medicamento = ValidarCrearRegistroMedicamento();
            if (medicamento != null)
            {
                if (ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento, droguerias, cmbMonodrogas.Text))
                {
                    lblLeyenda.Text = "Medicamento cargado con éxito.";
                }
                else
                {
                    lblLeyenda.Text = "El medicamento no pudo ser registrado.";
                }
            }
            else
            {
                lblLeyenda.Text = "Completar todos los campos";
            }
            lblLeyenda.Visible = true;
            droguerias.Clear();
        }

        private Medicamento ValidarCrearRegistroMedicamento()
        {
            if (txtNombreComercial.Text != "" && txtPrecioVenta.Text != "" && txtStockActual.Text != "" && txtStockMinimo.Text != "" && cmbDroguerias.Text != "" && cmbMonodrogas.Text != "")
            {
                Medicamento medicamento = new Medicamento()
                {
                    NombreComercial = txtNombreComercial.Text,
                    PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                    StockActual = int.Parse(txtStockActual.Text),
                    StockMinimo = int.Parse(txtStockMinimo.Text),
                    VentaLibre = rbVentaLibre.Checked
                };
                return medicamento;
            }
            else
            {
                return null;
            }
        }

        private void btnVerMedicamentos_Click(object sender, EventArgs e)
        {
            FormMedicamentos formMedicamentos = new FormMedicamentos();
            formMedicamentos.ShowDialog();
        }

        private void dgvDrogueriasDelMedicamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            drogueriaSeleccionada = ControladoraMedicamentos.Instancia.ListarDroguerias().FirstOrDefault(dr => dr.Cuit == long.Parse(dgvDrogueriasDelMedicamento.Rows[e.RowIndex].Cells[0].Value.ToString()));
        }

        private void btnEliminarDrogueria_Click(object sender, EventArgs e)
        {
            if (drogueriaSeleccionada!=null)
            {
                droguerias.Remove(drogueriaSeleccionada);
                ActualizarGrilla();
            }
        }
    }
}