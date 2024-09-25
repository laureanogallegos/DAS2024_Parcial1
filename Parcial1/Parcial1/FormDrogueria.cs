using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class FormDrogueria : Form
    {
        public FormDrogueria()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var Drogueria = new Drogueria
            {
                Cuit = txtCuit.Text,
                RazonSocial = txtRazonSocial.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text
            };

            var ok = ControladoraDrogueria.Instance.AgregarDrogueria(Drogueria);
            if (ok)
            {
                MessageBox.Show("Agregado!");
            }
            else
            {
                MessageBox.Show("No se pudo agregar!");
            }
        }
    }
}