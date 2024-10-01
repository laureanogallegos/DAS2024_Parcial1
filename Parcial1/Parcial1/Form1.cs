using Controladora;
using Modelo;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Parcial1
{
    public partial class Form1 : Form

    {
        private Monodroga monodroga;
        private Medicamento medicamento;
        private List<Drogueria> droguerias; // Variable de instancia para la lista

        public Form1()
        {
            InitializeComponent();
            droguerias = new List<Drogueria>();
            medicamento = new Medicamento();
            medicamento.Monodroga = new Monodroga();


            /*dgvLista.DataSource = null;
            dgvLista.DataSource = ControladoraMedicamentos.Instancia.RecuperarMedicamentos();*/
            cmbMonodroga.DataSource = RepositorioMonodrogas.Instancia.Monodrogas;

            cmbDrogueria.DataSource = RepositorioDroguerias.Instancia.Droguerias;

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (IngresoDatos())
            {
                medicamento.NombreComercial = txtNombreComercial.Text;
                medicamento.StockActual = Convert.ToInt32(txtStock.Text);
                medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                medicamento.Monodroga.Nombre = cmbMonodroga.SelectedItem.ToString();
                if (rbNo.Checked)
                {
                    medicamento.EsVentaLibre = false;
                }
                else
                {
                    medicamento.EsVentaLibre = true;
                }

                foreach (var drogueria in droguerias)
                {
                    medicamento.AgregarDrogueria(drogueria);
                }
                var respuesta = ControladoraMedicamentos.Instancia.AgregarMedicamentos(medicamento);
                MessageBox.Show(respuesta);

            }
            else
            {
                MessageBox.Show("revise");
            }
            // limpio la lista de droguerias que le asigno a cada medicamento nuevo

            ActualizarGrilla();
            Limpiar();
            dgvDroguerias.DataSource = null;
        }

        private void btnDrogueria_Click(object sender, EventArgs e)
        {
            //creo una variable para guardor la drogueria q voy a agregar a las lista de mi nuevo medicamento
            var xDrogueria = cmbDrogueria.SelectedItem.ToString();
            //aunque no recibe valores nulos, chequeo que la drogueria este en la bse de datos
            var drogueriaMedicamento = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.RazonSocial.ToLower() == xDrogueria.ToLower());
            //reviso que no se repita la dorgueria por medicamento
            var repetir = droguerias.FirstOrDefault(x => x.RazonSocial.ToLower() == xDrogueria.ToLower());
            //como la dorgueria no esta en la lista me devuelve el valor nulo, entonces la puedo agregar 
            if (repetir == null)
            {
                droguerias.Add(drogueriaMedicamento);
                dgvDroguerias.DataSource = null;
                dgvDroguerias.DataSource = droguerias;
            }
            else
            {
                MessageBox.Show("SELECCIONE OTRA DROGUERIA");
            }
        }


        public bool IngresoDatos()
        {

            if (string.IsNullOrEmpty(txtNombreComercial.Text))
            {
                MessageBox.Show("debe ingresar un nombre");
                return false;
            }
            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("debe ingresar stock");
                return false;
            }
            if (!int.TryParse(txtStockMinimo.Text, out int stockMinimo))
            {
                MessageBox.Show("debe ingresar stock");
                return false;
            }
            if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta))
            {
                MessageBox.Show("debe ingresar precio de venta");
                return false;
            }
            if (droguerias.Count == 0)
            {
                MessageBox.Show("debe ingresar una drogueria");
                return false;
            }
            return true;
        }
        public void ActualizarGrilla()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }
        public void Limpiar()
        {
            txtNombreComercial.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtStockMinimo.Text = string.Empty;
            droguerias.Clear();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //checkeo que este seleccionado un medicamento del dgv
            if (dgvLista.CurrentRow != null)
            {
                var medicamentoSeleccionado = (Medicamento)dgvLista.CurrentRow.DataBoundItem;
                var resp = ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamentoSeleccionado);
                MessageBox.Show(resp);
            }

            else
            {
                MessageBox.Show("debe seleccionar un medicamento");
            }
            ActualizarGrilla();
        }
        public void LlenarForm()
        {
            if (dgvLista.CurrentRow != null)
            {
                var medicamentoSeleccionado = (Medicamento)dgvLista.CurrentRow.DataBoundItem;
                txtNombreComercial.Text = medicamentoSeleccionado.NombreComercial.ToLower();
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (IngresoDatos())
            {
                medicamento.StockActual = Convert.ToInt32(txtStock.Text);
                medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                medicamento.Monodroga = (Monodroga)cmbMonodroga.SelectedItem;
                if (rbNo.Checked)
                {
                    medicamento.EsVentaLibre = false;
                }
                else
                {
                    medicamento.EsVentaLibre = true;
                }

                foreach (var drogueria in medicamento.Droguerias)
                {
                    medicamento.AgregarDrogueria(drogueria);
                }
                var respuesta = ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);
                MessageBox.Show(respuesta);
            }

        }
        private void dgvLista_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                medicamento = (Medicamento)dgvLista.CurrentRow.DataBoundItem;
                txtNombreComercial.Text = medicamento.NombreComercial.ToLower();
                txtPrecioVenta.Text = medicamento.PrecioVenta.ToString();
                txtStock.Text = medicamento.StockActual.ToString();
                txtStockMinimo.Text = medicamento.StockMinimo.ToString();
                if (medicamento.EsVentaLibre == true)
                {
                    rbSi.Checked = true;
                }
                else
                {
                    rbNo.Checked = true;
                }
                cmbMonodroga.SelectedItem = cmbMonodroga.Items.Cast<Monodroga>().FirstOrDefault(m => m.Nombre == medicamento.Monodroga.Nombre);

                
                dgvDroguerias.DataSource = null;
                dgvDroguerias.DataSource = medicamento.Droguerias;            
        }
    }
}
