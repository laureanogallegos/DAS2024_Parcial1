namespace Parcial1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnABMMedicamento_Click(object sender, EventArgs e)
        {
            Form formMedicamento = new FormMedicamento();
            formMedicamento.Show();
        }
    }
}