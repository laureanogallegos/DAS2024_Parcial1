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
            label1 = new Label();
            txtNombreComercial = new TextBox();
            cmbDroguerias = new ComboBox();
            cbxVentaLibre = new CheckBox();
            cmbMonodrogas = new ComboBox();
            txtPrecioVenta = new TextBox();
            txtStock = new TextBox();
            txtStockMinimo = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnAgregarMedicamento = new Button();
            btnAgregarDrogueria = new Button();
            dgvDrogueriasMedicamento = new DataGridView();
            btnSalir = new Button();
            btnEliminarDrogueria = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasMedicamento).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 66);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre Comercial";
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(32, 84);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(121, 23);
            txtNombreComercial.TabIndex = 1;
            // 
            // cmbDroguerias
            // 
            cmbDroguerias.DisplayMember = "razonsocial";
            cmbDroguerias.FormattingEnabled = true;
            cmbDroguerias.Location = new Point(450, 12);
            cmbDroguerias.Name = "cmbDroguerias";
            cmbDroguerias.Size = new Size(121, 23);
            cmbDroguerias.TabIndex = 2;
            // 
            // cbxVentaLibre
            // 
            cbxVentaLibre.AutoSize = true;
            cbxVentaLibre.Location = new Point(124, 297);
            cbxVentaLibre.Name = "cbxVentaLibre";
            cbxVentaLibre.Size = new Size(15, 14);
            cbxVentaLibre.TabIndex = 3;
            cbxVentaLibre.UseVisualStyleBackColor = true;
            // 
            // cmbMonodrogas
            // 
            cmbMonodrogas.DisplayMember = "Nombre";
            cmbMonodrogas.FormattingEnabled = true;
            cmbMonodrogas.Location = new Point(37, 260);
            cmbMonodrogas.Name = "cmbMonodrogas";
            cmbMonodrogas.Size = new Size(121, 23);
            cmbMonodrogas.TabIndex = 4;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(35, 128);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(121, 23);
            txtPrecioVenta.TabIndex = 5;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(37, 172);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(121, 23);
            txtStock.TabIndex = 6;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(37, 216);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(121, 23);
            txtStockMinimo.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 110);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 8;
            label2.Text = "Precio Venta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(82, 154);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 9;
            label3.Text = "Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 198);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 10;
            label4.Text = "Stock Minimo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(64, 242);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 11;
            label5.Text = "Monodroga";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(53, 297);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 12;
            label6.Text = "Venta Libre";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(349, 15);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 13;
            label7.Text = "Droguerias";
            // 
            // btnAgregarMedicamento
            // 
            btnAgregarMedicamento.Location = new Point(32, 376);
            btnAgregarMedicamento.Name = "btnAgregarMedicamento";
            btnAgregarMedicamento.Size = new Size(136, 23);
            btnAgregarMedicamento.TabIndex = 14;
            btnAgregarMedicamento.Text = "Agregar Medicamento";
            btnAgregarMedicamento.UseVisualStyleBackColor = true;
            btnAgregarMedicamento.Click += btnAgregarModificarMedicamento_Click;
            // 
            // btnAgregarDrogueria
            // 
            btnAgregarDrogueria.Location = new Point(603, 15);
            btnAgregarDrogueria.Name = "btnAgregarDrogueria";
            btnAgregarDrogueria.Size = new Size(121, 23);
            btnAgregarDrogueria.TabIndex = 15;
            btnAgregarDrogueria.Text = "Agregar Drogueria";
            btnAgregarDrogueria.UseVisualStyleBackColor = true;
            btnAgregarDrogueria.Click += btnAgregarDrogueria_Click;
            // 
            // dgvDrogueriasMedicamento
            // 
            dgvDrogueriasMedicamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDrogueriasMedicamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasMedicamento.Location = new Point(204, 87);
            dgvDrogueriasMedicamento.Name = "dgvDrogueriasMedicamento";
            dgvDrogueriasMedicamento.RowTemplate.Height = 25;
            dgvDrogueriasMedicamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDrogueriasMedicamento.Size = new Size(559, 312);
            dgvDrogueriasMedicamento.TabIndex = 16;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(652, 415);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(136, 23);
            btnSalir.TabIndex = 17;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminarDrogueria
            // 
            btnEliminarDrogueria.Location = new Point(603, 44);
            btnEliminarDrogueria.Name = "btnEliminarDrogueria";
            btnEliminarDrogueria.Size = new Size(121, 23);
            btnEliminarDrogueria.TabIndex = 18;
            btnEliminarDrogueria.Text = "Eliminar Drogueria";
            btnEliminarDrogueria.UseVisualStyleBackColor = true;
            btnEliminarDrogueria.Click += btnEliminarDrogueria_Click;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminarDrogueria);
            Controls.Add(btnSalir);
            Controls.Add(dgvDrogueriasMedicamento);
            Controls.Add(btnAgregarDrogueria);
            Controls.Add(btnAgregarMedicamento);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtStockMinimo);
            Controls.Add(txtStock);
            Controls.Add(txtPrecioVenta);
            Controls.Add(cmbMonodrogas);
            Controls.Add(cbxVentaLibre);
            Controls.Add(cmbDroguerias);
            Controls.Add(txtNombreComercial);
            Controls.Add(label1);
            Name = "FormMedicamento";
            Text = "Medicamento";
            Load += FormMedicamento_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasMedicamento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombreComercial;
        private ComboBox cmbDroguerias;
        private CheckBox cbxVentaLibre;
        private ComboBox cmbMonodrogas;
        private TextBox txtPrecioVenta;
        private TextBox txtStock;
        private TextBox txtStockMinimo;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnAgregarMedicamento;
        private Button btnAgregarDrogueria;
        private DataGridView dgvDrogueriasMedicamento;
        private Button btnSalir;
        private Button btnEliminarDrogueria;
    }
}