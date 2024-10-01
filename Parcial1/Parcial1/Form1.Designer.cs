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
            btnListar = new Button();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            dgvLista = new DataGridView();
            txtNombreComercial = new TextBox();
            txtPrecioVenta = new MaskedTextBox();
            txtStockMinimo = new MaskedTextBox();
            gbVentaLibre = new GroupBox();
            rbSi = new RadioButton();
            rbNo = new RadioButton();
            cmbDrogueria = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtStock = new MaskedTextBox();
            cmbMonodroga = new ComboBox();
            label6 = new Label();
            gbMedicamento = new GroupBox();
            groupBox2 = new GroupBox();
            dgvDroguerias = new DataGridView();
            btnDrogueria = new Button();
            cmbProveedor4 = new ComboBox();
            cmbProveedor3 = new ComboBox();
            cmbProveedor2 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            gbVentaLibre.SuspendLayout();
            gbMedicamento.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            SuspendLayout();
            // 
            // btnListar
            // 
            btnListar.Location = new Point(27, 27);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(174, 77);
            btnListar.TabIndex = 0;
            btnListar.Text = "LISTAR";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(27, 110);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(174, 77);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(27, 193);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(174, 77);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "MODIFiCAR";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(27, 276);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(174, 77);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvLista
            // 
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Location = new Point(235, 27);
            dgvLista.Name = "dgvLista";
            dgvLista.RowTemplate.Height = 25;
            dgvLista.Size = new Size(565, 150);
            dgvLista.TabIndex = 4;
            dgvLista.RowHeaderMouseClick += dgvLista_RowHeaderMouseClick;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(366, 193);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(121, 23);
            txtNombreComercial.TabIndex = 5;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(366, 217);
            txtPrecioVenta.Mask = "99999";
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(121, 23);
            txtPrecioVenta.TabIndex = 6;
            txtPrecioVenta.ValidatingType = typeof(int);
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(366, 235);
            txtStockMinimo.Mask = "99999";
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(121, 23);
            txtStockMinimo.TabIndex = 7;
            txtStockMinimo.ValidatingType = typeof(int);
            // 
            // gbVentaLibre
            // 
            gbVentaLibre.Controls.Add(rbSi);
            gbVentaLibre.Controls.Add(rbNo);
            gbVentaLibre.Location = new Point(235, 320);
            gbVentaLibre.Name = "gbVentaLibre";
            gbVentaLibre.Size = new Size(200, 52);
            gbVentaLibre.TabIndex = 8;
            gbVentaLibre.TabStop = false;
            gbVentaLibre.Text = "es de venta libre?";
            // 
            // rbSi
            // 
            rbSi.AutoSize = true;
            rbSi.Checked = true;
            rbSi.Location = new Point(20, 18);
            rbSi.Name = "rbSi";
            rbSi.Size = new Size(33, 19);
            rbSi.TabIndex = 9;
            rbSi.TabStop = true;
            rbSi.Text = "si";
            rbSi.UseVisualStyleBackColor = true;
            // 
            // rbNo
            // 
            rbNo.AutoSize = true;
            rbNo.Location = new Point(126, 18);
            rbNo.Name = "rbNo";
            rbNo.Size = new Size(39, 19);
            rbNo.TabIndex = 10;
            rbNo.Text = "no";
            rbNo.UseVisualStyleBackColor = true;
            // 
            // cmbDrogueria
            // 
            cmbDrogueria.FormattingEnabled = true;
            cmbDrogueria.Items.AddRange(new object[] { "" });
            cmbDrogueria.Location = new Point(86, 16);
            cmbDrogueria.Name = "cmbDrogueria";
            cmbDrogueria.Size = new Size(121, 23);
            cmbDrogueria.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(235, 201);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 12;
            label1.Text = "NOMBRE COMERCIAL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(235, 220);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 13;
            label2.Text = "PRECIO DE VENTA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(235, 243);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 14;
            label3.Text = "STOCK MINIMO";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(235, 263);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 15;
            label4.Text = "STOCK";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 19);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 16;
            label5.Text = "Drogueria";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(366, 255);
            txtStock.Mask = "99999";
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(121, 23);
            txtStock.TabIndex = 17;
            txtStock.ValidatingType = typeof(int);
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(366, 299);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(121, 23);
            cmbMonodroga.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(235, 302);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 19;
            label6.Text = "MONODROGA";
            // 
            // gbMedicamento
            // 
            gbMedicamento.Controls.Add(groupBox2);
            gbMedicamento.Location = new Point(226, 183);
            gbMedicamento.Name = "gbMedicamento";
            gbMedicamento.Size = new Size(574, 200);
            gbMedicamento.TabIndex = 20;
            gbMedicamento.TabStop = false;
            gbMedicamento.Text = "Nuevo Medicamento";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvDroguerias);
            groupBox2.Controls.Add(btnDrogueria);
            groupBox2.Controls.Add(cmbDrogueria);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(292, 13);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(276, 181);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Droguerias";
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(6, 72);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowTemplate.Height = 25;
            dgvDroguerias.Size = new Size(270, 103);
            dgvDroguerias.TabIndex = 24;
            // 
            // btnDrogueria
            // 
            btnDrogueria.Location = new Point(28, 43);
            btnDrogueria.Name = "btnDrogueria";
            btnDrogueria.Size = new Size(75, 23);
            btnDrogueria.TabIndex = 23;
            btnDrogueria.Text = "agregar Drogueria";
            btnDrogueria.UseVisualStyleBackColor = true;
            btnDrogueria.Click += btnDrogueria_Click;
            // 
            // cmbProveedor4
            // 
            cmbProveedor4.FormattingEnabled = true;
            cmbProveedor4.Location = new Point(827, 93);
            cmbProveedor4.Name = "cmbProveedor4";
            cmbProveedor4.Size = new Size(121, 23);
            cmbProveedor4.TabIndex = 21;
            // 
            // cmbProveedor3
            // 
            cmbProveedor3.FormattingEnabled = true;
            cmbProveedor3.Location = new Point(827, 70);
            cmbProveedor3.Name = "cmbProveedor3";
            cmbProveedor3.Size = new Size(121, 23);
            cmbProveedor3.TabIndex = 19;
            // 
            // cmbProveedor2
            // 
            cmbProveedor2.FormattingEnabled = true;
            cmbProveedor2.Location = new Point(827, 50);
            cmbProveedor2.Name = "cmbProveedor2";
            cmbProveedor2.Size = new Size(121, 23);
            cmbProveedor2.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 376);
            Controls.Add(label6);
            Controls.Add(cmbMonodroga);
            Controls.Add(cmbProveedor4);
            Controls.Add(txtStock);
            Controls.Add(label4);
            Controls.Add(cmbProveedor3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbProveedor2);
            Controls.Add(label1);
            Controls.Add(gbVentaLibre);
            Controls.Add(txtStockMinimo);
            Controls.Add(txtPrecioVenta);
            Controls.Add(txtNombreComercial);
            Controls.Add(dgvLista);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(btnListar);
            Controls.Add(gbMedicamento);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            gbVentaLibre.ResumeLayout(false);
            gbVentaLibre.PerformLayout();
            gbMedicamento.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListar;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private DataGridView dgvLista;
        private TextBox txtNombreComercial;
        private MaskedTextBox txtPrecioVenta;
        private MaskedTextBox txtStockMinimo;
        private GroupBox gbVentaLibre;
        private RadioButton rbSi;
        private RadioButton rbNo;
        private ComboBox cmbDrogueria;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private MaskedTextBox txtStock;
        private ComboBox cmbMonodroga;
        private Label label6;
        private GroupBox gbMedicamento;
        private GroupBox groupBox2;
        private ComboBox cmbProveedor4;
        private ComboBox cmbProveedor3;
        private ComboBox cmbProveedor2;
        private DataGridView dgvDroguerias;
        private Button btnDrogueria;
    }
}