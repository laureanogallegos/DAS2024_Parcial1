namespace Parcial1
{
    partial class AgregarMedicamentos
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
            btnAgregar = new Button();
            btnAgregarDrog = new Button();
            btnEliminarDroguerias = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dgvDrogueriasMedicamento = new DataGridView();
            cBoxDroguerias = new ComboBox();
            cBoxMonodrogas = new ComboBox();
            txtNombreComercial = new TextBox();
            txtPrecioDeVenta = new TextBox();
            txtStock = new TextBox();
            txtStockMinimo = new TextBox();
            cBoxVentaLibre = new CheckBox();
            btnModifMedicamento = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasMedicamento).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(250, 126);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(89, 41);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar Medicamento";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnAgregarDrog
            // 
            btnAgregarDrog.Location = new Point(250, 79);
            btnAgregarDrog.Name = "btnAgregarDrog";
            btnAgregarDrog.Size = new Size(89, 41);
            btnAgregarDrog.TabIndex = 1;
            btnAgregarDrog.Text = "Agregar Droguerias";
            btnAgregarDrog.UseVisualStyleBackColor = true;
            btnAgregarDrog.Click += btnAgregarDrog_Click;
            // 
            // btnEliminarDroguerias
            // 
            btnEliminarDroguerias.Location = new Point(363, 78);
            btnEliminarDroguerias.Name = "btnEliminarDroguerias";
            btnEliminarDroguerias.Size = new Size(89, 41);
            btnEliminarDroguerias.TabIndex = 2;
            btnEliminarDroguerias.Text = "Eliminar Droguerias";
            btnEliminarDroguerias.UseVisualStyleBackColor = true;
            btnEliminarDroguerias.Click += btnEliminarDroguerias_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 53);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 3;
            label1.Text = "Droguerias";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 24);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 4;
            label2.Text = "Monodrogas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 24);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 5;
            label3.Text = "Nombre Comercial";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 53);
            label4.Name = "label4";
            label4.Size = new Size(89, 15);
            label4.TabIndex = 6;
            label4.Text = "Precio De Venta";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 84);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 7;
            label5.Text = "Stock Actual";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 111);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 8;
            label6.Text = "Stock Minimo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 138);
            label7.Name = "label7";
            label7.Size = new Size(96, 15);
            label7.TabIndex = 9;
            label7.Text = "Es De Venta Libre";
            // 
            // dgvDrogueriasMedicamento
            // 
            dgvDrogueriasMedicamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasMedicamento.Location = new Point(19, 172);
            dgvDrogueriasMedicamento.Name = "dgvDrogueriasMedicamento";
            dgvDrogueriasMedicamento.RowTemplate.Height = 25;
            dgvDrogueriasMedicamento.Size = new Size(433, 167);
            dgvDrogueriasMedicamento.TabIndex = 10;
            // 
            // cBoxDroguerias
            // 
            cBoxDroguerias.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxDroguerias.FormattingEnabled = true;
            cBoxDroguerias.Location = new Point(331, 50);
            cBoxDroguerias.Name = "cBoxDroguerias";
            cBoxDroguerias.Size = new Size(121, 23);
            cBoxDroguerias.TabIndex = 11;
            // 
            // cBoxMonodrogas
            // 
            cBoxMonodrogas.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxMonodrogas.FormattingEnabled = true;
            cBoxMonodrogas.Location = new Point(331, 21);
            cBoxMonodrogas.Name = "cBoxMonodrogas";
            cBoxMonodrogas.Size = new Size(121, 23);
            cBoxMonodrogas.TabIndex = 12;
            // 
            // txtNombreComercial
            // 
            txtNombreComercial.Location = new Point(133, 21);
            txtNombreComercial.Name = "txtNombreComercial";
            txtNombreComercial.Size = new Size(100, 23);
            txtNombreComercial.TabIndex = 13;
            // 
            // txtPrecioDeVenta
            // 
            txtPrecioDeVenta.Location = new Point(133, 50);
            txtPrecioDeVenta.Name = "txtPrecioDeVenta";
            txtPrecioDeVenta.Size = new Size(100, 23);
            txtPrecioDeVenta.TabIndex = 14;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(133, 79);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 15;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(133, 108);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(100, 23);
            txtStockMinimo.TabIndex = 16;
            // 
            // cBoxVentaLibre
            // 
            cBoxVentaLibre.AutoSize = true;
            cBoxVentaLibre.Location = new Point(133, 137);
            cBoxVentaLibre.Name = "cBoxVentaLibre";
            cBoxVentaLibre.Size = new Size(35, 19);
            cBoxVentaLibre.TabIndex = 17;
            cBoxVentaLibre.Text = "Si";
            cBoxVentaLibre.UseVisualStyleBackColor = true;
            // 
            // btnModifMedicamento
            // 
            btnModifMedicamento.Location = new Point(363, 125);
            btnModifMedicamento.Name = "btnModifMedicamento";
            btnModifMedicamento.Size = new Size(89, 41);
            btnModifMedicamento.TabIndex = 18;
            btnModifMedicamento.Text = "Modificar Medicamento";
            btnModifMedicamento.UseVisualStyleBackColor = true;
            btnModifMedicamento.Click += btnModifMedicamento_Click;
            // 
            // AgregarMedicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 350);
            Controls.Add(btnModifMedicamento);
            Controls.Add(cBoxVentaLibre);
            Controls.Add(txtStockMinimo);
            Controls.Add(txtStock);
            Controls.Add(txtPrecioDeVenta);
            Controls.Add(txtNombreComercial);
            Controls.Add(cBoxMonodrogas);
            Controls.Add(cBoxDroguerias);
            Controls.Add(dgvDrogueriasMedicamento);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEliminarDroguerias);
            Controls.Add(btnAgregarDrog);
            Controls.Add(btnAgregar);
            Name = "AgregarMedicamentos";
            Text = "AgregarMedicamentos";
            Load += AgregarMedicamentos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasMedicamento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Button btnAgregarDrog;
        private Button btnEliminarDroguerias;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridView dgvDrogueriasMedicamento;
        private ComboBox cBoxDroguerias;
        private ComboBox cBoxMonodrogas;
        private TextBox txtNombreComercial;
        private TextBox txtPrecioDeVenta;
        private TextBox txtStock;
        private TextBox txtStockMinimo;
        private CheckBox cBoxVentaLibre;
        private Button btnModifMedicamento;
    }
}