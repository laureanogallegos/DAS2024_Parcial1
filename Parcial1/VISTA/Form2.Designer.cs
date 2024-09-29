namespace VISTA
{
    partial class Form2
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
            lblNombreComercial = new Label();
            lblVentaLibre = new Label();
            lblPrecioVenta = new Label();
            lblStockActual = new Label();
            lblStockMinimo = new Label();
            lblMonodroga = new Label();
            txtNombreComercial = new TextBox();
            txtVentaLibre = new TextBox();
            txtPrecioVenta = new TextBox();
            txtStockActual = new TextBox();
            txtStockMinimo = new TextBox();
            txtMonodroga = new TextBox();
            btnAgregarMedicamento = new Button();
            dgvDrogueria = new DataGridView();
            gbMedicamento = new GroupBox();
            btnAgregarDrogueria = new Button();
            btnEliminarDrogueria = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueria).BeginInit();
            gbMedicamento.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombreComercial
            // 
            lblNombreComercial.AutoSize = true;
            lblNombreComercial.Location = new Point(23, 35);
            lblNombreComercial.Name = "lblNombreComercial";
            lblNombreComercial.Size = new Size(135, 20);
            lblNombreComercial.TabIndex = 0;
            lblNombreComercial.Text = "Nombre Comercial";
            // 
            // lblVentaLibre
            // 
            lblVentaLibre.AutoSize = true;
            lblVentaLibre.Location = new Point(23, 83);
            lblVentaLibre.Name = "lblVentaLibre";
            lblVentaLibre.Size = new Size(83, 20);
            lblVentaLibre.TabIndex = 1;
            lblVentaLibre.Text = "Venta Libre";
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Location = new Point(23, 134);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(91, 20);
            lblPrecioVenta.TabIndex = 2;
            lblPrecioVenta.Text = "Precio Venta";
            // 
            // lblStockActual
            // 
            lblStockActual.AutoSize = true;
            lblStockActual.Location = new Point(23, 189);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(91, 20);
            lblStockActual.TabIndex = 3;
            lblStockActual.Text = "Stock Actual";
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Location = new Point(23, 244);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(100, 20);
            lblStockMinimo.TabIndex = 4;
            lblStockMinimo.Text = "Stock Minimo";
            // 
            // lblMonodroga
            // 
            lblMonodroga.AutoSize = true;
            lblMonodroga.Location = new Point(23, 298);
            lblMonodroga.Name = "lblMonodroga";
            lblMonodroga.Size = new Size(88, 20);
            lblMonodroga.TabIndex = 5;
            lblMonodroga.Text = "Monodroga";
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(168, 28);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(125, 27);
            txtNombreComercial.TabIndex = 6;
            // 
            // txtVentaLibre
            // 
            txtVentaLibre.Location = new Point(168, 76);
            txtVentaLibre.Name = "txtVentaLibre";
            txtVentaLibre.Size = new Size(125, 27);
            txtVentaLibre.TabIndex = 7;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(168, 127);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(125, 27);
            txtPrecioVenta.TabIndex = 8;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(168, 182);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(125, 27);
            txtStockActual.TabIndex = 9;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(168, 237);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(125, 27);
            txtStockMinimo.TabIndex = 10;
            // 
            // txtMonodroga
            // 
            txtMonodroga.Location = new Point(168, 295);
            txtMonodroga.Name = "txtMonodroga";
            txtMonodroga.Size = new Size(125, 27);
            txtMonodroga.TabIndex = 11;
            // 
            // btnAgregarMedicamento
            // 
            btnAgregarMedicamento.Location = new Point(61, 341);
            btnAgregarMedicamento.Name = "btnAgregarMedicamento";
            btnAgregarMedicamento.Size = new Size(189, 29);
            btnAgregarMedicamento.TabIndex = 12;
            btnAgregarMedicamento.Text = "Agregar Medicamento";
            btnAgregarMedicamento.UseVisualStyleBackColor = true;
            // 
            // dgvDrogueria
            // 
            dgvDrogueria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueria.Location = new Point(391, 76);
            dgvDrogueria.Name = "dgvDrogueria";
            dgvDrogueria.RowHeadersWidth = 51;
            dgvDrogueria.Size = new Size(488, 242);
            dgvDrogueria.TabIndex = 13;
            // 
            // gbMedicamento
            // 
            gbMedicamento.Controls.Add(btnEliminarDrogueria);
            gbMedicamento.Controls.Add(btnAgregarDrogueria);
            gbMedicamento.Controls.Add(txtStockMinimo);
            gbMedicamento.Controls.Add(dgvDrogueria);
            gbMedicamento.Controls.Add(lblNombreComercial);
            gbMedicamento.Controls.Add(btnAgregarMedicamento);
            gbMedicamento.Controls.Add(lblVentaLibre);
            gbMedicamento.Controls.Add(txtMonodroga);
            gbMedicamento.Controls.Add(lblPrecioVenta);
            gbMedicamento.Controls.Add(lblStockActual);
            gbMedicamento.Controls.Add(txtStockActual);
            gbMedicamento.Controls.Add(lblStockMinimo);
            gbMedicamento.Controls.Add(txtPrecioVenta);
            gbMedicamento.Controls.Add(lblMonodroga);
            gbMedicamento.Controls.Add(txtVentaLibre);
            gbMedicamento.Controls.Add(txtNombreComercial);
            gbMedicamento.Location = new Point(55, 32);
            gbMedicamento.Name = "gbMedicamento";
            gbMedicamento.Size = new Size(915, 504);
            gbMedicamento.TabIndex = 14;
            gbMedicamento.TabStop = false;
            gbMedicamento.Text = "Medicamento";
            // 
            // btnAgregarDrogueria
            // 
            btnAgregarDrogueria.Location = new Point(391, 341);
            btnAgregarDrogueria.Name = "btnAgregarDrogueria";
            btnAgregarDrogueria.Size = new Size(213, 29);
            btnAgregarDrogueria.TabIndex = 14;
            btnAgregarDrogueria.Text = "Agregar Drogueria";
            btnAgregarDrogueria.UseVisualStyleBackColor = true;
            // 
            // btnEliminarDrogueria
            // 
            btnEliminarDrogueria.Location = new Point(683, 341);
            btnEliminarDrogueria.Name = "btnEliminarDrogueria";
            btnEliminarDrogueria.Size = new Size(196, 29);
            btnEliminarDrogueria.TabIndex = 15;
            btnEliminarDrogueria.Text = "Eliminar Drogueria";
            btnEliminarDrogueria.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 550);
            Controls.Add(gbMedicamento);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dgvDrogueria).EndInit();
            gbMedicamento.ResumeLayout(false);
            gbMedicamento.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNombreComercial;
        private Label lblVentaLibre;
        private Label lblPrecioVenta;
        private Label lblStockActual;
        private Label lblStockMinimo;
        private Label lblMonodroga;
        private TextBox txtNombreComercial;
        private TextBox txtVentaLibre;
        private TextBox txtPrecioVenta;
        private TextBox txtStockActual;
        private TextBox txtStockMinimo;
        private TextBox txtMonodroga;
        private Button btnAgregarMedicamento;
        private DataGridView dgvDrogueria;
        private GroupBox gbMedicamento;
        private Button btnEliminarDrogueria;
        private Button btnAgregarDrogueria;
    }
}