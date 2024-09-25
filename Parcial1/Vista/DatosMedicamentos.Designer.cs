namespace Vista
{
    partial class DatosMedicamentos
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
            txtNombre = new TextBox();
            txtPrecioVenta = new TextBox();
            txtStockActual = new TextBox();
            txtStockMinimo = new TextBox();
            cmbMonodroga = new ComboBox();
            cmbDrogueria = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            chkVentaLibre = new CheckBox();
            label5 = new Label();
            label6 = new Label();
            BtnAgregar = new Button();
            btnCerrar = new Button();
            btnDrogueria = new Button();
            dgvDrogueria = new DataGridView();
            btnEliminarDrogueria = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueria).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(145, 29);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(182, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(145, 76);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(182, 23);
            txtPrecioVenta.TabIndex = 1;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(145, 128);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(182, 23);
            txtStockActual.TabIndex = 2;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(506, 26);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(182, 23);
            txtStockMinimo.TabIndex = 3;
            // 
            // cmbMonodroga
            // 
            cmbMonodroga.FormattingEnabled = true;
            cmbMonodroga.Location = new Point(506, 82);
            cmbMonodroga.Name = "cmbMonodroga";
            cmbMonodroga.Size = new Size(182, 23);
            cmbMonodroga.TabIndex = 5;
            // 
            // cmbDrogueria
            // 
            cmbDrogueria.FormattingEnabled = true;
            cmbDrogueria.Location = new Point(145, 200);
            cmbDrogueria.Name = "cmbDrogueria";
            cmbDrogueria.Size = new Size(182, 23);
            cmbDrogueria.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 32);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 7;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 79);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 8;
            label2.Text = "Precio VENTA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 131);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 9;
            label3.Text = "Stock Actual";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(411, 29);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 10;
            label4.Text = "Stock Minima";
            // 
            // chkVentaLibre
            // 
            chkVentaLibre.AutoSize = true;
            chkVentaLibre.Location = new Point(506, 132);
            chkVentaLibre.Name = "chkVentaLibre";
            chkVentaLibre.Size = new Size(84, 19);
            chkVentaLibre.TabIndex = 11;
            chkVentaLibre.Text = "Venta Libre";
            chkVentaLibre.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(411, 85);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 12;
            label5.Text = "Monodroga";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(55, 200);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 13;
            label6.Text = "Drogueria";
            // 
            // BtnAgregar
            // 
            BtnAgregar.Location = new Point(599, 389);
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.Size = new Size(94, 49);
            BtnAgregar.TabIndex = 14;
            BtnAgregar.Text = "Agregar";
            BtnAgregar.UseVisualStyleBackColor = true;
            BtnAgregar.Click += BtnAgregar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(713, 415);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 15;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnDrogueria
            // 
            btnDrogueria.Location = new Point(145, 229);
            btnDrogueria.Name = "btnDrogueria";
            btnDrogueria.Size = new Size(182, 26);
            btnDrogueria.TabIndex = 16;
            btnDrogueria.Text = "Agregar Drogueria";
            btnDrogueria.UseVisualStyleBackColor = true;
            btnDrogueria.Click += btnDrogueria_Click;
            // 
            // dgvDrogueria
            // 
            dgvDrogueria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueria.Location = new Point(145, 293);
            dgvDrogueria.Name = "dgvDrogueria";
            dgvDrogueria.Size = new Size(182, 102);
            dgvDrogueria.TabIndex = 17;
            // 
            // btnEliminarDrogueria
            // 
            btnEliminarDrogueria.Location = new Point(145, 261);
            btnEliminarDrogueria.Name = "btnEliminarDrogueria";
            btnEliminarDrogueria.Size = new Size(182, 26);
            btnEliminarDrogueria.TabIndex = 18;
            btnEliminarDrogueria.Text = "Eliminar";
            btnEliminarDrogueria.UseVisualStyleBackColor = true;
            // 
            // DatosMedicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminarDrogueria);
            Controls.Add(dgvDrogueria);
            Controls.Add(btnDrogueria);
            Controls.Add(btnCerrar);
            Controls.Add(BtnAgregar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(chkVentaLibre);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbDrogueria);
            Controls.Add(cmbMonodroga);
            Controls.Add(txtStockMinimo);
            Controls.Add(txtStockActual);
            Controls.Add(txtPrecioVenta);
            Controls.Add(txtNombre);
            Name = "DatosMedicamentos";
            Text = "DatosMedicamentos";
            Load += DatosMedicamentos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDrogueria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtPrecioVenta;
        private TextBox txtStockActual;
        private TextBox txtStockMinimo;
        private ComboBox cmbMonodroga;
        private ComboBox cmbDrogueria;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox chkVentaLibre;
        private Label label5;
        private Label label6;
        private Button BtnAgregar;
        private Button btnCerrar;
        private Button btnDrogueria;
        private DataGridView dgvDrogueria;
        private Button btnEliminarDrogueria;
    }
}