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
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            label1 = new Label();
            dgvDroguerias = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            SuspendLayout();
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Location = new Point(12, 38);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowTemplate.Height = 25;
            dgvMedicamentos.Size = new Size(479, 150);
            dgvMedicamentos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 194);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 43);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(202, 194);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 43);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(397, 194);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 43);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(416, 425);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(166, 15);
            label1.TabIndex = 5;
            label1.Text = "Medicamentos de la farmacia:";
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(12, 269);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowTemplate.Height = 25;
            dgvDroguerias.Size = new Size(479, 150);
            dgvDroguerias.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 251);
            label2.Name = "label2";
            label2.Size = new Size(163, 15);
            label2.TabIndex = 7;
            label2.Text = "Droguerias del medicamento:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 460);
            Controls.Add(label2);
            Controls.Add(dgvDroguerias);
            Controls.Add(label1);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
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
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnSalir;
        private Label label1;
        private DataGridView dgvDroguerias;
        private Label label2;
    }
}