namespace Parcial1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvMedicamentos = new DataGridView();
            dgvDroguerias = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            SuspendLayout();
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Location = new Point(30, 32);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowTemplate.Height = 25;
            dgvMedicamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicamentos.Size = new Size(709, 155);
            dgvMedicamentos.TabIndex = 0;
            dgvMedicamentos.CellClick += dgvMedicamentos_CellClick;
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(30, 231);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowTemplate.Height = 25;
            dgvDroguerias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDroguerias.Size = new Size(709, 143);
            dgvDroguerias.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(365, 9);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 3;
            label1.Text = "Medicamentos";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(331, 202);
            label2.Name = "label2";
            label2.Size = new Size(160, 15);
            label2.TabIndex = 4;
            label2.Text = "Droguerias del Medicamento";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(767, 108);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(131, 38);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(767, 165);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(131, 38);
            btnModificar.TabIndex = 6;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(767, 225);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(131, 38);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(767, 333);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(131, 38);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 419);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvDroguerias);
            Controls.Add(dgvMedicamentos);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMedicamentos;
        private DataGridView dgvDroguerias;
        private Label label1;
        private Label label2;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnSalir;
    }
}