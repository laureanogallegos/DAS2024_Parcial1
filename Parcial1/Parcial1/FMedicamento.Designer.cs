namespace Parcial1
{
    partial class FMedicamento
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtNombreComercial = new TextBox();
            txtPrecioVenta = new TextBox();
            txtStockActual = new TextBox();
            txtStockMinimo = new TextBox();
            cbMonodrogas = new ComboBox();
            label8 = new Label();
            cbDroguerias = new ComboBox();
            dgvDroguerias = new DataGridView();
            btnQuitarDrogueria = new Button();
            btnAceptar = new Button();
            btnCancelar = new Button();
            btnAgregarDrogueria = new Button();
            cbVentaLibre = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(210, 38);
            label1.TabIndex = 0;
            label1.Text = "Medicamentos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 70);
            label2.Name = "label2";
            label2.Size = new Size(165, 25);
            label2.TabIndex = 1;
            label2.Text = "Nombre Comercial:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 118);
            label3.Name = "label3";
            label3.Size = new Size(112, 25);
            label3.TabIndex = 2;
            label3.Text = "Monodroga:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 167);
            label4.Name = "label4";
            label4.Size = new Size(0, 25);
            label4.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 217);
            label5.Name = "label5";
            label5.Size = new Size(113, 25);
            label5.TabIndex = 4;
            label5.Text = "Precio Venta:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 267);
            label6.Name = "label6";
            label6.Size = new Size(113, 25);
            label6.TabIndex = 5;
            label6.Text = "Stock Actual:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 322);
            label7.Name = "label7";
            label7.Size = new Size(125, 25);
            label7.TabIndex = 6;
            label7.Text = "Stock Mínimo:";
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(186, 67);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(230, 31);
            txtNombreComercial.TabIndex = 0;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(186, 214);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(230, 31);
            txtPrecioVenta.TabIndex = 3;
            txtPrecioVenta.KeyPress += txtPrecioVenta_KeyPress;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(186, 264);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(230, 31);
            txtStockActual.TabIndex = 4;
            txtStockActual.KeyPress += txtStockActual_KeyPress;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(186, 319);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(230, 31);
            txtStockMinimo.TabIndex = 5;
            txtStockMinimo.KeyPress += txtStockMinimo_KeyPress;
            // 
            // cbMonodrogas
            // 
            cbMonodrogas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMonodrogas.FormattingEnabled = true;
            cbMonodrogas.Location = new Point(186, 115);
            cbMonodrogas.Name = "cbMonodrogas";
            cbMonodrogas.Size = new Size(230, 33);
            cbMonodrogas.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 374);
            label8.Name = "label8";
            label8.Size = new Size(95, 25);
            label8.TabIndex = 13;
            label8.Text = "Droguería:";
            // 
            // cbDroguerias
            // 
            cbDroguerias.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDroguerias.FormattingEnabled = true;
            cbDroguerias.Location = new Point(186, 371);
            cbDroguerias.Name = "cbDroguerias";
            cbDroguerias.Size = new Size(157, 33);
            cbDroguerias.TabIndex = 6;
            // 
            // dgvDroguerias
            // 
            dgvDroguerias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDroguerias.Location = new Point(21, 421);
            dgvDroguerias.Name = "dgvDroguerias";
            dgvDroguerias.RowHeadersWidth = 62;
            dgvDroguerias.RowTemplate.Height = 33;
            dgvDroguerias.Size = new Size(500, 281);
            dgvDroguerias.TabIndex = 15;
            // 
            // btnQuitarDrogueria
            // 
            btnQuitarDrogueria.Location = new Point(186, 708);
            btnQuitarDrogueria.Name = "btnQuitarDrogueria";
            btnQuitarDrogueria.Size = new Size(161, 46);
            btnQuitarDrogueria.TabIndex = 8;
            btnQuitarDrogueria.Text = "Quitar Droguería";
            btnQuitarDrogueria.UseVisualStyleBackColor = true;
            btnQuitarDrogueria.Click += btnQuitarDrogueria_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(118, 804);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(132, 49);
            btnAceptar.TabIndex = 9;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(284, 804);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(132, 49);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAgregarDrogueria
            // 
            btnAgregarDrogueria.Location = new Point(349, 371);
            btnAgregarDrogueria.Name = "btnAgregarDrogueria";
            btnAgregarDrogueria.Size = new Size(172, 34);
            btnAgregarDrogueria.TabIndex = 7;
            btnAgregarDrogueria.Text = "Agregar Droguería";
            btnAgregarDrogueria.UseVisualStyleBackColor = true;
            btnAgregarDrogueria.Click += btnAgregarDrogueria_Click;
            // 
            // cbVentaLibre
            // 
            cbVentaLibre.AutoSize = true;
            cbVentaLibre.Location = new Point(186, 167);
            cbVentaLibre.Name = "cbVentaLibre";
            cbVentaLibre.Size = new Size(125, 29);
            cbVentaLibre.TabIndex = 2;
            cbVentaLibre.Text = "Venta Libre";
            cbVentaLibre.UseVisualStyleBackColor = true;
            // 
            // FMedicamento
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 872);
            Controls.Add(cbVentaLibre);
            Controls.Add(btnAgregarDrogueria);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(btnQuitarDrogueria);
            Controls.Add(dgvDroguerias);
            Controls.Add(cbDroguerias);
            Controls.Add(label8);
            Controls.Add(cbMonodrogas);
            Controls.Add(txtStockMinimo);
            Controls.Add(txtStockActual);
            Controls.Add(txtPrecioVenta);
            Controls.Add(txtNombreComercial);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FMedicamento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Medicamento";
            Load += FMedicamento_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDroguerias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtNombreComercial;
        private TextBox txtPrecioVenta;
        private TextBox txtStockActual;
        private TextBox txtStockMinimo;
        private ComboBox cbMonodrogas;
        private Label label8;
        private ComboBox cbDroguerias;
        private DataGridView dgvDroguerias;
        private Button btnQuitarDrogueria;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnAgregarDrogueria;
        private CheckBox cbVentaLibre;
    }
}