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
    public partial class FormMonodroga : Form
    {
        public FormMonodroga()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var monodroga = new Monodroga
            {
                Nombre = txtNombre.Text
            };
            var ok = ControladoraMonodroga.Instance.AgregarMonodroga(monodroga);
            if (ok)
            {
                MessageBox.Show("Agregado");
            }
            else
            {
                MessageBox.Show("No se pudo agregar!");
            }
        }

        private void FormMonodroga_Load(object sender, EventArgs e)
        {
            dgvMonodrogas.AutoGenerateColumns = false;
            Listar();

        }

        public void Listar()
        {
            var list = RepositorioMonodrogas.Instancia.Monodrogas;
            dgvMonodrogas.DataSource = null;
            dgvMonodrogas.DataSource = list;
        }
    }
}
