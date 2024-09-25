namespace Pruebavista
{
    partial class FormDatosMedicamentos
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
            txtNombreComercial = new TextBox();
            txtPrecioVenta = new TextBox();
            txtStockMinimo = new TextBox();
            txtStock = new TextBox();
            chkVentaLibre = new CheckBox();
            cmbMonodroga = new ComboBox();
            cmbDrogueria = new ComboBox();
            btnAgregarDrogueria = new Button();
            dgvAgregarDrogueria = new DataGridView();
            btnAgregarMedicamento = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnEliminarDrogueria = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAgregarDrogueria).BeginInit();
            SuspendLayout();
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(188, 102);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(100, 23);
            txtNombreComercial.TabIndex = 0;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(188, 141);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(100, 23);
            txtPrecioVenta.TabIndex = 1;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(188, 191);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(100, 23);
            txtStockMinimo.TabIndex = 2;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(188, 245);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 3;
            // 
            // chkVentaLibre
            // 
            chkVentaLibre.AutoSize = true;
            chkVentaLibre.Location = new Point(304, 312);
            chkVentaLibre.Name = "chkVentaLibre";
            chkVentaLibre.Size = new Size(81, 19);
            chkVentaLibre.TabIndex = 4;
            chkVentaLibre.Text = "VentaLibre";
            chkVentaLibre.UseVisualStyleBackColor = true;
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(188, 308);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(100, 23);
            cmbMonodroga.TabIndex = 5;
            // 
            // cmbDrogueria
            // 
            cmbDrogueria.FormattingEnabled = true;
            cmbDrogueria.Location = new Point(507, 26);
            cmbDrogueria.Name = "cmbDrogueria";
            cmbDrogueria.Size = new Size(100, 23);
            cmbDrogueria.TabIndex = 6;
            // 
            // btnAgregarDrogueria
            // 
            btnAgregarDrogueria.Location = new Point(507, 73);
            btnAgregarDrogueria.Name = "btnAgregarDrogueria";
            btnAgregarDrogueria.Size = new Size(140, 23);
            btnAgregarDrogueria.TabIndex = 7;
            btnAgregarDrogueria.Text = "Agregar Drogueria";
            btnAgregarDrogueria.UseVisualStyleBackColor = true;
            btnAgregarDrogueria.Click += btnAgregarDrogueria_Click;
            // 
            // dgvAgregarDrogueria
            // 
            dgvAgregarDrogueria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAgregarDrogueria.Location = new Point(507, 131);
            dgvAgregarDrogueria.Name = "dgvAgregarDrogueria";
            dgvAgregarDrogueria.Size = new Size(190, 92);
            dgvAgregarDrogueria.TabIndex = 8;
            // 
            // btnAgregarMedicamento
            // 
            btnAgregarMedicamento.Location = new Point(116, 347);
            btnAgregarMedicamento.Name = "btnAgregarMedicamento";
            btnAgregarMedicamento.Size = new Size(181, 23);
            btnAgregarMedicamento.TabIndex = 9;
            btnAgregarMedicamento.Text = "Aceptar Medicamento";
            btnAgregarMedicamento.UseVisualStyleBackColor = true;
            btnAgregarMedicamento.Click += btnAgregarMedicamento_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 110);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 10;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 149);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 11;
            label2.Text = "Precio Venta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 194);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 12;
            label3.Text = "Stock Minimo";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 248);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 13;
            label4.Text = "Stock Minimo";
            // 
            // btnEliminarDrogueria
            // 
            btnEliminarDrogueria.Location = new Point(507, 102);
            btnEliminarDrogueria.Name = "btnEliminarDrogueria";
            btnEliminarDrogueria.Size = new Size(140, 23);
            btnEliminarDrogueria.TabIndex = 14;
            btnEliminarDrogueria.Text = "Eliminar Drogueria";
            btnEliminarDrogueria.UseVisualStyleBackColor = true;
            btnEliminarDrogueria.Click += btnEliminarDrogueria_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(57, 308);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 15;
            label5.Text = "Monodroga";
            // 
            // FormDatosMedicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(btnEliminarDrogueria);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAgregarMedicamento);
            Controls.Add(dgvAgregarDrogueria);
            Controls.Add(btnAgregarDrogueria);
            Controls.Add(cmbDrogueria);
            Controls.Add(cmbMonodroga);
            Controls.Add(chkVentaLibre);
            Controls.Add(txtStock);
            Controls.Add(txtStockMinimo);
            Controls.Add(txtPrecioVenta);
            Controls.Add(txtNombreComercial);
            Name = "FormDatosMedicamentos";
            Text = "FormDatosMedicamentos";
            Load += FormDatosMedicamentos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAgregarDrogueria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreComercial;
        private TextBox txtPrecioVenta;
        private TextBox txtStockMinimo;
        private TextBox txtStock;
        private CheckBox chkVentaLibre;
        private ComboBox cmbMonodroga;
        private ComboBox cmbDrogueria;
        private Button btnAgregarDrogueria;
        private DataGridView dgvAgregarDrogueria;
        private Button btnAgregarMedicamento;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnEliminarDrogueria;
        private Label label5;
    }
}