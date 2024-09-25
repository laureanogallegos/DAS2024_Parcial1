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
            dataGridView1 = new DataGridView();
            Agregar = new Button();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            checkBox1 = new CheckBox();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(403, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(385, 312);
            dataGridView1.TabIndex = 0;
            // 
            // Agregar
            // 
            Agregar.Location = new Point(12, 335);
            Agregar.Name = "Agregar";
            Agregar.Size = new Size(144, 38);
            Agregar.TabIndex = 1;
            Agregar.Text = "Agregar";
            Agregar.UseVisualStyleBackColor = true;
            Agregar.Click += Agregar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(181, 335);
            button1.Name = "button1";
            button1.Size = new Size(105, 38);
            button1.TabIndex = 2;
            button1.Text = "Modificar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(309, 335);
            button2.Name = "button2";
            button2.Size = new Size(83, 38);
            button2.TabIndex = 3;
            button2.Text = "Eliminar";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(111, 23);
            textBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 47);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 5;
            label1.Text = "Nombre";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(141, 68);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 6;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 68);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 7;
            label2.Text = "Venta libre";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(141, 88);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 96);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 9;
            label3.Text = "Precio venta";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(141, 129);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 10;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(141, 170);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 23);
            numericUpDown3.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 131);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 12;
            label4.Text = "Stock";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 172);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 13;
            label5.Text = "Stock minimo";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(141, 210);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(58, 213);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 15;
            label6.Text = "Monodroga";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Agregar);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button Agregar;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private CheckBox checkBox1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private Label label6;
    }
}