using Controladora;
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
    public partial class FormMonodrogas : Form
    {
        public FormMonodrogas()
        {
            InitializeComponent();
        }

        private void Listado()
        {
            var list = ControladoraMonodroga.Instance.RecuperarMonodroga();
            dgvMonodroga.DataSource = null;
            dgvMonodroga.DataSource = list;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formMonodroga = new FormMonodroga();
            formMonodroga.ShowDialog();
            Listado();
        }

        private void FormMonodrogas_Load(object sender, EventArgs e)
        {
            this.dgvMonodroga.AutoGenerateColumns = false;
            Listado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMonodroga.Rows.Count > 0)
            {
                var mono = (Monodroga)dgvMonodroga.CurrentRow.DataBoundItem;
                var formMonodroga = new FormMonodroga(mono);
                formMonodroga.ShowDialog();
                Listado();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMonodroga.Rows.Count > 0)
            {
                var mono = (Monodroga)dgvMonodroga.CurrentRow.DataBoundItem;
                var ok = ControladoraMonodroga.Instance.EliminarMonodroga(mono);
                if (ok)
                {
                    MessageBox.Show("Monodroga eliminada");
                    Listado();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la monodroga");
                }
            }
        }
    }
}
