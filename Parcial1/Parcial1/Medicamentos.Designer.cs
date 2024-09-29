namespace Parcial1
{
    partial class Medicamentos
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
            groupBox2 = new GroupBox();
            dgvDAdheridas = new DataGridView();
            btn_EliminarMed = new Button();
            btn_ModMed = new Button();
            btn_AgregarMed = new Button();
            dgv_Medicamentos = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDAdheridas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Medicamentos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(btn_EliminarMed);
            groupBox1.Controls.Add(btn_ModMed);
            groupBox1.Controls.Add(btn_AgregarMed);
            groupBox1.Controls.Add(dgv_Medicamentos);
            groupBox1.Location = new Point(28, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(747, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Administración Medicamentos";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvDAdheridas);
            groupBox2.Location = new Point(19, 221);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(537, 199);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Droguerias Adheridas";
            // 
            // dgvDAdheridas
            // 
            dgvDAdheridas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDAdheridas.Location = new Point(16, 32);
            dgvDAdheridas.Name = "dgvDAdheridas";
            dgvDAdheridas.RowTemplate.Height = 25;
            dgvDAdheridas.Size = new Size(500, 150);
            dgvDAdheridas.TabIndex = 0;
            // 
            // btn_EliminarMed
            // 
            btn_EliminarMed.Location = new Point(578, 149);
            btn_EliminarMed.Name = "btn_EliminarMed";
            btn_EliminarMed.Size = new Size(94, 48);
            btn_EliminarMed.TabIndex = 3;
            btn_EliminarMed.Text = "Eliminar Medicamento";
            btn_EliminarMed.UseVisualStyleBackColor = true;
            btn_EliminarMed.Click += btn_EliminarMed_Click;
            // 
            // btn_ModMed
            // 
            btn_ModMed.Location = new Point(578, 96);
            btn_ModMed.Name = "btn_ModMed";
            btn_ModMed.Size = new Size(94, 47);
            btn_ModMed.TabIndex = 2;
            btn_ModMed.Text = "Modificar Medicamento";
            btn_ModMed.UseVisualStyleBackColor = true;
            btn_ModMed.Click += btn_ModMed_Click;
            // 
            // btn_AgregarMed
            // 
            btn_AgregarMed.Location = new Point(578, 52);
            btn_AgregarMed.Name = "btn_AgregarMed";
            btn_AgregarMed.RightToLeft = RightToLeft.Yes;
            btn_AgregarMed.Size = new Size(94, 38);
            btn_AgregarMed.TabIndex = 1;
            btn_AgregarMed.Text = "Nuevo Medicamento";
            btn_AgregarMed.UseVisualStyleBackColor = true;
            btn_AgregarMed.Click += btn_AgregarMed_Click;
            // 
            // dgv_Medicamentos
            // 
            dgv_Medicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Medicamentos.Location = new Point(19, 22);
            dgv_Medicamentos.Name = "dgv_Medicamentos";
            dgv_Medicamentos.RowTemplate.Height = 25;
            dgv_Medicamentos.Size = new Size(537, 193);
            dgv_Medicamentos.TabIndex = 0;
            dgv_Medicamentos.SelectionChanged += dgv_Medicamentos_SelectionChanged;
            // 
            // Medicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "Medicamentos";
            Text = "Form1";
            Load += Medicamentos_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDAdheridas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Medicamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_ModMed;
        private Button btn_AgregarMed;
        private DataGridView dgv_Medicamentos;
        private Button btn_EliminarMed;
        private GroupBox groupBox2;
        private DataGridView dgvDAdheridas;
    }
}