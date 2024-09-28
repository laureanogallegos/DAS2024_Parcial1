using Controladora;
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

namespace Parcial1
{
    public partial class FormDroguerias : Form
    {
        public FormDroguerias()
        {
            InitializeComponent();
        }

        private void Listado()
        {
            var list = ControladoraDrogueria.Instance.RecuperarDroguerias();
            dgvDroguerias.DataSource = null;
            dgvDroguerias.DataSource = list;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formDrogueria = new FormDrogueria();
            formDrogueria.ShowDialog();
            Listado();
        }

        private void FormDroguerias_Load(object sender, EventArgs e)
        {
            this.dgvDroguerias.AutoGenerateColumns = false;
            Listado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDroguerias.Rows.Count > 0)
            {
                var drogue = (Drogueria)dgvDroguerias.CurrentRow.DataBoundItem;
                var formDrogueria = new FormDrogueria(drogue);
                formDrogueria.ShowDialog();
                Listado();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDroguerias.Rows.Count > 0)
            {
                var drogue = (Drogueria)dgvDroguerias.CurrentRow.DataBoundItem;
                var ok = ControladoraDrogueria.Instance.EliminarDrogueria(drogue);
                if (ok)
                {
                    MessageBox.Show("Drogueria eliminada");
                    Listado();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la drogueria");
                }
            }
        }
    }
}
