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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void monodrogaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formMonodroga = new FormMonodroga();
            formMonodroga.ShowDialog();
        }

        private void drogueriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formDrogueria = new FormDrogueria();
            formDrogueria.ShowDialog();
        }

        private void medicamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formMedicamentos = new FormMedicamentos();
            formMedicamentos.ShowDialog();
        }
    }
}
