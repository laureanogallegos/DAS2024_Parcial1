namespace Pruebavista
{
    partial class Form1
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
            dgvMedicamentos = new DataGridView();
            btnAgregar = new Button();
            button2 = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            SuspendLayout();
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Location = new Point(126, 26);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.Size = new Size(552, 150);
            dgvMedicamentos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(163, 273);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(365, 273);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "modificar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(527, 273);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(button2);
            Controls.Add(btnAgregar);
            Controls.Add(dgvMedicamentos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMedicamentos;
        private Button btnAgregar;
        private Button button2;
        private Button btnEliminar;
    }
}