namespace Parcial1
{
    partial class FormMedicamento
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
            btnModificar = new Button();
            btnBorrar = new Button();
            btnAgregar = new Button();
            clbDroguerias = new CheckedListBox();
            label2 = new Label();
            label1 = new Label();
            cBMonodroga = new ComboBox();
            cbVentaLibre = new CheckBox();
            lblStockMinimo = new Label();
            tbStockMinimo = new TextBox();
            lblStock = new Label();
            tbStock = new TextBox();
            lblPrecioVenta = new Label();
            tbPrecioVenta = new TextBox();
            lblNombreComercial = new Label();
            tbNombreComercial = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(btnBorrar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(clbDroguerias);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cBMonodroga);
            groupBox1.Controls.Add(cbVentaLibre);
            groupBox1.Controls.Add(lblStockMinimo);
            groupBox1.Controls.Add(tbStockMinimo);
            groupBox1.Controls.Add(lblStock);
            groupBox1.Controls.Add(tbStock);
            groupBox1.Controls.Add(lblPrecioVenta);
            groupBox1.Controls.Add(tbPrecioVenta);
            groupBox1.Controls.Add(lblNombreComercial);
            groupBox1.Controls.Add(tbNombreComercial);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(447, 337);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "gbMedicamento";
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(185, 280);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(84, 39);
            btnModificar.TabIndex = 16;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(339, 280);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(84, 39);
            btnBorrar.TabIndex = 15;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(37, 280);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(84, 39);
            btnAgregar.TabIndex = 14;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // clbDroguerias
            // 
            clbDroguerias.FormattingEnabled = true;
            clbDroguerias.Location = new Point(236, 171);
            clbDroguerias.Name = "clbDroguerias";
            clbDroguerias.Size = new Size(187, 94);
            clbDroguerias.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 144);
            label2.Name = "label2";
            label2.Size = new Size(130, 15);
            label2.TabIndex = 12;
            label2.Text = "Drogueria que lo vende";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(236, 88);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 10;
            label1.Text = "Monodroga";
            // 
            // cBMonodroga
            // 
            cBMonodroga.FormattingEnabled = true;
            cBMonodroga.Location = new Point(236, 106);
            cBMonodroga.Name = "cBMonodroga";
            cBMonodroga.Size = new Size(121, 23);
            cBMonodroga.TabIndex = 9;
            // 
            // cbVentaLibre
            // 
            cbVentaLibre.AutoSize = true;
            cbVentaLibre.Location = new Point(236, 55);
            cbVentaLibre.Name = "cbVentaLibre";
            cbVentaLibre.Size = new Size(103, 19);
            cbVentaLibre.TabIndex = 8;
            cbVentaLibre.Text = "Es Venta Libre?";
            cbVentaLibre.UseVisualStyleBackColor = true;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Location = new Point(40, 194);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(81, 15);
            lblStockMinimo.TabIndex = 7;
            lblStockMinimo.Text = "Stock Minimo";
            // 
            // tbStockMinimo
            // 
            tbStockMinimo.Location = new Point(38, 214);
            tbStockMinimo.Name = "tbStockMinimo";
            tbStockMinimo.Size = new Size(135, 23);
            tbStockMinimo.TabIndex = 6;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(40, 142);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(36, 15);
            lblStock.TabIndex = 5;
            lblStock.Text = "Stock";
            // 
            // tbStock
            // 
            tbStock.Location = new Point(38, 162);
            tbStock.Name = "tbStock";
            tbStock.Size = new Size(135, 23);
            tbStock.TabIndex = 4;
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Location = new Point(40, 86);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(88, 15);
            lblPrecioVenta.TabIndex = 3;
            lblPrecioVenta.Text = "Precio de Venta";
            // 
            // tbPrecioVenta
            // 
            tbPrecioVenta.Location = new Point(38, 106);
            tbPrecioVenta.Name = "tbPrecioVenta";
            tbPrecioVenta.Size = new Size(135, 23);
            tbPrecioVenta.TabIndex = 2;
            // 
            // lblNombreComercial
            // 
            lblNombreComercial.AutoSize = true;
            lblNombreComercial.Location = new Point(40, 31);
            lblNombreComercial.Name = "lblNombreComercial";
            lblNombreComercial.Size = new Size(108, 15);
            lblNombreComercial.TabIndex = 1;
            lblNombreComercial.Text = "Nombre Comercial";
            // 
            // tbNombreComercial
            // 
            tbNombreComercial.Location = new Point(38, 51);
            tbNombreComercial.Name = "tbNombreComercial";
            tbNombreComercial.Size = new Size(135, 23);
            tbNombreComercial.TabIndex = 0;
            // 
            // FormMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "FormMedicamento";
            Text = "FormMedicamentos";
            Load += FormMedicamento_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbNombreComercial;
        private Label lblStock;
        private TextBox tbStock;
        private Label lblPrecioVenta;
        private TextBox tbPrecioVenta;
        private Label lblNombreComercial;
        private Label lblStockMinimo;
        private TextBox tbStockMinimo;
        private ComboBox cBMonodroga;
        private CheckBox cbVentaLibre;
        private Label label1;
        private CheckedListBox clbDroguerias;
        private Label label2;
        private Button btnModificar;
        private Button btnBorrar;
        private Button btnAgregar;
    }
}