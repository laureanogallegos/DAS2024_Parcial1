using System;
using Controladora;
using Modelo;

namespace Parcial1
{
    
    public partial class Medicamentos : Form
    {
        int index = -1;
        public Medicamentos()
        {
            InitializeComponent();
            ActualizarGrillaMedicamentos();
        }

        private void ActualizarGrillaMedicamentos()
        {
            dgv_Medicamentos.DataSource = null;
            dgv_Medicamentos.DataSource = Controladora.ControladoraMedicamentos.Instancia.ListaDeMedicamentos();
        }


        private void EstadoBotonEliminarModificar()
        {
            if (dgv_Medicamentos.Rows.Count == 0)
            {
                btn_EliminarMed.Enabled = false;
                btn_ModMed.Enabled = false;
            }
            else
            {
                btn_EliminarMed.Enabled = true;
                btn_ModMed.Enabled = true;
            }
        }

        private void Medicamentos_Load(object sender, EventArgs e)
        {
            ActualizarGrillaMedicamentos();
            EstadoBotonEliminarModificar();
        }

        private void btn_EliminarMed_Click(object sender, EventArgs e)
        {
            if (dgv_Medicamentos.Rows.Count > 0)
            {
                var seleccion = (Modelo.Medicamento)dgv_Medicamentos.CurrentRow.DataBoundItem;
                ControladoraMedicamentos.Instancia.EliminarMedicamento(seleccion);
                MessageBox.Show("El medicamento ha sido eliminado");
                ActualizarGrillaMedicamentos();
            }
            else
            {
                MessageBox.Show("Seleccione el medicamento que desea eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_AgregarMed_Click(object sender, EventArgs e)
        {
            FormularioMedicamento formularioMedicamento = new FormularioMedicamento();
            formularioMedicamento.ShowDialog();
            ActualizarGrillaMedicamentos();
            
        }

        private void btn_ModMed_Click(object sender, EventArgs e)
        {
            var seleccion = (Modelo.Medicamento)dgv_Medicamentos.CurrentRow.DataBoundItem;
            var modificacion = new FormularioMedicamento(seleccion);
            modificacion.ShowDialog();
            ActualizarGrillaMedicamentos();
        }
        
        private void dgv_Medicamentos_SelectionChanged(object sender, EventArgs e)
        {
            index = -1;
           if (dgv_Medicamentos.CurrentRow != null)
           {
               var seleccion = (Modelo.Medicamento)dgv_Medicamentos.CurrentRow.DataBoundItem;
               CargaGrillaDrogueriasAdheridas(seleccion);
               EstadoBotonEliminarModificar();
           }
           else
           {
               dgvDAdheridas.DataSource = null;
               EstadoBotonEliminarModificar();
           }
        }

        private void CargaGrillaDrogueriasAdheridas(Medicamento medicamento)
        {
            dgvDAdheridas.DataSource = medicamento.ListaDeDroguerias;
        }
    }
}