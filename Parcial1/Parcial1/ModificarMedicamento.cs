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
        List<Drogueria> drogueriaList = new List<Drogueria>();
        Drogueria drogueriaSeleccionada;
        public ModificarMedicamento(Medicamento medi)
        {
            InitializeComponent();
            medicamento = medi;
            foreach (Drogueria drog in medicamento.ListarDroguerias())
            {
                drogueriaList.Add(drog);
            }
            ActualizarGrilla();
        }

        private void ModificarMedicamento_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();

            cmbDroguerias.DataSource = null;
            cmbDroguerias.DataSource = ControladoraMedicamentos.Instancia.ListarDroguerias();

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

                foreach (Drogueria drogueria in drogueriaList)
                {
                    medicamentoActualizado.AgregarDrogueria(drogueria);
                }

                if (ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamentoActualizado))
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

        private void ActualizarGrilla()
        {
            dgvDrogueriasDelMedicamento.DataSource = null;
            dgvDrogueriasDelMedicamento.DataSource = drogueriaList.AsReadOnly();
        }

        private void dgvDrogueriasDelMedicamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            drogueriaSeleccionada = ControladoraMedicamentos.Instancia.ListarDroguerias().FirstOrDefault(dr => dr.Cuit == long.Parse(dgvDrogueriasDelMedicamento.Rows[e.RowIndex].Cells[0].Value.ToString()));
        }

        private void btnEliminarDrogueria_Click(object sender, EventArgs e)
        {
            if (drogueriaSeleccionada != null)
            {
                drogueriaList.Remove(drogueriaSeleccionada);
                ActualizarGrilla();
            }
            else
            {
                lblLeyenda.Text = "Debe seleccionar alguna drogueria";
            }
        }

        private void btnCargarDrogueria_Click(object sender, EventArgs e)
        {
            var drogueria = ControladoraMedicamentos.Instancia.ListarDroguerias().FirstOrDefault(dr=>dr.Cuit==long.Parse(cmbDroguerias.Text));
            if (drogueria!=null)
            {
                drogueriaList.Add(drogueria);
                ActualizarGrilla();
            }
            else
            {
                lblLeyenda.Text = "No se pudo agregar drogueria.";
            }
        }
    }
}
