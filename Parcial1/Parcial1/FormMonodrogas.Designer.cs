namespace Parcial1
{
    partial class FormMonodrogas
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
            dgvMonodroga = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMonodroga).BeginInit();
            SuspendLayout();
            // 
            // dgvMonodroga
            // 
            dgvMonodroga.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonodroga.Columns.AddRange(new DataGridViewColumn[] { Nombre });
            dgvMonodroga.Location = new Point(92, 30);
            dgvMonodroga.Name = "dgvMonodroga";
            dgvMonodroga.RowTemplate.Height = 25;
            dgvMonodroga.Size = new Size(240, 150);
            dgvMonodroga.TabIndex = 0;
            // 
            // Nombre
            // 
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(40, 207);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(82, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(174, 207);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(83, 23);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(307, 207);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(81, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FormMonodrogas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 242);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvMonodroga);
            Name = "FormMonodrogas";
            Text = "FormMonodrogas";
            Load += FormMonodrogas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMonodroga).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMonodroga;
        private DataGridViewTextBoxColumn Nombre;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
    }
}