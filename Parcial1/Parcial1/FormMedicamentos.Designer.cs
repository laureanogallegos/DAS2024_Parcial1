namespace Parcial1
{
    partial class FormMedicamentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbMedicamentos = new ComboBox();
            label1 = new Label();
            dgvMedicamentos = new DataGridView();
            dgvDroguerias = new DataGridView();
            btnModificarMedicamento = new Button();
            btnEliminarMedicamento = new Button();
            lblLeyenda = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            SuspendLayout();
            // 
            // cmbMedicamentos
            // 
            cmbMedicamentos.FormattingEnabled = true;
            cmbMedicamentos.Location = new Point(12, 25);
            cmbMedicamentos.Name = "cmbMedicamentos";
            cmbMedicamentos.Size = new Size(192, 28);
            cmbMedicamentos.TabIndex = 0;
            cmbMedicamentos.SelectedIndexChanged += cmbMedicamentos_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 2);
            label1.Name = "label1";
            label1.Size = new Size(192, 20);
            label1.TabIndex = 1;
            label1.Text = "Seleccione el Medicamento";
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Location = new Point(225, 25);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowHeadersWidth = 51;
            dgvMedicamentos.RowTemplate.Height = 29;
            dgvMedicamentos.Size = new Size(563, 113);
            dgvMedicamentos.TabIndex = 2;
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(225, 144);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowHeadersWidth = 51;
            dgvDroguerias.RowTemplate.Height = 29;
            dgvDroguerias.Size = new Size(563, 177);
            dgvDroguerias.TabIndex = 3;
            // 
            // btnModificarMedicamento
            // 
            btnModificarMedicamento.Location = new Point(12, 144);
            btnModificarMedicamento.Name = "btnModificarMedicamento";
            btnModificarMedicamento.Size = new Size(192, 84);
            btnModificarMedicamento.TabIndex = 4;
            btnModificarMedicamento.Text = "MODIFICAR";
            btnModificarMedicamento.UseVisualStyleBackColor = true;
            btnModificarMedicamento.Click += btnModificarMedicamento_Click;
            // 
            // btnEliminarMedicamento
            // 
            btnEliminarMedicamento.Location = new Point(12, 237);
            btnEliminarMedicamento.Name = "btnEliminarMedicamento";
            btnEliminarMedicamento.Size = new Size(192, 84);
            btnEliminarMedicamento.TabIndex = 5;
            btnEliminarMedicamento.Text = "ELIMINAR";
            btnEliminarMedicamento.UseVisualStyleBackColor = true;
            btnEliminarMedicamento.Click += btnEliminarMedicamento_Click;
            // 
            // lblLeyenda
            // 
            lblLeyenda.AutoSize = true;
            lblLeyenda.Location = new Point(12, 332);
            lblLeyenda.Name = "lblLeyenda";
            lblLeyenda.Size = new Size(50, 20);
            lblLeyenda.TabIndex = 6;
            lblLeyenda.Text = "label2";
            lblLeyenda.Visible = false;
            // 
            // FormMedicamentos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 361);
            Controls.Add(lblLeyenda);
            Controls.Add(btnEliminarMedicamento);
            Controls.Add(btnModificarMedicamento);
            Controls.Add(dgvDroguerias);
            Controls.Add(dgvMedicamentos);
            Controls.Add(label1);
            Controls.Add(cmbMedicamentos);
            Name = "FormMedicamentos";
            Text = "FormMedicamentos";
            Load += FormMedicamentos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMedicamentos;
        private Label label1;
        private DataGridView dgvMedicamentos;
        private DataGridView dgvDroguerias;
        private Button btnModificarMedicamento;
        private Button btnEliminarMedicamento;
        private Label lblLeyenda;
    }
}