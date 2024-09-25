using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1
{
    public partial class FormMedicamento : Form
    {
        List<Drogueria> listaDroguerias;
        List<Drogueria> listaDrogueriasSeleccionadas;
        Medicamento medicamento = new Medicamento();
        string selectedOption;
        public FormMedicamento()
        {
            InitializeComponent();
        }

        private void cbMedicamentoOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNombreComercial.Text = "";
            txtPrecioVenta.Text = null;
            txtStockActual.Text = null;
            txtStockMinimo.Text = null;

            selectedOption = cbMedicamentoOpciones.SelectedItem.ToString();

            switch (selectedOption)
            {
                case "AGREGAR":
                    groupBox1.Enabled = true;
                    btnMedicamento.Enabled = true;
                    btnMedicamento.Text = "AGREGAR";
                    txtNombreComercial.Enabled = true;
                    txtPrecioVenta.Enabled = true;
                    txtStockActual.Enabled = true;
                    txtStockMinimo.Enabled = true;
                    cbMonodroga.Enabled = true;
                    clbDroguerias.Enabled = true;
                    cbVentaLibre.Enabled = true;

                    lblNombreComercial.Enabled = true;
                    lblPrecioVenta.Enabled = true;
                    lblStockActual.Enabled = true;
                    lblStockMinimo.Enabled = true;
                    lblMonodroga.Enabled = true;
                    lblDroguerias.Enabled = true;
                    cbMonodroga.DataSource = null;
                    clbDroguerias.DataSource = null;
                    cbMonodroga.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarMonodroga();
                    clbDroguerias.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarDroguerias();
                    break;
                case "MODIFICAR":
                    groupBox1.Enabled = true;
                    btnMedicamento.Enabled = true;
                    btnMedicamento.Text = "MODIFICAR";
                    txtNombreComercial.Enabled = true;
                    txtPrecioVenta.Enabled = true;
                    txtStockActual.Enabled = true;
                    txtStockMinimo.Enabled = true;
                    cbMonodroga.Enabled = true;
                    clbDroguerias.Enabled = true;
                    cbVentaLibre.Enabled = true;

                    lblNombreComercial.Enabled = true;
                    lblPrecioVenta.Enabled = true;
                    lblStockActual.Enabled = true;
                    lblStockMinimo.Enabled = true;
                    lblMonodroga.Enabled = true;
                    lblDroguerias.Enabled = true;
                    cbMonodroga.DataSource = null;
                    clbDroguerias.DataSource = null;
                    cbMonodroga.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarMonodroga();
                    clbDroguerias.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListarDroguerias();
                    break;
                case "ELIMINAR":
                    groupBox1.Enabled = true;
                    btnMedicamento.Enabled = true;
                    btnMedicamento.Text = "ELIMINAR";
                    txtNombreComercial.Enabled = true;
                    txtPrecioVenta.Enabled = false;
                    txtStockActual.Enabled = false;
                    txtStockMinimo.Enabled = false;
                    cbMonodroga.Enabled = false;
                    clbDroguerias.Enabled = false;
                    cbVentaLibre.Enabled = false;

                    lblNombreComercial.Enabled = true;
                    lblPrecioVenta.Enabled = false;
                    lblStockActual.Enabled = false;
                    lblStockMinimo.Enabled = false;
                    lblMonodroga.Enabled = false;
                    lblDroguerias.Enabled = false;
                    cbMonodroga.DataSource = null;
                    clbDroguerias.DataSource = null;
                    break;
            }

        }

        private void cbMonodroga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonodroga.DataSource != null)
            {
                string monodrogaSeleccionada = "";
                monodrogaSeleccionada = cbMonodroga.SelectedItem.ToString();
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

        private void AgregarMedicamento()
        {
            medicamento.NombreComercial = txtNombreComercial.Text;
            medicamento.EsVentaLibre = cbVentaLibre.Checked;
            medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
            medicamento.StockActual = Convert.ToInt32((txtStockActual.Text).ToString());
            medicamento.StockMinimo = Convert.ToInt32((txtStockMinimo.Text).ToString());

            if (medicamento.Monodroga == null || medicamento.Droguerias.Count() == 0)
            {

                MessageBox.Show("Error al cargar el medicamento, no selecciono monodroga o drogueria.");
            }
            else
            {
                Boolean ok = Controladora.ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);
                if (ok)
                {

                    MessageBox.Show("Medicamento agregado correctamente");
                    //ActualizarVista();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el medicamento.");
                }
            }
        }

        private void ModificarMedicamento()
        {

            medicamento.NombreComercial = txtNombreComercial.Text;
            medicamento.EsVentaLibre = cbVentaLibre.Checked;
            medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
            medicamento.StockActual = Convert.ToInt32((txtStockActual.Text).ToString());
            medicamento.StockMinimo = Convert.ToInt32((txtStockMinimo.Text).ToString());

            if (medicamento.Monodroga == null || medicamento.Droguerias.Count() == 0)
            {

                MessageBox.Show("Error al cargar el medicamento, no selecciono monodroga o drogueria.");
            }
            else
            {
                Boolean ok = Controladora.ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);

                if (ok)
                {

                    MessageBox.Show("Medicamento modificado correctamente");
                    //ActualizarVista();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el medicamento.");
                }
            }
        }

        private void EliminarMedicamento()
        {
            string nombreComercial = txtNombreComercial.Text;
            Boolean ok = Controladora.ControladoraMedicamentos.Instancia.EliminarMedicamento(nombreComercial);
            if (ok)
            {
                MessageBox.Show("Medicamento eliminado correctamente");
                //ActualizarVista();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el Medicamento");
            }
        }

        private void btnMedicamento_Click(object sender, EventArgs e)
        {
            switch (selectedOption)
            {
                case "AGREGAR":
                    //ValidarDatos();
                    AgregarMedicamento();
                    break;
                case "MODIFICAR":
                    //ValidarDatos();
                    ModificarMedicamento();
                    break;
                case "ELIMINAR":
                    //ValidarDatos();
                    EliminarMedicamento();
                    break;
            }
        }

        private void clbDroguerias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbDroguerias.DataSource != null)
            {
                var seleccion = clbDroguerias.SelectedItem.ToString();
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

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            listaDrogueriasSeleccionadas = new List<Drogueria>();
        }
    }
}
