namespace Parcial1
{
    partial class FormMedicamentos
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
            dgvMedicamentos = new DataGridView();
            NombreComercial = new DataGridViewTextBoxColumn();
            VentaLibre = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            StockActual = new DataGridViewTextBoxColumn();
            StockMinimo = new DataGridViewTextBoxColumn();
            Monodroga = new DataGridViewTextBoxColumn();
            Droguerias = new DataGridViewTextBoxColumn();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            SuspendLayout();
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Columns.AddRange(new DataGridViewColumn[] { NombreComercial, VentaLibre, PrecioVenta, StockActual, StockMinimo, Monodroga, Droguerias });
            dgvMedicamentos.Location = new Point(46, 24);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowTemplate.Height = 25;
            dgvMedicamentos.Size = new Size(509, 150);
            dgvMedicamentos.TabIndex = 0;
            // 
            // NombreComercial
            // 
            NombreComercial.DataPropertyName = "NombreComercial";
            NombreComercial.HeaderText = "NombreComercial";
            NombreComercial.Name = "NombreComercial";
            // 
            // VentaLibre
            // 
            VentaLibre.DataPropertyName = "VentaLibre";
            VentaLibre.HeaderText = "VentaLibre";
            VentaLibre.Name = "VentaLibre";
            // 
            // PrecioVenta
            // 
            PrecioVenta.DataPropertyName = "PrecioVenta";
            PrecioVenta.HeaderText = "PrecioVenta";
            PrecioVenta.Name = "PrecioVenta";
            // 
            // StockActual
            // 
            StockActual.DataPropertyName = "StockActual";
            StockActual.HeaderText = "StockActual";
            StockActual.Name = "StockActual";
            // 
            // StockMinimo
            // 
            StockMinimo.DataPropertyName = "StockMinimo";
            StockMinimo.HeaderText = "StockMinimo";
            StockMinimo.Name = "StockMinimo";
            // 
            // Monodroga
            // 
            Monodroga.DataPropertyName = "Monodroga";
            Monodroga.HeaderText = "Monodroga";
            Monodroga.Name = "Monodroga";
            // 
            // Droguerias
            // 
            Droguerias.DataPropertyName = "Droguerias";
            Droguerias.HeaderText = "Droguerias";
            Droguerias.Name = "Droguerias";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(46, 201);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(93, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(262, 201);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(90, 23);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(467, 201);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(88, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FormMedicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 242);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvMedicamentos);
            Name = "FormMedicamentos";
            Text = "FormMedicamentos";
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMedicamentos;
        private DataGridViewTextBoxColumn NombreComercial;
        private DataGridViewTextBoxColumn VentaLibre;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn StockActual;
        private DataGridViewTextBoxColumn StockMinimo;
        private DataGridViewTextBoxColumn Monodroga;
        private DataGridViewTextBoxColumn Droguerias;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
    }
}