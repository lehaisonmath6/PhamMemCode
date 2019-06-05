namespace ArmyProject
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tùyChọnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.điềuKhiểnĐiệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tùyChọnToolStripMenuItem,
            this.điềuKhiểnĐiệnToolStripMenuItem,
            this.thuToolStripMenuItem,
            this.phátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(905, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tùyChọnToolStripMenuItem
            // 
            this.tùyChọnToolStripMenuItem.Name = "tùyChọnToolStripMenuItem";
            this.tùyChọnToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.tùyChọnToolStripMenuItem.Text = "Tùy chọn";
            // 
            // điềuKhiểnĐiệnToolStripMenuItem
            // 
            this.điềuKhiểnĐiệnToolStripMenuItem.Name = "điềuKhiểnĐiệnToolStripMenuItem";
            this.điềuKhiểnĐiệnToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.điềuKhiểnĐiệnToolStripMenuItem.Text = "Điều khiển điện";
            this.điềuKhiểnĐiệnToolStripMenuItem.Click += new System.EventHandler(this.điềuKhiểnĐiệnToolStripMenuItem_Click);
            // 
            // thuToolStripMenuItem
            // 
            this.thuToolStripMenuItem.Name = "thuToolStripMenuItem";
            this.thuToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.thuToolStripMenuItem.Text = "Thu";
            // 
            // phátToolStripMenuItem
            // 
            this.phátToolStripMenuItem.Name = "phátToolStripMenuItem";
            this.phátToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.phátToolStripMenuItem.Text = "Phát";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tùyChọnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem điềuKhiểnĐiệnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phátToolStripMenuItem;
    }
}

