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
            groupBox1 = new GroupBox();
            lblDroguerias = new Label();
            clbDroguerias = new CheckedListBox();
            btnMedicamento = new Button();
            lblMonodroga = new Label();
            cbMonodroga = new ComboBox();
            lblStockMinimo = new Label();
            lblStockActual = new Label();
            txtStockMinimo = new MaskedTextBox();
            txtStockActual = new MaskedTextBox();
            cbVentaLibre = new CheckBox();
            lblPrecioVenta = new Label();
            txtPrecioVenta = new MaskedTextBox();
            lblNombreComercial = new Label();
            txtNombreComercial = new TextBox();
            cbMedicamentoOpciones = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblDroguerias);
            groupBox1.Controls.Add(clbDroguerias);
            groupBox1.Controls.Add(btnMedicamento);
            groupBox1.Controls.Add(lblMonodroga);
            groupBox1.Controls.Add(cbMonodroga);
            groupBox1.Controls.Add(lblStockMinimo);
            groupBox1.Controls.Add(lblStockActual);
            groupBox1.Controls.Add(txtStockMinimo);
            groupBox1.Controls.Add(txtStockActual);
            groupBox1.Controls.Add(cbVentaLibre);
            groupBox1.Controls.Add(lblPrecioVenta);
            groupBox1.Controls.Add(txtPrecioVenta);
            groupBox1.Controls.Add(lblNombreComercial);
            groupBox1.Controls.Add(txtNombreComercial);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(12, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(204, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "gbMedicamento";
            // 
            // lblDroguerias
            // 
            lblDroguerias.AutoSize = true;
            lblDroguerias.Location = new Point(6, 315);
            lblDroguerias.Name = "lblDroguerias";
            lblDroguerias.Size = new Size(64, 15);
            lblDroguerias.TabIndex = 11;
            lblDroguerias.Text = "Droguerias";
            // 
            // clbDroguerias
            // 
            clbDroguerias.FormattingEnabled = true;
            clbDroguerias.Location = new Point(6, 333);
            clbDroguerias.Name = "clbDroguerias";
            clbDroguerias.Size = new Size(185, 58);
            clbDroguerias.TabIndex = 1;
            clbDroguerias.SelectedIndexChanged += clbDroguerias_SelectedIndexChanged;
            // 
            // btnMedicamento
            // 
            btnMedicamento.BackColor = SystemColors.ActiveCaption;
            btnMedicamento.Location = new Point(6, 397);
            btnMedicamento.Name = "btnMedicamento";
            btnMedicamento.Size = new Size(185, 23);
            btnMedicamento.TabIndex = 10;
            btnMedicamento.Text = "AGREGAR";
            btnMedicamento.UseVisualStyleBackColor = false;
            btnMedicamento.Click += btnMedicamento_Click;
            // 
            // lblMonodroga
            // 
            lblMonodroga.AutoSize = true;
            lblMonodroga.Location = new Point(6, 251);
            lblMonodroga.Name = "lblMonodroga";
            lblMonodroga.Size = new Size(70, 15);
            lblMonodroga.TabIndex = 9;
            lblMonodroga.Text = "Monodroga";
            // 
            // cbMonodroga
            // 
            cbMonodroga.FormattingEnabled = true;
            cbMonodroga.Location = new Point(6, 269);
            cbMonodroga.Name = "cbMonodroga";
            cbMonodroga.Size = new Size(185, 23);
            cbMonodroga.TabIndex = 9;
            cbMonodroga.SelectedIndexChanged += cbMonodroga_SelectedIndexChanged;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Location = new Point(6, 190);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(81, 15);
            lblStockMinimo.TabIndex = 8;
            lblStockMinimo.Text = "Stock Minimo";
            // 
            // lblStockActual
            // 
            lblStockActual.AutoSize = true;
            lblStockActual.Location = new Point(6, 136);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(73, 15);
            lblStockActual.TabIndex = 6;
            lblStockActual.Text = "Stock Actual";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(6, 208);
            txtStockMinimo.Mask = "99999";
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(185, 23);
            txtStockMinimo.TabIndex = 7;
            txtStockMinimo.ValidatingType = typeof(int);
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(6, 154);
            txtStockActual.Mask = "99999";
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(185, 23);
            txtStockActual.TabIndex = 5;
            txtStockActual.ValidatingType = typeof(int);
            // 
            // cbVentaLibre
            // 
            cbVentaLibre.AutoSize = true;
            cbVentaLibre.Location = new Point(96, 97);
            cbVentaLibre.Name = "cbVentaLibre";
            cbVentaLibre.Size = new Size(95, 19);
            cbVentaLibre.TabIndex = 4;
            cbVentaLibre.Text = "Es venta libre";
            cbVentaLibre.UseVisualStyleBackColor = true;
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Location = new Point(6, 77);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(72, 15);
            lblPrecioVenta.TabIndex = 3;
            lblPrecioVenta.Text = "Precio venta";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(6, 95);
            txtPrecioVenta.Mask = "999.99";
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(72, 23);
            txtPrecioVenta.TabIndex = 2;
            // 
            // lblNombreComercial
            // 
            lblNombreComercial.AutoSize = true;
            lblNombreComercial.Location = new Point(6, 30);
            lblNombreComercial.Name = "lblNombreComercial";
            lblNombreComercial.Size = new Size(106, 15);
            lblNombreComercial.TabIndex = 1;
            lblNombreComercial.Text = "Nombre comercial";
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(6, 48);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(185, 23);
            txtNombreComercial.TabIndex = 0;
            // 
            // cbMedicamentoOpciones
            // 
            cbMedicamentoOpciones.FormattingEnabled = true;
            cbMedicamentoOpciones.Items.AddRange(new object[] { "AGREGAR", "MODIFICAR", "ELIMINAR" });
            cbMedicamentoOpciones.Location = new Point(18, 24);
            cbMedicamentoOpciones.Name = "cbMedicamentoOpciones";
            cbMedicamentoOpciones.Size = new Size(185, 23);
            cbMedicamentoOpciones.TabIndex = 1;
            cbMedicamentoOpciones.SelectedIndexChanged += cbMedicamentoOpciones_SelectedIndexChanged;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 648);
            Controls.Add(cbMedicamentoOpciones);
            Controls.Add(groupBox1);
            Name = "FormMedicamento";
            Text = "FormMedicamento";
            Load += FormMedicamento_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblNombreComercial;
        private TextBox txtNombreComercial;
        private Label lblMonodroga;
        private ComboBox cbMonodroga;
        private Label lblStockMinimo;
        private Label lblStockActual;
        private MaskedTextBox txtStockMinimo;
        private MaskedTextBox txtStockActual;
        private CheckBox cbVentaLibre;
        private Label lblPrecioVenta;
        private MaskedTextBox txtPrecioVenta;
        private Label lblDroguerias;
        private CheckedListBox clbDroguerias;
        private Button btnMedicamento;
        private ComboBox cbMedicamentoOpciones;
    }
}