using Controladora;
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
        Medicamento medicamento;
        string selectedOption;
        public FormMedicamento()
        {
            InitializeComponent();
        }

        private void cbMedicamentoOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            medicamento = new Medicamento();
            txtNombreComercial.Text = "";
            txtPrecioVenta.Text = null;
            txtStockActual.Text = null;
            txtStockMinimo.Text = null;
            cbVentaLibre.Checked = false;

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
                    ActualizarVista();
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
                    ActualizarVista();
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
                ActualizarVista();
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
                    if (ValidarDatos())
                    {
                        AgregarMedicamento();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el medicamento. Revise los datos ingresados.");
                    }
                    break;

                case "MODIFICAR":
                    if (ValidarDatos())
                    {
                        ModificarMedicamento();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar el medicamento. Revise los datos ingresados.");
                    }
                    break;

                case "ELIMINAR":
                    if (ValidarDatos())
                    {
                        EliminarMedicamento();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el medicamento. Revise los datos ingresados.");
                    }
                    break;

                default:
                    MessageBox.Show("Debe seleccionar una opción válida.");
                    break;
            }
        }


        private void clbDroguerias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (clbDroguerias.DataSource != null)
            {
                var seleccion = clbDroguerias.Items[e.Index].ToString();
                // Si el estado es 'Checked', significa que se va a agregar
                if (e.NewValue == CheckState.Checked)
                {
                    var seleccionExistente = medicamento.Droguerias.FirstOrDefault(ls => ls.RazonSocial == seleccion);
                    if (seleccionExistente == null)
                    {
                        var drogueria = Controladora.ControladoraMedicamentos.Instancia.BuscarDrogueriaPorRazonSocial(seleccion);
                        if (drogueria != null)
                        {
                            medicamento.AgregarDrogueria(drogueria);
                        }
                    }
                }
                // Si el estado es 'Unchecked', significa que se va a eliminar
                else if (e.NewValue == CheckState.Unchecked)
                {
                    var seleccionExistente = medicamento.Droguerias.FirstOrDefault(ls => ls.RazonSocial == seleccion);
                    if (seleccionExistente != null)
                    {
                        medicamento.QuitarDrogueria(seleccionExistente);
                    }
                }
            }
        }


        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            ActualizarVista();
        }

        private void ActualizarVista()
        {
            dataGridView1.DataSource = null;
            var list = ControladoraMedicamentos.Instancia.ListarMedicamento();
            dataGridView1.DataSource = list;
            txtNombreComercial.Text = "";
            txtPrecioVenta.Text = null;
            txtStockActual.Text = null;
            txtStockMinimo.Text = null;
            cbVentaLibre.Checked = false;
            cbMonodroga.DataSource = null;
            clbDroguerias.DataSource = null;
            groupBox1.Enabled = false;
        }

        private bool ValidarDatos()
        {
            switch (selectedOption)
            {
                case "AGREGAR":
                case "MODIFICAR":
                    if (string.IsNullOrEmpty(txtNombreComercial.Text))
                    {
                        MessageBox.Show("Debe ingresar el nombre comercial del medicamento.");
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtPrecioVenta.Text) || !decimal.TryParse(txtPrecioVenta.Text, out _))
                    {
                        MessageBox.Show("Debe ingresar un precio de venta válido.");
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtStockActual.Text) || !int.TryParse(txtStockActual.Text, out _))
                    {
                        MessageBox.Show("Debe ingresar una cantidad válida de stock actual.");
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtStockMinimo.Text) || !int.TryParse(txtStockMinimo.Text, out _))
                    {
                        MessageBox.Show("Debe ingresar una cantidad válida de stock mínimo.");
                        return false;
                    }
                    if (cbMonodroga.SelectedItem == null)
                    {
                        MessageBox.Show("Debe seleccionar una monodroga.");
                        return false;
                    }
                    if (clbDroguerias.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Debe seleccionar al menos una droguería.");
                        return false;
                    }
                    break;

                case "ELIMINAR":
                    if (string.IsNullOrEmpty(txtNombreComercial.Text))
                    {
                        MessageBox.Show("Debe ingresar el nombre comercial del medicamento para eliminarlo.");
                        return false;
                    }
                    break;

                default:
                    MessageBox.Show("Debe seleccionar una opción válida.");
                    return false;
            }
            return true;
        }
    }
}
