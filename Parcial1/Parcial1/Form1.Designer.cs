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
            txtNombreComercial = new TextBox();
            label1 = new Label();
            rbVentaLibre = new RadioButton();
            label2 = new Label();
            txtPrecioVenta = new TextBox();
            txtStockMinimo = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtStockActual = new TextBox();
            btnRegistrarMedicamento = new Button();
            cmbMonodrogas = new ComboBox();
            cmbDroguerias = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            btnCargarDrogueria = new Button();
            dgvDrogueriasDelMedicamento = new DataGridView();
            lblLeyenda = new Label();
            btnVerMedicamentos = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasDelMedicamento).BeginInit();
            SuspendLayout();
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(6, 46);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(151, 27);
            txtNombreComercial.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre Comercial";
            // 
            // rbVentaLibre
            // 
            rbVentaLibre.AutoSize = true;
            rbVentaLibre.Location = new Point(6, 292);
            rbVentaLibre.Name = "rbVentaLibre";
            rbVentaLibre.Size = new Size(104, 24);
            rbVentaLibre.TabIndex = 2;
            rbVentaLibre.TabStop = true;
            rbVentaLibre.Text = "Venta Libre";
            rbVentaLibre.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 76);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 3;
            label2.Text = "Precio Venta";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(6, 99);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(151, 27);
            txtPrecioVenta.TabIndex = 4;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(6, 205);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(151, 27);
            txtStockMinimo.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 182);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 7;
            label3.Text = "Stock Minimo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 129);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 6;
            label4.Text = "Stock Actual";
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(6, 152);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(151, 27);
            txtStockActual.TabIndex = 5;
            // 
            // btnRegistrarMedicamento
            // 
            btnRegistrarMedicamento.Location = new Point(12, 348);
            btnRegistrarMedicamento.Name = "btnRegistrarMedicamento";
            btnRegistrarMedicamento.Size = new Size(162, 45);
            btnRegistrarMedicamento.TabIndex = 9;
            btnRegistrarMedicamento.Text = "REGISTRAR";
            btnRegistrarMedicamento.UseVisualStyleBackColor = true;
            btnRegistrarMedicamento.Click += btnRegistrarMedicamento_Click;
            // 
            // cmbMonodrogas
            // 
            cmbMonodrogas.FormattingEnabled = true;
            cmbMonodrogas.Location = new Point(6, 258);
            cmbMonodrogas.Name = "cmbMonodrogas";
            cmbMonodrogas.Size = new Size(151, 28);
            cmbMonodrogas.TabIndex = 10;
            // 
            // cmbDroguerias
            // 
            cmbDroguerias.FormattingEnabled = true;
            cmbDroguerias.Location = new Point(182, 45);
            cmbDroguerias.Name = "cmbDroguerias";
            cmbDroguerias.Size = new Size(162, 28);
            cmbDroguerias.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 235);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 12;
            label5.Text = "Monodroga";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(182, 23);
            label6.Name = "label6";
            label6.Size = new Size(82, 20);
            label6.TabIndex = 13;
            label6.Text = "Droguerias";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCargarDrogueria);
            groupBox1.Controls.Add(dgvDrogueriasDelMedicamento);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(rbVentaLibre);
            groupBox1.Controls.Add(txtNombreComercial);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbDroguerias);
            groupBox1.Controls.Add(txtPrecioVenta);
            groupBox1.Controls.Add(cmbMonodrogas);
            groupBox1.Controls.Add(txtStockActual);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtStockMinimo);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(673, 330);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registro Medicamento";
            // 
            // btnCargarDrogueria
            // 
            btnCargarDrogueria.Location = new Point(350, 45);
            btnCargarDrogueria.Name = "btnCargarDrogueria";
            btnCargarDrogueria.Size = new Size(162, 29);
            btnCargarDrogueria.TabIndex = 15;
            btnCargarDrogueria.Text = "CARGAR DROGUERIA";
            btnCargarDrogueria.UseVisualStyleBackColor = true;
            btnCargarDrogueria.Click += btnCargarDrogueria_Click;
            // 
            // dgvDrogueriasDelMedicamento
            // 
            dgvDrogueriasDelMedicamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasDelMedicamento.Location = new Point(182, 80);
            dgvDrogueriasDelMedicamento.Name = "dgvDrogueriasDelMedicamento";
            dgvDrogueriasDelMedicamento.RowHeadersWidth = 51;
            dgvDrogueriasDelMedicamento.RowTemplate.Height = 29;
            dgvDrogueriasDelMedicamento.Size = new Size(485, 206);
            dgvDrogueriasDelMedicamento.TabIndex = 14;
            // 
            // lblLeyenda
            // 
            lblLeyenda.AutoSize = true;
            lblLeyenda.Location = new Point(12, 409);
            lblLeyenda.Name = "lblLeyenda";
            lblLeyenda.Size = new Size(50, 20);
            lblLeyenda.TabIndex = 15;
            lblLeyenda.Text = "label7";
            lblLeyenda.Visible = false;
            // 
            // btnVerMedicamentos
            // 
            btnVerMedicamentos.Location = new Point(180, 348);
            btnVerMedicamentos.Name = "btnVerMedicamentos";
            btnVerMedicamentos.Size = new Size(162, 45);
            btnVerMedicamentos.TabIndex = 16;
            btnVerMedicamentos.Text = "VER MEDICAMENTOS";
            btnVerMedicamentos.UseVisualStyleBackColor = true;
            btnVerMedicamentos.Click += btnVerMedicamentos_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 439);
            Controls.Add(btnVerMedicamentos);
            Controls.Add(lblLeyenda);
            Controls.Add(groupBox1);
            Controls.Add(btnRegistrarMedicamento);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasDelMedicamento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreComercial;
        private Label label1;
        private RadioButton rbVentaLibre;
        private Label label2;
        private TextBox txtPrecioVenta;
        private TextBox txtStockMinimo;
        private Label label3;
        private Label label4;
        private TextBox txtStockActual;
        private Button btnRegistrarMedicamento;
        private ComboBox cmbMonodrogas;
        private ComboBox cmbDroguerias;
        private Label label5;
        private Label label6;
        private GroupBox groupBox1;
        private Button btnCargarDrogueria;
        private DataGridView dgvDrogueriasDelMedicamento;
        private Label lblLeyenda;
        private Button btnVerMedicamentos;
    }
}