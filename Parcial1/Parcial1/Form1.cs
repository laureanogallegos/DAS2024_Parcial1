using Modelo;

namespace Parcial1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarVista();
        }

        private void ActualizarVista()
        {
            var list = Controladora.ControladoraMedicamentos.Instancia.RecuperarMedicamentos;
            //dgvMedicamentos.DataSource = null;
            //dgvMedicamentos.DataSource = list;
        }


    }
}