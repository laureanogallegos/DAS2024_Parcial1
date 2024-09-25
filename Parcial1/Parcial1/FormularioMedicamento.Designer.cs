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
            btnCargar = new Button();
            btnVolver = new Button();
            groupBox1 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            label6 = new Label();
            comboBox1 = new ComboBox();
            groupBox2 = new GroupBox();
            label5 = new Label();
            txtPrecio = new TextBox();
            label4 = new Label();
            cbMonodroga = new ComboBox();
            cbVenta = new CheckBox();
            label3 = new Label();
            txtPrecioVenta = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            txtNombre = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(278, 227);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(115, 43);
            btnCargar.TabIndex = 6;
            btnCargar.Text = "Cargar Medicamento";
            btnCargar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(417, 229);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(114, 43);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Location = new Point(399, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(399, 192);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Puntos de Ventas";
            // 
            // button4
            // 
            button4.Location = new Point(318, 161);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 20;
            button4.Text = "Eliminar";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(318, 131);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 19;
            button3.Text = "Asociar";
            button3.UseVisualStyleBackColor = true;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(74, 32);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 17;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtPrecio);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(cbMonodroga);
            groupBox2.Controls.Add(cbVenta);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtPrecioVenta);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBox1);
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
            // cbVenta
            // 
            cbVenta.AutoSize = true;
            cbVenta.Location = new Point(160, 157);
            cbVenta.Name = "cbVenta";
            cbVenta.Size = new Size(81, 19);
            cbVenta.TabIndex = 19;
            cbVenta.Text = "VentaLibre";
            cbVenta.UseVisualStyleBackColor = true;
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
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(9, 157);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(108, 23);
            txtPrecioVenta.TabIndex = 17;
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
            // textBox1
            // 
            textBox1.Location = new Point(17, 100);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 15;
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
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(306, 119);
            dataGridView1.TabIndex = 21;
            // 
            // FormularioMedicamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 284);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnVolver);
            Controls.Add(btnCargar);
            Name = "FormularioMedicamento";
            Text = "FormularioMedicamento";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnCargar;
        private Button btnVolver;
        private GroupBox groupBox1;
        private Button button4;
        private Button button3;
        private Label label6;
        private ComboBox comboBox1;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox txtPrecio;
        private Label label4;
        private ComboBox cbMonodroga;
        private CheckBox cbVenta;
        private Label label3;
        private TextBox txtPrecioVenta;
        private Label label2;
        private TextBox textBox1;
        private TextBox txtNombre;
        private Label label1;
        private DataGridView dataGridView1;
    }
}