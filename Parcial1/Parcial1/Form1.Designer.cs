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
            groupBox1 = new GroupBox();
            dgvMedicamentos = new DataGridView();
            btnEliminar = new Button();
            btnAgregar = new Button();
            btnModificar = new Button();
            groupBox2 = new GroupBox();
            cmbDrogueria = new ComboBox();
            cmbMonodroga = new ComboBox();
            txtStockMinimo = new TextBox();
            txtStockActual = new TextBox();
            txtPrecioDeVenta = new TextBox();
            txtNombreComercial = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            chkEsVentaLibre = new CheckBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvMedicamentos);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(993, 562);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Medicamentos";
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Location = new Point(6, 26);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowHeadersWidth = 51;
            dgvMedicamentos.RowTemplate.Height = 29;
            dgvMedicamentos.Size = new Size(981, 530);
            dgvMedicamentos.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(12, 610);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(222, 65);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(1011, 610);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(189, 65);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(1235, 610);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(185, 65);
            btnModificar.TabIndex = 6;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkEsVentaLibre);
            groupBox2.Controls.Add(cmbDrogueria);
            groupBox2.Controls.Add(cmbMonodroga);
            groupBox2.Controls.Add(txtStockMinimo);
            groupBox2.Controls.Add(txtStockActual);
            groupBox2.Controls.Add(txtPrecioDeVenta);
            groupBox2.Controls.Add(txtNombreComercial);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(1011, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(409, 562);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Agregar o modificar";
            // 
            // cmbDrogueria
            // 
            cmbDrogueria.FormattingEnabled = true;
            cmbDrogueria.Location = new Point(258, 501);
            cmbDrogueria.Name = "cmbDrogueria";
            cmbDrogueria.Size = new Size(136, 28);
            cmbDrogueria.TabIndex = 13;
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(258, 421);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(136, 28);
            cmbMonodroga.TabIndex = 12;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(259, 342);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(135, 27);
            txtStockMinimo.TabIndex = 11;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(259, 268);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(135, 27);
            txtStockActual.TabIndex = 10;
            // 
            // txtPrecioDeVenta
            // 
            txtPrecioDeVenta.Location = new Point(259, 192);
            txtPrecioDeVenta.Name = "txtPrecioDeVenta";
            txtPrecioDeVenta.Size = new Size(135, 27);
            txtPrecioDeVenta.TabIndex = 9;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(259, 51);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(135, 27);
            txtNombreComercial.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 504);
            label7.Name = "label7";
            label7.Size = new Size(79, 20);
            label7.TabIndex = 6;
            label7.Text = "Droguería:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 424);
            label6.Name = "label6";
            label6.Size = new Size(91, 20);
            label6.TabIndex = 5;
            label6.Text = "Monodroga:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 345);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 4;
            label5.Text = "Stock mínimo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 271);
            label4.Name = "label4";
            label4.Size = new Size(92, 20);
            label4.TabIndex = 3;
            label4.Text = "Stock actual:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 195);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 2;
            label3.Text = "Precio de venta:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 124);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 1;
            label2.Text = "Es venta libre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 54);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre comercial:";
            // 
            // chkEsVentaLibre
            // 
            chkEsVentaLibre.AutoSize = true;
            chkEsVentaLibre.Location = new Point(259, 124);
            chkEsVentaLibre.Name = "chkEsVentaLibre";
            chkEsVentaLibre.Size = new Size(18, 17);
            chkEsVentaLibre.TabIndex = 14;
            chkEsVentaLibre.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 712);
            Controls.Add(groupBox2);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnEliminar;
        private Button btnAgregar;
        private Button btnModificar;
        private GroupBox groupBox2;
        private DataGridView dgvMedicamentos;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label7;
        private Label label6;
        private ComboBox cmbDrogueria;
        private ComboBox cmbMonodroga;
        private TextBox txtStockMinimo;
        private TextBox txtStockActual;
        private TextBox txtPrecioDeVenta;
        private TextBox txtNombreComercial;
        private CheckBox chkEsVentaLibre;
    }
}