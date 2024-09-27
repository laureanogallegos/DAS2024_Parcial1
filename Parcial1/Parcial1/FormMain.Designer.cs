namespace Parcial1
{
    partial class FormMain
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
            chkEsVentaLibre = new CheckBox();
            cmbMonodroga = new ComboBox();
            txtStockMinimo = new TextBox();
            txtStockActual = new TextBox();
            txtPrecioDeVenta = new TextBox();
            txtNombreComercial = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbDrogueria = new ComboBox();
            label7 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // chkEsVentaLibre
            // 
            chkEsVentaLibre.AutoSize = true;
            chkEsVentaLibre.Location = new Point(269, 88);
            chkEsVentaLibre.Name = "chkEsVentaLibre";
            chkEsVentaLibre.Size = new Size(18, 17);
            chkEsVentaLibre.TabIndex = 14;
            chkEsVentaLibre.UseVisualStyleBackColor = true;
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(230, 264);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(136, 28);
            cmbMonodroga.TabIndex = 12;
            cmbMonodroga.SelectedIndexChanged += cmbMonodroga_SelectedIndexChanged;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(231, 219);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(135, 27);
            txtStockMinimo.TabIndex = 11;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(231, 132);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(135, 27);
            txtStockActual.TabIndex = 10;
            // 
            // txtPrecioDeVenta
            // 
            txtPrecioDeVenta.Location = new Point(231, 177);
            txtPrecioDeVenta.Name = "txtPrecioDeVenta";
            txtPrecioDeVenta.Size = new Size(135, 27);
            txtPrecioDeVenta.TabIndex = 9;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(231, 47);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(135, 27);
            txtNombreComercial.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 267);
            label6.Name = "label6";
            label6.Size = new Size(91, 20);
            label6.TabIndex = 5;
            label6.Text = "Monodroga:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 219);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 4;
            label5.Text = "Stock mínimo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 132);
            label4.Name = "label4";
            label4.Size = new Size(92, 20);
            label4.TabIndex = 3;
            label4.Text = "Stock actual:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 177);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 2;
            label3.Text = "Precio de venta:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 88);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 1;
            label2.Text = "Es venta libre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 53);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre comercial:";
            // 
            // cmbDrogueria
            // 
            cmbDrogueria.FormattingEnabled = true;
            cmbDrogueria.Location = new Point(230, 313);
            cmbDrogueria.Name = "cmbDrogueria";
            cmbDrogueria.Size = new Size(144, 28);
            cmbDrogueria.TabIndex = 16;
            cmbDrogueria.SelectedIndexChanged += cmbDrogueria_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 316);
            label7.Name = "label7";
            label7.Size = new Size(79, 20);
            label7.TabIndex = 15;
            label7.Text = "Droguería:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(231, 367);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(99, 31);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(22, 367);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(117, 31);
            btnAceptar.TabIndex = 17;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click_1;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 479);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cmbDrogueria);
            Controls.Add(label7);
            Controls.Add(chkEsVentaLibre);
            Controls.Add(txtStockActual);
            Controls.Add(txtPrecioDeVenta);
            Controls.Add(label4);
            Controls.Add(cmbMonodroga);
            Controls.Add(label3);
            Controls.Add(txtNombreComercial);
            Controls.Add(txtStockMinimo);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMain";
            Text = "FormMain";
            Load += FormMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox chkEsVentaLibre;
        private ComboBox cmbMonodroga;
        private TextBox txtStockMinimo;
        private TextBox txtStockActual;
        private TextBox txtPrecioDeVenta;
        private TextBox txtNombreComercial;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbDrogueria;
        private Label label7;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}