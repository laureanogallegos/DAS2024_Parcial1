namespace Parcial1
{
    partial class FormPrincipal
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
            menuStrip1 = new MenuStrip();
            monodrogaToolStripMenuItem = new ToolStripMenuItem();
            drogueriaToolStripMenuItem = new ToolStripMenuItem();
            medicamentosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { monodrogaToolStripMenuItem, drogueriaToolStripMenuItem, medicamentosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(395, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // monodrogaToolStripMenuItem
            // 
            monodrogaToolStripMenuItem.Name = "monodrogaToolStripMenuItem";
            monodrogaToolStripMenuItem.Size = new Size(82, 20);
            monodrogaToolStripMenuItem.Text = "Monodroga";
            monodrogaToolStripMenuItem.Click += monodrogaToolStripMenuItem_Click;
            // 
            // drogueriaToolStripMenuItem
            // 
            drogueriaToolStripMenuItem.Name = "drogueriaToolStripMenuItem";
            drogueriaToolStripMenuItem.Size = new Size(71, 20);
            drogueriaToolStripMenuItem.Text = "Drogueria";
            drogueriaToolStripMenuItem.Click += drogueriaToolStripMenuItem_Click;
            // 
            // medicamentosToolStripMenuItem
            // 
            medicamentosToolStripMenuItem.Name = "medicamentosToolStripMenuItem";
            medicamentosToolStripMenuItem.Size = new Size(98, 20);
            medicamentosToolStripMenuItem.Text = "Medicamentos";
            medicamentosToolStripMenuItem.Click += medicamentosToolStripMenuItem_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 154);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem monodrogaToolStripMenuItem;
        private ToolStripMenuItem drogueriaToolStripMenuItem;
        private ToolStripMenuItem medicamentosToolStripMenuItem;
    }
}