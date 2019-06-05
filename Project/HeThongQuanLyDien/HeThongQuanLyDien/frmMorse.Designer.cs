namespace HeThongQuanLyDien
{
    partial class frmMorse
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
            this.địnhNghĩaBảngMãToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thiếtLậpTầnSốToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mởToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPhatTin = new System.Windows.Forms.Button();
            this.btnPhat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVanBan = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tùyChọnToolStripMenuItem,
            this.mởToolStripMenuItem,
            this.lưuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(788, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tùyChọnToolStripMenuItem
            // 
            this.tùyChọnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.địnhNghĩaBảngMãToolStripMenuItem,
            this.thiếtLậpTầnSốToolStripMenuItem});
            this.tùyChọnToolStripMenuItem.Name = "tùyChọnToolStripMenuItem";
            this.tùyChọnToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.tùyChọnToolStripMenuItem.Text = "Tùy chọn";
            // 
            // địnhNghĩaBảngMãToolStripMenuItem
            // 
            this.địnhNghĩaBảngMãToolStripMenuItem.Name = "địnhNghĩaBảngMãToolStripMenuItem";
            this.địnhNghĩaBảngMãToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.địnhNghĩaBảngMãToolStripMenuItem.Text = "Định nghĩa bảng mã";
            this.địnhNghĩaBảngMãToolStripMenuItem.Click += new System.EventHandler(this.địnhNghĩaBảngMãToolStripMenuItem_Click);
            // 
            // thiếtLậpTầnSốToolStripMenuItem
            // 
            this.thiếtLậpTầnSốToolStripMenuItem.Name = "thiếtLậpTầnSốToolStripMenuItem";
            this.thiếtLậpTầnSốToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.thiếtLậpTầnSốToolStripMenuItem.Text = "Thiết lập thông số";
            this.thiếtLậpTầnSốToolStripMenuItem.Click += new System.EventHandler(this.thiếtLậpTầnSốToolStripMenuItem_Click);
            // 
            // mởToolStripMenuItem
            // 
            this.mởToolStripMenuItem.Name = "mởToolStripMenuItem";
            this.mởToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.mởToolStripMenuItem.Text = "Mở";
            this.mởToolStripMenuItem.Click += new System.EventHandler(this.mởToolStripMenuItem_Click);
            // 
            // lưuToolStripMenuItem
            // 
            this.lưuToolStripMenuItem.Name = "lưuToolStripMenuItem";
            this.lưuToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.lưuToolStripMenuItem.Text = "Lưu";
            this.lưuToolStripMenuItem.Click += new System.EventHandler(this.lưuToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPhatTin);
            this.panel1.Controls.Add(this.btnPhat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 64);
            this.panel1.TabIndex = 4;
            // 
            // btnPhatTin
            // 
            this.btnPhatTin.Location = new System.Drawing.Point(488, 11);
            this.btnPhatTin.Name = "btnPhatTin";
            this.btnPhatTin.Size = new System.Drawing.Size(75, 35);
            this.btnPhatTin.TabIndex = 2;
            this.btnPhatTin.Text = "Phát tín";
            this.btnPhatTin.UseVisualStyleBackColor = true;
            this.btnPhatTin.Click += new System.EventHandler(this.btnPhatTin_Click);
            // 
            // btnPhat
            // 
            this.btnPhat.Location = new System.Drawing.Point(183, 11);
            this.btnPhat.Name = "btnPhat";
            this.btnPhat.Size = new System.Drawing.Size(75, 35);
            this.btnPhat.TabIndex = 0;
            this.btnPhat.Text = "Gửi tín";
            this.btnPhat.UseVisualStyleBackColor = true;
            this.btnPhat.Click += new System.EventHandler(this.btnPhat_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(788, 241);
            this.panel2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVanBan);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 241);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập văn bản";
            // 
            // txtVanBan
            // 
            this.txtVanBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVanBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVanBan.Location = new System.Drawing.Point(3, 16);
            this.txtVanBan.Name = "txtVanBan";
            this.txtVanBan.Size = new System.Drawing.Size(782, 222);
            this.txtVanBan.TabIndex = 0;
            this.txtVanBan.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            // 
            // frmMorse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 329);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMorse";
            this.Text = "Quản lý mã morse";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tùyChọnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem địnhNghĩaBảngMãToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thiếtLậpTầnSốToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mởToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPhat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtVanBan;
        private System.Windows.Forms.ToolStripMenuItem lưuToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnPhatTin;
    }
}