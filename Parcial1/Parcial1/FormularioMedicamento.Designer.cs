namespace Parcial1
{
    partial class FormularioMedicamento
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
            btn_CargarMed = new Button();
            btn_Volver = new Button();
            groupBox1 = new GroupBox();
            dgv_Drogueiras = new DataGridView();
            btn_EliminarDrog = new Button();
            btn_AsociarDrog = new Button();
            label6 = new Label();
            cbDroguerias = new ComboBox();
            groupBox2 = new GroupBox();
            label5 = new Label();
            txtPrecio = new TextBox();
            label4 = new Label();
            cbMonodroga = new ComboBox();
            chkVenta = new CheckBox();
            label3 = new Label();
            txtStockMinimo = new TextBox();
            label2 = new Label();
            txtStock = new TextBox();
            txtNombre = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Drogueiras).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btn_CargarMed
            // 
            btn_CargarMed.Location = new Point(278, 227);
            btn_CargarMed.Name = "btn_CargarMed";
            btn_CargarMed.Size = new Size(115, 43);
            btn_CargarMed.TabIndex = 6;
            btn_CargarMed.Text = "Cargar Medicamento";
            btn_CargarMed.UseVisualStyleBackColor = true;
            btn_CargarMed.Click += btn_CargarMed_Click;
            // 
            // btn_Volver
            // 
            btn_Volver.Location = new Point(417, 227);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(114, 43);
            btn_Volver.TabIndex = 7;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = true;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_Drogueiras);
            groupBox1.Controls.Add(btn_EliminarDrog);
            groupBox1.Controls.Add(btn_AsociarDrog);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cbDroguerias);
            groupBox1.Location = new Point(399, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(399, 192);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Puntos de Ventas";
            // 
            // dgv_Drogueiras
            // 
            dgv_Drogueiras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Drogueiras.Location = new Point(6, 61);
            dgv_Drogueiras.Name = "dgv_Drogueiras";
            dgv_Drogueiras.RowTemplate.Height = 25;
            dgv_Drogueiras.Size = new Size(306, 119);
            dgv_Drogueiras.TabIndex = 21;
            // 
            // btn_EliminarDrog
            // 
            btn_EliminarDrog.Location = new Point(318, 161);
            btn_EliminarDrog.Name = "btn_EliminarDrog";
            btn_EliminarDrog.Size = new Size(75, 23);
            btn_EliminarDrog.TabIndex = 20;
            btn_EliminarDrog.Text = "Eliminar";
            btn_EliminarDrog.UseVisualStyleBackColor = true;
            btn_EliminarDrog.Click += btn_EliminarDrog_Click;
            // 
            // btn_AsociarDrog
            // 
            btn_AsociarDrog.Location = new Point(318, 131);
            btn_AsociarDrog.Name = "btn_AsociarDrog";
            btn_AsociarDrog.Size = new Size(75, 23);
            btn_AsociarDrog.TabIndex = 19;
            btn_AsociarDrog.Text = "Asociar";
            btn_AsociarDrog.UseVisualStyleBackColor = true;
            btn_AsociarDrog.Click += btn_AsociarDrog_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(92, 14);
            label6.Name = "label6";
            label6.Size = new Size(64, 15);
            label6.TabIndex = 18;
            label6.Text = "Droguerias";
            // 
            // cbDroguerias
            // 
            cbDroguerias.FormattingEnabled = true;
            cbDroguerias.Location = new Point(74, 32);
            cbDroguerias.Name = "cbDroguerias";
            cbDroguerias.Size = new Size(121, 23);
            cbDroguerias.TabIndex = 17;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtPrecio);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(cbMonodroga);
            groupBox2.Controls.Add(chkVenta);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtStockMinimo);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtStock);
            groupBox2.Controls.Add(txtNombre);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(381, 192);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos Medicamento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(160, 30);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 23;
            label5.Text = "Precio Venta";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(146, 48);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(108, 23);
            txtPrecio.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(160, 82);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 21;
            label4.Text = "Monodroga";
            // 
            // cbMonodroga
            // 
            cbMonodroga.FormattingEnabled = true;
            cbMonodroga.Location = new Point(146, 100);
            cbMonodroga.Name = "cbMonodroga";
            cbMonodroga.Size = new Size(121, 23);
            cbMonodroga.TabIndex = 20;
            // 
            // chkVenta
            // 
            chkVenta.AutoSize = true;
            chkVenta.Location = new Point(160, 157);
            chkVenta.Name = "chkVenta";
            chkVenta.Size = new Size(81, 19);
            chkVenta.TabIndex = 19;
            chkVenta.Text = "VentaLibre";
            chkVenta.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 139);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 18;
            label3.Text = "Stock Minimo";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(9, 157);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(108, 23);
            txtStockMinimo.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 82);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 16;
            label2.Text = "Stock Actual";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(17, 100);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 15;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(17, 44);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(108, 23);
            txtNombre.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 26);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 13;
            label1.Text = "Nombre Comercial";
            // 
            // FormularioMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 284);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btn_Volver);
            Controls.Add(btn_CargarMed);
            Name = "FormularioMedicamento";
            Text = "FormularioMedicamento";
            Load += FormularioMedicamento_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Drogueiras).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_CargarMed;
        private Button btn_Volver;
        private GroupBox groupBox1;
        private Button btn_EliminarDrog;
        private Button btn_AsociarDrog;
        private Label label6;
        private ComboBox cbDroguerias;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox txtPrecio;
        private Label label4;
        private ComboBox cbMonodroga;
        private CheckBox chkVenta;
        private Label label3;
        private TextBox txtStockMinimo;
        private Label label2;
        private TextBox txtStock;
        private TextBox txtNombre;
        private Label label1;
        private DataGridView dgv_Drogueiras;
    }
}