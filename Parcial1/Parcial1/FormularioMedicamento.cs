using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace Parcial1
{
    public partial class FormularioMedicamento : Form
    {
        private Medicamento medicamento;
        private bool modificar = false;
        public FormularioMedicamento()
        {
            InitializeComponent();
            medicamento = new Medicamento();
        }

        public FormularioMedicamento(Medicamento medicamento)
        {
            InitializeComponent();
            modificar = true;
            this.medicamento = medicamento;
        }

        private void FormularioMedicamento_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                this.Text = "Modificar medicamento";

                txtNombre.Text = medicamento.NombreComercial;
                txtNombre.Enabled= false;
                txtPrecio.Text = medicamento.PrecioVenta.ToString();
                txtStockMinimo.Text = medicamento.PrecioVenta.ToString();
                txtStock.Text = medicamento.Stock.ToString();
                txtStockMinimo.Text = medicamento.StockMinimo.ToString();
                chkVenta.Checked = medicamento.EsVentaLibre;
                cbMonodroga.Text = medicamento.monodroga.Nombre.ToString();
                cbMonodroga.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarMonodrogas();
                cbMonodroga.DisplayMember = "NOMBRE";
                cbDroguerias.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarDroguerias();
                cbDroguerias.DisplayMember = "RAZONSOCIAL";
                dgv_Drogueiras.DataSource = medicamento.ListaDeDroguerias;
            }
            else
            {
                this.Text = "Nuevo medicamento";
                cbDroguerias.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarDroguerias();
                cbDroguerias.DisplayMember = "RAZONSOCIAL";
                cbMonodroga.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarMonodrogas();
                cbMonodroga.DisplayMember = "NOMBRE";
            }
        }

        private void btn_AsociarDrog_Click(object sender, EventArgs e)
        {
            medicamento.AgregarDrogueria((Drogueria)cbDroguerias.SelectedItem);
            dgv_Drogueiras.DataSource = null;
            dgv_Drogueiras.DataSource = medicamento.ListaDeDroguerias;
        }

        private void btn_EliminarDrog_Click(object sender, EventArgs e)
        {
            medicamento.EliminarDrogueria((Drogueria)dgv_Drogueiras.CurrentRow.DataBoundItem);
            dgv_Drogueiras.DataSource = null;
            dgv_Drogueiras.DataSource = medicamento.ListaDeDroguerias;
        }

        private void btn_CargarMed_Click(object sender, EventArgs e)
        {
            if (modificar == true)
            {
                medicamento.NombreComercial = txtNombre.Text;
                medicamento.PrecioVenta = Convert.ToDecimal(txtPrecio.Text);
                medicamento.Stock = Convert.ToInt32(txtStock.Text);
                medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                medicamento.EsVentaLibre = chkVenta.Checked;
                medicamento.monodroga.Nombre = cbMonodroga.Text;
                Controladora.ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);

                MessageBox.Show("Modificación Exitosa");
            }
            else
            {
                medicamento.NombreComercial = txtNombre.Text;
                medicamento.PrecioVenta = Convert.ToDecimal(txtPrecio.Text);
                medicamento.Stock = Convert.ToInt32(txtStock.Text);
                medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                medicamento.EsVentaLibre = chkVenta.Checked;
                medicamento.monodroga = ((Monodroga)cbMonodroga.SelectedItem);
                var respuesta = Controladora.ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);
                
                if (respuesta == true)
                {
                    MessageBox.Show("Se cargó un nuevo medicamento");
                }
                else
                {
                    MessageBox.Show("Carga Fallida");
                }
            }
            this.Close();
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
