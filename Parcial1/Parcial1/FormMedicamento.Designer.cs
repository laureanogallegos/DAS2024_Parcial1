namespace Parcial1
{
    partial class FormMedicamento
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
            label8 = new Label();
            cmbDrogueria = new ComboBox();
            label7 = new Label();
            cmbMonodroga = new ComboBox();
            label3 = new Label();
            txtNomb = new TextBox();
            txtTipo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            txtPrecio = new TextBox();
            txtStockActual = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtStokMin = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(354, 162);
            label8.Name = "label8";
            label8.Size = new Size(59, 15);
            label8.TabIndex = 28;
            label8.Text = "Drogueria";
            // 
            // cmbDrogueria
            // 
            cmbDrogueria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDrogueria.FormattingEnabled = true;
            cmbDrogueria.Location = new Point(447, 158);
            cmbDrogueria.Name = "cmbDrogueria";
            cmbDrogueria.Size = new Size(149, 23);
            cmbDrogueria.TabIndex = 27;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(34, 158);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 26;
            label7.Text = "Monodroga";
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(129, 154);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(149, 23);
            cmbMonodroga.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 78);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 24;
            label3.Text = "Precio:";
            // 
            // txtNomb
            // 
            txtNomb.Location = new Point(169, 24);
            txtNomb.MaxLength = 15;
            txtNomb.Name = "txtNomb";
            txtNomb.Size = new Size(149, 23);
            txtNomb.TabIndex = 20;
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(447, 29);
            txtTipo.MaxLength = 150;
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(151, 23);
            txtTipo.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 32);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 22;
            label1.Text = "Nombre Comercial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(350, 33);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 23;
            label2.Text = "Tipo Venta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(350, 78);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 29;
            label4.Text = "Stock Actual:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(169, 70);
            txtPrecio.MaxLength = 15;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(149, 23);
            txtPrecio.TabIndex = 30;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(449, 75);
            txtStockActual.MaxLength = 15;
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(149, 23);
            txtStockActual.TabIndex = 31;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(106, 192);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(96, 37);
            btnAceptar.TabIndex = 32;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(466, 212);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 42);
            btnCancelar.TabIndex = 33;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtStokMin
            // 
            txtStokMin.Location = new Point(169, 115);
            txtStokMin.MaxLength = 15;
            txtStokMin.Name = "txtStokMin";
            txtStokMin.Size = new Size(149, 23);
            txtStokMin.TabIndex = 35;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 123);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 34;
            label5.Text = "Stock Minimo:";
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 332);
            Controls.Add(txtStokMin);
            Controls.Add(label5);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtStockActual);
            Controls.Add(txtPrecio);
            Controls.Add(label4);
            Controls.Add(label8);
            Controls.Add(cmbDrogueria);
            Controls.Add(label7);
            Controls.Add(cmbMonodroga);
            Controls.Add(label3);
            Controls.Add(txtNomb);
            Controls.Add(txtTipo);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "FormMedicamento";
            Text = "FormMedicamento";
            Load += FormMedicamento_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label8;
        private ComboBox cmbDrogueria;
        private Label label7;
        private ComboBox cmbMonodroga;
        private Label label3;
        private TextBox txtNomb;
        private TextBox txtTipo;
        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox txtPrecio;
        private TextBox txtStockActual;
        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtStokMin;
        private Label label5;
    }
}