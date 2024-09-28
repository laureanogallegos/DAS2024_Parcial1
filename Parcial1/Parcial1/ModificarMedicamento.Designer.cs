namespace Parcial1
{
    partial class ModificarMedicamento
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
            rbVentaLibre = new RadioButton();
            txtNombreComercial = new TextBox();
            label5 = new Label();
            label2 = new Label();
            txtPrecioVenta = new TextBox();
            cmbMonodrogas = new ComboBox();
            txtStockActual = new TextBox();
            label4 = new Label();
            txtStockMinimo = new TextBox();
            label3 = new Label();
            btnModificar = new Button();
            lblLeyenda = new Label();
            btnEliminarDrogueria = new Button();
            btnCargarDrogueria = new Button();
            dgvDrogueriasDelMedicamento = new DataGridView();
            label6 = new Label();
            cmbDroguerias = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasDelMedicamento).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 14;
            label1.Text = "Nombre Comercial";
            // 
            // rbVentaLibre
            // 
            rbVentaLibre.AutoSize = true;
            rbVentaLibre.Location = new Point(12, 278);
            rbVentaLibre.Name = "rbVentaLibre";
            rbVentaLibre.Size = new Size(104, 24);
            rbVentaLibre.TabIndex = 15;
            rbVentaLibre.TabStop = true;
            rbVentaLibre.Text = "Venta Libre";
            rbVentaLibre.UseVisualStyleBackColor = true;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(12, 32);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(218, 27);
            txtNombreComercial.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 221);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 23;
            label5.Text = "Monodroga";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 16;
            label2.Text = "Precio Venta";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(12, 85);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(218, 27);
            txtPrecioVenta.TabIndex = 17;
            // 
            // cmbMonodrogas
            // 
            cmbMonodrogas.FormattingEnabled = true;
            cmbMonodrogas.Location = new Point(12, 244);
            cmbMonodrogas.Name = "cmbMonodrogas";
            cmbMonodrogas.Size = new Size(218, 28);
            cmbMonodrogas.TabIndex = 22;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(12, 138);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(218, 27);
            txtStockActual.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 115);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 19;
            label4.Text = "Stock Actual";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(12, 191);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(218, 27);
            txtStockMinimo.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 168);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 20;
            label3.Text = "Stock Minimo";
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(12, 308);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(218, 54);
            btnModificar.TabIndex = 24;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // lblLeyenda
            // 
            lblLeyenda.AutoSize = true;
            lblLeyenda.Location = new Point(12, 366);
            lblLeyenda.Name = "lblLeyenda";
            lblLeyenda.Size = new Size(50, 20);
            lblLeyenda.TabIndex = 25;
            lblLeyenda.Text = "label6";
            lblLeyenda.Visible = false;
            // 
            // btnEliminarDrogueria
            // 
            btnEliminarDrogueria.Location = new Point(428, 281);
            btnEliminarDrogueria.Name = "btnEliminarDrogueria";
            btnEliminarDrogueria.Size = new Size(175, 30);
            btnEliminarDrogueria.TabIndex = 30;
            btnEliminarDrogueria.Text = "ELIMINAR DROGUERIA";
            btnEliminarDrogueria.UseVisualStyleBackColor = true;
            btnEliminarDrogueria.Click += btnEliminarDrogueria_Click;
            // 
            // btnCargarDrogueria
            // 
            btnCargarDrogueria.Location = new Point(247, 281);
            btnCargarDrogueria.Name = "btnCargarDrogueria";
            btnCargarDrogueria.Size = new Size(175, 30);
            btnCargarDrogueria.TabIndex = 29;
            btnCargarDrogueria.Text = "CARGAR DROGUERIA";
            btnCargarDrogueria.UseVisualStyleBackColor = true;
            btnCargarDrogueria.Click += btnCargarDrogueria_Click;
            // 
            // dgvDrogueriasDelMedicamento
            // 
            dgvDrogueriasDelMedicamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasDelMedicamento.Location = new Point(247, 67);
            dgvDrogueriasDelMedicamento.Name = "dgvDrogueriasDelMedicamento";
            dgvDrogueriasDelMedicamento.RowHeadersWidth = 51;
            dgvDrogueriasDelMedicamento.RowTemplate.Height = 29;
            dgvDrogueriasDelMedicamento.Size = new Size(485, 206);
            dgvDrogueriasDelMedicamento.TabIndex = 28;
            dgvDrogueriasDelMedicamento.CellClick += dgvDrogueriasDelMedicamento_CellClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(247, 10);
            label6.Name = "label6";
            label6.Size = new Size(82, 20);
            label6.TabIndex = 27;
            label6.Text = "Droguerias";
            // 
            // cmbDroguerias
            // 
            cmbDroguerias.FormattingEnabled = true;
            cmbDroguerias.Location = new Point(247, 32);
            cmbDroguerias.Name = "cmbDroguerias";
            cmbDroguerias.Size = new Size(162, 28);
            cmbDroguerias.TabIndex = 26;
            // 
            // ModificarMedicamento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 395);
            Controls.Add(btnEliminarDrogueria);
            Controls.Add(btnCargarDrogueria);
            Controls.Add(dgvDrogueriasDelMedicamento);
            Controls.Add(label6);
            Controls.Add(cmbDroguerias);
            Controls.Add(lblLeyenda);
            Controls.Add(btnModificar);
            Controls.Add(label1);
            Controls.Add(rbVentaLibre);
            Controls.Add(txtNombreComercial);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(txtPrecioVenta);
            Controls.Add(cmbMonodrogas);
            Controls.Add(txtStockActual);
            Controls.Add(label4);
            Controls.Add(txtStockMinimo);
            Controls.Add(label3);
            Name = "ModificarMedicamento";
            Text = "Modificar";
            Load += ModificarMedicamento_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasDelMedicamento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton rbVentaLibre;
        private TextBox txtNombreComercial;
        private Label label5;
        private Label label2;
        private TextBox txtPrecioVenta;
        private ComboBox cmbMonodrogas;
        private TextBox txtStockActual;
        private Label label4;
        private TextBox txtStockMinimo;
        private Label label3;
        private Button btnModificar;
        private Label lblLeyenda;
        private Button btnEliminarDrogueria;
        private Button btnCargarDrogueria;
        private DataGridView dgvDrogueriasDelMedicamento;
        private Label label6;
        private ComboBox cmbDroguerias;
    }
}