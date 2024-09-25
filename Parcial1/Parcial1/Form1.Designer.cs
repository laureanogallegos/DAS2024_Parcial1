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
            btnABMMedicamento = new Button();
            SuspendLayout();
            // 
            // btnABMMedicamento
            // 
            btnABMMedicamento.BackColor = SystemColors.ActiveCaption;
            btnABMMedicamento.Location = new Point(54, 32);
            btnABMMedicamento.Name = "btnABMMedicamento";
            btnABMMedicamento.Size = new Size(128, 46);
            btnABMMedicamento.TabIndex = 0;
            btnABMMedicamento.Text = "ABM MEDICAMENTO";
            btnABMMedicamento.UseVisualStyleBackColor = false;
            btnABMMedicamento.Click += btnABMMedicamento_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnABMMedicamento);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnABMMedicamento;
    }
}