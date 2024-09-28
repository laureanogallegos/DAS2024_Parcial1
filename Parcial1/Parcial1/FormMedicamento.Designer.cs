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
            gbVL = new GroupBox();
            rbVLSi = new RadioButton();
            rbVLNo = new RadioButton();
            cmbMonodroga = new ComboBox();
            txtStockActual = new TextBox();
            txtStockMinimo = new TextBox();
            txtPrecioVenta = new TextBox();
            txtNombre = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnQuitarDrogueria = new Button();
            btnAgregarDrogueria = new Button();
            dgvDroguerias = new DataGridView();
            cmbDroguerias = new ComboBox();
            label7 = new Label();
            btnAgregar = new Button();
            groupBox1.SuspendLayout();
            gbVL.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(gbVL);
            groupBox1.Controls.Add(cmbMonodroga);
            groupBox1.Controls.Add(txtStockActual);
            groupBox1.Controls.Add(txtStockMinimo);
            groupBox1.Controls.Add(txtPrecioVenta);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(33, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(345, 274);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Medicamentos";
            // 
            // gbVL
            // 
            gbVL.Controls.Add(rbVLSi);
            gbVL.Controls.Add(rbVLNo);
            gbVL.Location = new Point(153, 61);
            gbVL.Name = "gbVL";
            gbVL.Size = new Size(117, 35);
            gbVL.TabIndex = 15;
            gbVL.TabStop = false;
            // 
            // rbVLSi
            // 
            rbVLSi.AutoSize = true;
            rbVLSi.Location = new Point(19, 11);
            rbVLSi.Name = "rbVLSi";
            rbVLSi.Size = new Size(34, 19);
            rbVLSi.TabIndex = 13;
            rbVLSi.TabStop = true;
            rbVLSi.Text = "Si";
            rbVLSi.UseVisualStyleBackColor = true;
            // 
            // rbVLNo
            // 
            rbVLNo.AutoSize = true;
            rbVLNo.Location = new Point(59, 11);
            rbVLNo.Name = "rbVLNo";
            rbVLNo.Size = new Size(41, 19);
            rbVLNo.TabIndex = 14;
            rbVLNo.TabStop = true;
            rbVLNo.Text = "No";
            rbVLNo.UseVisualStyleBackColor = true;
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(153, 229);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(121, 23);
            cmbMonodroga.TabIndex = 12;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(153, 185);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(100, 23);
            txtStockActual.TabIndex = 11;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(153, 147);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(100, 23);
            txtStockMinimo.TabIndex = 10;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(153, 107);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(100, 23);
            txtPrecioVenta.TabIndex = 9;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(153, 32);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 237);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 5;
            label6.Text = "Monodroga";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 193);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 4;
            label5.Text = "Stock actual";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 155);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 3;
            label4.Text = "Stock minimo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 115);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 2;
            label3.Text = "Precio venta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 77);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 1;
            label2.Text = "Venta libre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 40);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre comercial";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnQuitarDrogueria);
            groupBox2.Controls.Add(btnAgregarDrogueria);
            groupBox2.Controls.Add(dgvDroguerias);
            groupBox2.Controls.Add(cmbDroguerias);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(384, 21);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(345, 287);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Drogueria";
            // 
            // btnQuitarDrogueria
            // 
            btnQuitarDrogueria.Location = new Point(193, 250);
            btnQuitarDrogueria.Name = "btnQuitarDrogueria";
            btnQuitarDrogueria.Size = new Size(144, 23);
            btnQuitarDrogueria.TabIndex = 4;
            btnQuitarDrogueria.Text = "Quitar drogueria";
            btnQuitarDrogueria.UseVisualStyleBackColor = true;
            btnQuitarDrogueria.Click += btnQuitarDrogueria_Click;
            // 
            // btnAgregarDrogueria
            // 
            btnAgregarDrogueria.Location = new Point(28, 250);
            btnAgregarDrogueria.Name = "btnAgregarDrogueria";
            btnAgregarDrogueria.Size = new Size(144, 23);
            btnAgregarDrogueria.TabIndex = 3;
            btnAgregarDrogueria.Text = "Agregar drogueria";
            btnAgregarDrogueria.UseVisualStyleBackColor = true;
            btnAgregarDrogueria.Click += btnAgregarDrogueria_Click;
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(19, 77);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowTemplate.Height = 25;
            dgvDroguerias.Size = new Size(311, 150);
            dgvDroguerias.TabIndex = 2;
            // 
            // cmbDroguerias
            // 
            cmbDroguerias.FormattingEnabled = true;
            cmbDroguerias.Location = new Point(119, 37);
            cmbDroguerias.Name = "cmbDroguerias";
            cmbDroguerias.Size = new Size(166, 23);
            cmbDroguerias.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 45);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 0;
            label7.Text = "Seleccionar";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(347, 339);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(108, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Terminar ";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 372);
            Controls.Add(btnAgregar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormMedicamento";
            Text = "FormMedicamentos";
            Load += FormMedicamentos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbVL.ResumeLayout(false);
            gbVL.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label5;
        private Label label4;
        private TextBox txtStockActual;
        private TextBox txtStockMinimo;
        private TextBox txtPrecioVenta;
        private TextBox txtNombre;
        private Label label6;
        private ComboBox cmbMonodroga;
        private GroupBox groupBox2;
        private Button btnQuitarDrogueria;
        private Button btnAgregarDrogueria;
        private DataGridView dgvDroguerias;
        private ComboBox cmbDroguerias;
        private Label label7;
        private Button btnAgregar;
        private RadioButton rbVLNo;
        private RadioButton rbVLSi;
        private GroupBox gbVL;
    }
}