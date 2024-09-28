namespace Parcial1
{
    partial class FormDrogueria
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
            groupBox1 = new GroupBox();
            btnAgregar = new Button();
            txtEmail = new TextBox();
            txtDireccion = new TextBox();
            txtRazonSocial = new TextBox();
            txtCuit = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvDrogueria = new DataGridView();
            Cuit = new DataGridViewTextBoxColumn();
            RazonSocial = new DataGridViewTextBoxColumn();
            Direccion = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueria).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(txtRazonSocial);
            groupBox1.Controls.Add(txtCuit);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(105, 29);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(288, 251);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Drogueria";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(137, 209);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 23);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(137, 164);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 7;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(137, 123);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 6;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(137, 86);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(100, 23);
            txtRazonSocial.TabIndex = 5;
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(137, 44);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(100, 23);
            txtCuit.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 172);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 131);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "Direccion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 94);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 1;
            label2.Text = "Razon Social";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 52);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 0;
            label1.Text = "Cuit";
            // 
            // dgvDrogueria
            // 
            dgvDrogueria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueria.Columns.AddRange(new DataGridViewColumn[] { Cuit, RazonSocial, Direccion, Email });
            dgvDrogueria.Location = new Point(24, 300);
            dgvDrogueria.Name = "dgvDrogueria";
            dgvDrogueria.RowTemplate.Height = 25;
            dgvDrogueria.Size = new Size(443, 150);
            dgvDrogueria.TabIndex = 1;
            // 
            // Cuit
            // 
            Cuit.DataPropertyName = "Cuit";
            Cuit.HeaderText = "Cuit";
            Cuit.Name = "Cuit";
            // 
            // RazonSocial
            // 
            RazonSocial.DataPropertyName = "RazonSocial";
            RazonSocial.HeaderText = "RazonSocial";
            RazonSocial.Name = "RazonSocial";
            // 
            // Direccion
            // 
            Direccion.DataPropertyName = "Direccion";
            Direccion.HeaderText = "Direccion";
            Direccion.Name = "Direccion";
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.Name = "Email";
            // 
            // FormDrogueria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 462);
            Controls.Add(dgvDrogueria);
            Controls.Add(groupBox1);
            Name = "FormDrogueria";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueria).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnAgregar;
        private TextBox txtEmail;
        private TextBox txtDireccion;
        private TextBox txtRazonSocial;
        private TextBox txtCuit;
        private DataGridView dgvDrogueria;
        private DataGridViewTextBoxColumn Cuit;
        private DataGridViewTextBoxColumn RazonSocial;
        private DataGridViewTextBoxColumn Direccion;
        private DataGridViewTextBoxColumn Email;
    }
}