using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class FormDrogueria : Form
    {
        private readonly bool modifica = false;
        private readonly Drogueria drogueria1;
        public FormDrogueria()
        {
            InitializeComponent();
        }
        public FormDrogueria(Drogueria drogue)
        {
            InitializeComponent();
            this.drogueria1 = drogue;
            modifica = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!modifica)
            {
                AgregarDrogueria();
            }
            else
            {
                ModificarDrogueria();
            }
        }

        public void AgregarDrogueria()
        {
            if (ValidarCampos())
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

        public void ModificarDrogueria()
        {
            if (ValidarCampos())
            {
                drogueria1.Cuit = txtCuit.Text;
                drogueria1.RazonSocial = txtRazonSocial.Text;
                drogueria1.Email = txtEmail.Text;
                drogueria1.Direccion = txtDireccion.Text;

                var ok = ControladoraDrogueria.Instance.ModificarDrogueria(drogueria1);
                if (ok)
                {
                    MessageBox.Show("Modificado");
                }
                else
                {
                    MessageBox.Show("No se pudo modificar!");
                }
            }
        }

        private bool ValidarCampos()
        {

            if (string.IsNullOrWhiteSpace(txtCuit.Text))
            {
                MessageBox.Show("El campo 'Cuit es obligatorio.", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCuit.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                MessageBox.Show("El campo 'Razon Social es obligatorio.", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRazonSocial.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El campo 'Email es obligatorio.", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("El campo 'Direccion es obligatorio.", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDireccion.Focus();
                return false;
            }
            return true;
        }
    }
}