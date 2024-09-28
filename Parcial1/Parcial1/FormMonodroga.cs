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

        private readonly bool modifica = false;
        private readonly Monodroga monodroga1;
        public FormMonodroga()
        {
            InitializeComponent();
        }

        public FormMonodroga(Monodroga mono)
        {
            InitializeComponent();
            this.monodroga1 = mono;
            modifica = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!modifica)
            {
                AgregarMonodroga();
            }
            else
            {
                ModificarMonodroga();
            }
        }
        public void AgregarMonodroga()
        {
            if (ValidarCampos())
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
        }

        public void ModificarMonodroga()
        {
            if (ValidarCampos())
            {
                monodroga1.Nombre = txtNombre.Text;

                var ok = ControladoraMonodroga.Instance.ModificarMonodroga(monodroga1);
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

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo 'Nombre es obligatorio.", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            return true;
        }
        }
}
