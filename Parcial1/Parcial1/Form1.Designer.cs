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
            dgvMedicamentos = new DataGridView();
            label1 = new Label();
            dataGridView2 = new DataGridView();
            label2 = new Label();
            btnAgregar = new Button();
            button2 = new Button();
            btnEliminar = new Button();
            txtNombreCom = new TextBox();
            txtPrecio = new TextBox();
            ckbVentaLib = new CheckBox();
            txtStock = new TextBox();
            txtStockMin = new TextBox();
            cmbNombreMono = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Location = new Point(24, 25);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowTemplate.Height = 25;
            dgvMedicamentos.Size = new Size(609, 258);
            dgvMedicamentos.TabIndex = 0;
            dgvMedicamentos.CellContentClick += dgvMedicamentos_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 7);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 1;
            label1.Text = "Medicamentos";
            label1.Click += label1_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(851, 25);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(600, 258);
            dataGridView2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(863, 6);
            label2.Name = "label2";
            label2.Size = new Size(155, 15);
            label2.TabIndex = 3;
            label2.Text = "Droguerias y medicamentos";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(32, 603);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 39);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(212, 603);
            button2.Name = "button2";
            button2.Size = new Size(75, 39);
            button2.TabIndex = 5;
            button2.Text = "Modificar";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(376, 603);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 39);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += button3_Click;
            // 
            // txtNombreCom
            // 
            txtNombreCom.Location = new Point(32, 309);
            txtNombreCom.Name = "txtNombreCom";
            txtNombreCom.Size = new Size(100, 23);
            txtNombreCom.TabIndex = 7;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(32, 391);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 8;
            // 
            // ckbVentaLib
            // 
            ckbVentaLib.AutoSize = true;
            ckbVentaLib.Location = new Point(32, 354);
            ckbVentaLib.Name = "ckbVentaLib";
            ckbVentaLib.Size = new Size(84, 19);
            ckbVentaLib.TabIndex = 9;
            ckbVentaLib.Text = "Venta Libre";
            ckbVentaLib.UseVisualStyleBackColor = true;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(32, 434);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 10;
            // 
            // txtStockMin
            // 
            txtStockMin.Location = new Point(32, 481);
            txtStockMin.Name = "txtStockMin";
            txtStockMin.Size = new Size(100, 23);
            txtStockMin.TabIndex = 11;
            // 
            // cmbNombreMono
            // 
            cmbNombreMono.FormattingEnabled = true;
            cmbNombreMono.Location = new Point(32, 539);
            cmbNombreMono.Name = "cmbNombreMono";
            cmbNombreMono.Size = new Size(121, 23);
            cmbNombreMono.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(186, 311);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 14;
            label3.Text = "Nombre comercial";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(186, 391);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 15;
            label4.Text = "Precio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(186, 437);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 16;
            label5.Text = "Stock";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(186, 484);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 17;
            label6.Text = "Stock minimo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(186, 542);
            label7.Name = "label7";
            label7.Size = new Size(117, 15);
            label7.TabIndex = 18;
            label7.Text = "Nombre monodroga";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1480, 680);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbNombreMono);
            Controls.Add(txtStockMin);
            Controls.Add(txtStock);
            Controls.Add(ckbVentaLib);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombreCom);
            Controls.Add(btnEliminar);
            Controls.Add(button2);
            Controls.Add(btnAgregar);
            Controls.Add(label2);
            Controls.Add(dataGridView2);
            Controls.Add(label1);
            Controls.Add(dgvMedicamentos);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMedicamentos;
        private Label label1;
        private DataGridView dataGridView2;
        private Label label2;
        private Button btnAgregar;
        private Button button2;
        private Button btnEliminar;
        private TextBox txtNombreCom;
        private TextBox txtPrecio;
        private CheckBox ckbVentaLib;
        private TextBox txtStock;
        private TextBox txtStockMin;
        private ComboBox cmbNombreMono;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}