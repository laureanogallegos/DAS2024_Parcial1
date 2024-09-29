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
using Controladora;

namespace Parcial1
{
    public partial class FormMedicamento : Form
    {
        bool Modifica = false;
        Medicamento medicamentoAModificar;
        public FormMedicamento()
        {
            InitializeComponent();
            ControladoraMedicamentos.Instancia.LimpiarDroguerias();
        }
        public FormMedicamento(Medicamento medicamento)
        {
            InitializeComponent();
            Modifica = true;
            medicamentoAModificar = medicamento;
            txtNombreComercial.Enabled = false;
            btnAgregarMedicamento.Text = "Modificar Medicamento";
            RellenarCampos(medicamentoAModificar);
            var medicamentoBuscado = ControladoraMedicamentos.Instancia.RecuperarMedicamentos().FirstOrDefault(x => x.NombreComercial == medicamentoAModificar.NombreComercial);
            dgvDrogueriasMedicamento.DataSource = null;
            dgvDrogueriasMedicamento.DataSource = medicamentoBuscado.ListarDrogueria();
            ControladoraMedicamentos.Instancia.LimpiarDroguerias();
            ControladoraMedicamentos.Instancia.ActualizarListaAModificar(medicamentoBuscado);
        }

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            cmbMonodrogas.DataSource = null;
            cmbMonodrogas.DataSource = ControladoraMedicamentos.Instancia.RecuperarMonodrogras();
            cmbDroguerias.DataSource = null;
            cmbDroguerias.DataSource = ControladoraMedicamentos.Instancia.RecuperarDroguerias();
            ActualizarGrillaDroguerias();
        }


        private void btnAgregarModificarMedicamento_Click(object sender, EventArgs e)
        {
            if (Modifica == false)
            {
                if (txtNombreComercial.Text == "" || txtPrecioVenta.Text == "" || txtStock.Text == "" || txtStockMinimo.Text == "" || cmbMonodrogas.Text == "")
                {
                    MessageBox.Show("Complete todos los campos");
                }
                else
                {
                    if (dgvDrogueriasMedicamento.Rows.Count == 0)
                    {
                        MessageBox.Show("Cargue al menos una drogueria al medicamento.");
                    }
                    else
                    {
                        Medicamento medicamento = new Medicamento();
                        medicamento.NombreComercial = txtNombreComercial.Text;
                        medicamento.VentaLibre = cbxVentaLibre.Checked;
                        medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                        medicamento.Stock = Convert.ToInt32(txtStock.Text);
                        medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                        medicamento.Monodroga = ControladoraMedicamentos.Instancia.RecuperarMonodrogras().FirstOrDefault(x => x.Nombre == cmbMonodrogas.Text);
                        if (ControladoraMedicamentos.Instancia.Agregar(medicamento))
                        {
                            MessageBox.Show("El medicamento se ha agregado.");
                        }
                        else
                        {
                            MessageBox.Show("El medicamento no se ha podido agregar.");
                        }
                        this.Close();
                    }
                }
            }
            else
            {
                if (txtNombreComercial.Text == "" || txtPrecioVenta.Text == "" || txtStock.Text == "" || txtStockMinimo.Text == "" || cmbMonodrogas.Text == "")
                {
                    MessageBox.Show("Complete todos los campos");
                }
                else
                {
                    if (dgvDrogueriasMedicamento.Rows.Count == 0)
                    {
                        MessageBox.Show("Cargue al menos una drogueria al medicamento.");
                    }
                    else
                    {
                        Medicamento medicamento = new Medicamento();
                        medicamento.NombreComercial = txtNombreComercial.Text;
                        medicamento.VentaLibre = cbxVentaLibre.Checked;
                        medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                        medicamento.Stock = Convert.ToInt32(txtStock.Text);
                        medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                        medicamento.Monodroga = ControladoraMedicamentos.Instancia.RecuperarMonodrogras().FirstOrDefault(x => x.Nombre == cmbMonodrogas.Text);
                        if (ControladoraMedicamentos.Instancia.Modificar(medicamentoAModificar, medicamento))
                        {
                            MessageBox.Show("El medicamento se ha modificado.");
                        }
                        else
                        {
                            MessageBox.Show("El medicamento no se ha podido modificar.");
                        }
                        this.Close();
                    }
                }
            }
        }
        private void RellenarCampos(Medicamento medicamentoAModificar)
        {
            txtNombreComercial.Text = medicamentoAModificar.NombreComercial;
            cbxVentaLibre.Checked = medicamentoAModificar.VentaLibre;
            txtPrecioVenta.Text = medicamentoAModificar.PrecioVenta.ToString();
            txtStock.Text = medicamentoAModificar.Stock.ToString();
            txtStockMinimo.Text = medicamentoAModificar.StockMinimo.ToString();
            cmbMonodrogas.Text = medicamentoAModificar.Monodroga.Nombre.ToString();
        }

        private void btnAgregarDrogueria_Click(object sender, EventArgs e)
        {
            if (cmbDroguerias.Text != "")
            {
                if (ControladoraMedicamentos.Instancia.AgregarDrogueria(ControladoraMedicamentos.Instancia.RecuperarDroguerias().FirstOrDefault(x => x.Cuit == Convert.ToInt64(cmbDroguerias.Text))))
                {
                    ActualizarGrillaDroguerias();
                    MessageBox.Show("Drogueria agregada con éxito.");

                }
                else
                {
                    MessageBox.Show("No se ha podido agregar la drogueria.");

                }
            }
        }
        private void btnEliminarDrogueria_Click(object sender, EventArgs e)
        {
            if (dgvDrogueriasMedicamento.SelectedRows.Count == 1)
            {
                if (ControladoraMedicamentos.Instancia.EliminarDrogueria((Drogueria)dgvDrogueriasMedicamento.CurrentRow.DataBoundItem))
                {
                    ActualizarGrillaDroguerias();
                    MessageBox.Show("Drogueria eliminada con éxito.");

                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar la drogueria.");
                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ActualizarGrillaDroguerias()
        {

            dgvDrogueriasMedicamento.DataSource = null;
            dgvDrogueriasMedicamento.DataSource = ControladoraMedicamentos.Instancia.ListarDrogueriasMedicamento();
        }

    }
}
