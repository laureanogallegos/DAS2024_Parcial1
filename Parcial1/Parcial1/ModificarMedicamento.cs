using Controladora;
using Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1
{
    public partial class ModificarMedicamento : Form
    {
        Medicamento medicamento;
        public ModificarMedicamento(Medicamento medi)
        {
            InitializeComponent();
            medicamento = medi;
        }

        private void ModificarMedicamento_Load(object sender, EventArgs e)
        {
            txtNombreComercial.Text = medicamento.NombreComercial;
            txtNombreComercial.Enabled = false;

            txtPrecioVenta.Text = medicamento.PrecioVenta.ToString();
            txtStockActual.Text = medicamento.StockActual.ToString();
            txtStockMinimo.Text = medicamento.StockMinimo.ToString();

            cmbMonodrogas.DataSource = null;
            cmbMonodrogas.DataSource = ControladoraMedicamentos.Instancia.LsitarMonodrogas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtNombreComercial.Text != "" && txtPrecioVenta.Text != "" && txtStockActual.Text != "" && txtStockMinimo.Text != "" && cmbMonodrogas.Text != "")
            {
                Medicamento medicamentoActualizado = new Medicamento()
                {
                    NombreComercial = txtNombreComercial.Text,
                    PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                    StockActual = int.Parse(txtStockActual.Text),
                    StockMinimo = int.Parse(txtStockMinimo.Text),
                    MonodrogaMedicamento = ControladoraMedicamentos.Instancia.LsitarMonodrogas().FirstOrDefault(mo => mo.Nombre == cmbMonodrogas.Text)
                };

                foreach (Drogueria drogueria in medicamento.ListarDroguerias())
                {
                    medicamentoActualizado.AgregarDrogueria(drogueria);
                }

                if (ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento, medicamentoActualizado))
                {
                    lblLeyenda.Text = "Modificado con éxito.";
                }
                else
                {
                    lblLeyenda.Text = "Error en la base de datos.";
                }
            }
            else
            {
                lblLeyenda.Text = "Completar todos los campos";
            }
            lblLeyenda.Visible = true;
        }
    }
}
