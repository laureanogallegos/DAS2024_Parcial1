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
            label7 = new Label();
            chBoxVentaLibre = new CheckBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnEliminarDrogueria = new Button();
            btnAgregarDrogueria = new Button();
            btnSalir = new Button();
            btnAceptar = new Button();
            dgvDroguerias = new DataGridView();
            cmbDrogueria = new ComboBox();
            cmbMonodroga = new ComboBox();
            txtStockMinimo = new TextBox();
            txtStock = new TextBox();
            txtPrecioVenta = new TextBox();
            txtNombreComercial = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(chBoxVentaLibre);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnEliminarDrogueria);
            groupBox1.Controls.Add(btnAgregarDrogueria);
            groupBox1.Controls.Add(btnSalir);
            groupBox1.Controls.Add(btnAceptar);
            groupBox1.Controls.Add(dgvDroguerias);
            groupBox1.Controls.Add(cmbDrogueria);
            groupBox1.Controls.Add(cmbMonodroga);
            groupBox1.Controls.Add(txtStockMinimo);
            groupBox1.Controls.Add(txtStock);
            groupBox1.Controls.Add(txtPrecioVenta);
            groupBox1.Controls.Add(txtNombreComercial);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(699, 306);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Medicamento:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 194);
            label7.Name = "label7";
            label7.Size = new Size(68, 15);
            label7.TabIndex = 18;
            label7.Text = "Venta Libre:";
            // 
            // chBoxVentaLibre
            // 
            chBoxVentaLibre.AutoSize = true;
            chBoxVentaLibre.Location = new Point(193, 194);
            chBoxVentaLibre.Name = "chBoxVentaLibre";
            chBoxVentaLibre.Size = new Size(15, 14);
            chBoxVentaLibre.TabIndex = 17;
            chBoxVentaLibre.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(363, 30);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 16;
            label6.Text = "Drogueria:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 239);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 15;
            label5.Text = "Monodroga:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 157);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 14;
            label4.Text = "Stock Minimo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 112);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 13;
            label3.Text = "Stock Actual:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 71);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 12;
            label2.Text = "Precio Venta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 30);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 11;
            label1.Text = "Nombre Comercial:";
            // 
            // btnEliminarDrogueria
            // 
            btnEliminarDrogueria.Location = new Point(595, 51);
            btnEliminarDrogueria.Name = "btnEliminarDrogueria";
            btnEliminarDrogueria.Size = new Size(75, 55);
            btnEliminarDrogueria.TabIndex = 10;
            btnEliminarDrogueria.Text = "Eliminar Drogueria";
            btnEliminarDrogueria.UseVisualStyleBackColor = true;
            btnEliminarDrogueria.Click += btnEliminarDrogueria_Click;
            // 
            // btnAgregarDrogueria
            // 
            btnAgregarDrogueria.Location = new Point(430, 51);
            btnAgregarDrogueria.Name = "btnAgregarDrogueria";
            btnAgregarDrogueria.Size = new Size(75, 55);
            btnAgregarDrogueria.TabIndex = 9;
            btnAgregarDrogueria.Text = "Agregar Drogueria";
            btnAgregarDrogueria.UseVisualStyleBackColor = true;
            btnAgregarDrogueria.Click += btnAgregarDrogueria_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(595, 277);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(6, 277);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(306, 112);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowTemplate.Height = 25;
            dgvDroguerias.Size = new Size(364, 150);
            dgvDroguerias.TabIndex = 6;
            // 
            // cmbDrogueria
            // 
            cmbDrogueria.FormattingEnabled = true;
            cmbDrogueria.Location = new Point(430, 22);
            cmbDrogueria.Name = "cmbDrogueria";
            cmbDrogueria.Size = new Size(240, 23);
            cmbDrogueria.TabIndex = 5;
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(137, 231);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(131, 23);
            cmbMonodroga.TabIndex = 4;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(137, 149);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(131, 23);
            txtStockMinimo.TabIndex = 3;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(137, 104);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(131, 23);
            txtStock.TabIndex = 2;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(137, 63);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(131, 23);
            txtPrecioVenta.TabIndex = 1;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(137, 22);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(131, 23);
            txtNombreComercial.TabIndex = 0;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 342);
            Controls.Add(groupBox1);
            Name = "FormMedicamento";
            Text = "FormMedicamento";
            Load += FormMedicamento_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnEliminarDrogueria;
        private Button btnAgregarDrogueria;
        private Button btnSalir;
        private Button btnAceptar;
        private DataGridView dgvDroguerias;
        private ComboBox cmbDrogueria;
        private ComboBox cmbMonodroga;
        private TextBox txtStockMinimo;
        private TextBox txtStock;
        private TextBox txtPrecioVenta;
        private TextBox txtNombreComercial;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private CheckBox chBoxVentaLibre;
    }
}