﻿namespace Parcial1
{
    partial class FormMonodroga
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
            label1 = new Label();
            txtNombre = new TextBox();
            btnAgregar = new Button();
            dgvMonodrogas = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvMonodrogas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 49);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(105, 41);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(105, 86);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvMonodrogas
            // 
            dgvMonodrogas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonodrogas.Columns.AddRange(new DataGridViewColumn[] { Nombre });
            dgvMonodrogas.Location = new Point(31, 135);
            dgvMonodrogas.Name = "dgvMonodrogas";
            dgvMonodrogas.RowTemplate.Height = 25;
            dgvMonodrogas.Size = new Size(240, 150);
            dgvMonodrogas.TabIndex = 3;
            // 
            // Nombre
            // 
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // FormMonodroga
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 307);
            Controls.Add(dgvMonodrogas);
            Controls.Add(btnAgregar);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "FormMonodroga";
            Text = "FormMonodroga";
            Load += FormMonodroga_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMonodrogas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Button btnAgregar;
        private DataGridView dgvMonodrogas;
        private DataGridViewTextBoxColumn Nombre;
    }
}