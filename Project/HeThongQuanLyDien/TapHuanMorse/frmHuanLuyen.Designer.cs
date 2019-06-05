namespace TapHuanMorse
{
    partial class frmHuanLuyen
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
            this.lưuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoNhom = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApDung = new System.Windows.Forms.Button();
            this.txtAmSac = new System.Windows.Forms.NumericUpDown();
            this.txtTocDo = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTaoBang = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSendMorse = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbTienTrinh = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbBangDienPhat = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCauHinh = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmSac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTocDo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lưuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lưuToolStripMenuItem
            // 
            this.lưuToolStripMenuItem.Name = "lưuToolStripMenuItem";
            this.lưuToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.lưuToolStripMenuItem.Text = "Lưu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng số nhóm";
            // 
            // txtSoNhom
            // 
            this.txtSoNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoNhom.Location = new System.Drawing.Point(198, 11);
            this.txtSoNhom.Name = "txtSoNhom";
            this.txtSoNhom.Size = new System.Drawing.Size(120, 29);
            this.txtSoNhom.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCauHinh);
            this.panel1.Controls.Add(this.btnApDung);
            this.panel1.Controls.Add(this.txtAmSac);
            this.panel1.Controls.Add(this.txtTocDo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnTaoBang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSoNhom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1136, 121);
            this.panel1.TabIndex = 6;
            // 
            // btnApDung
            // 
            this.btnApDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApDung.Location = new System.Drawing.Point(690, 61);
            this.btnApDung.Name = "btnApDung";
            this.btnApDung.Size = new System.Drawing.Size(120, 36);
            this.btnApDung.TabIndex = 16;
            this.btnApDung.Text = "Áp dụng";
            this.btnApDung.UseVisualStyleBackColor = true;
            this.btnApDung.Click += new System.EventHandler(this.btnApDung_Click);
            // 
            // txtAmSac
            // 
            this.txtAmSac.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmSac.Location = new System.Drawing.Point(506, 61);
            this.txtAmSac.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtAmSac.Name = "txtAmSac";
            this.txtAmSac.Size = new System.Drawing.Size(141, 29);
            this.txtAmSac.TabIndex = 15;
            this.txtAmSac.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // txtTocDo
            // 
            this.txtTocDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTocDo.Location = new System.Drawing.Point(198, 61);
            this.txtTocDo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtTocDo.Name = "txtTocDo";
            this.txtTocDo.Size = new System.Drawing.Size(120, 29);
            this.txtTocDo.TabIndex = 14;
            this.txtTocDo.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tốc độ chữ / phút";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(403, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ấm sắc";
            // 
            // btnTaoBang
            // 
            this.btnTaoBang.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoBang.Location = new System.Drawing.Point(690, 8);
            this.btnTaoBang.Name = "btnTaoBang";
            this.btnTaoBang.Size = new System.Drawing.Size(120, 36);
            this.btnTaoBang.TabIndex = 6;
            this.btnTaoBang.Text = "Tạo bảng điện";
            this.btnTaoBang.UseVisualStyleBackColor = true;
            this.btnTaoBang.Click += new System.EventHandler(this.btnTaoBang_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSendMorse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 457);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1136, 43);
            this.panel2.TabIndex = 7;
            // 
            // btnSendMorse
            // 
            this.btnSendMorse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSendMorse.Location = new System.Drawing.Point(452, 6);
            this.btnSendMorse.Name = "btnSendMorse";
            this.btnSendMorse.Size = new System.Drawing.Size(120, 23);
            this.btnSendMorse.TabIndex = 7;
            this.btnSendMorse.Text = "Phát tín";
            this.btnSendMorse.UseVisualStyleBackColor = true;
            this.btnSendMorse.Click += new System.EventHandler(this.btnSendMorse_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1136, 312);
            this.panel3.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbTienTrinh);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(543, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 312);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiến trình phát";
            // 
            // rtbTienTrinh
            // 
            this.rtbTienTrinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTienTrinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTienTrinh.Location = new System.Drawing.Point(3, 16);
            this.rtbTienTrinh.Name = "rtbTienTrinh";
            this.rtbTienTrinh.Size = new System.Drawing.Size(587, 293);
            this.rtbTienTrinh.TabIndex = 0;
            this.rtbTienTrinh.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbBangDienPhat);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 312);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng điện phát";
            // 
            // rtbBangDienPhat
            // 
            this.rtbBangDienPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbBangDienPhat.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbBangDienPhat.Location = new System.Drawing.Point(3, 16);
            this.rtbBangDienPhat.Name = "rtbBangDienPhat";
            this.rtbBangDienPhat.Size = new System.Drawing.Size(537, 293);
            this.rtbBangDienPhat.TabIndex = 0;
            this.rtbBangDienPhat.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(403, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Cấu hình";
            // 
            // txtCauHinh
            // 
            this.txtCauHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCauHinh.Location = new System.Drawing.Point(506, 11);
            this.txtCauHinh.Name = "txtCauHinh";
            this.txtCauHinh.Size = new System.Drawing.Size(141, 29);
            this.txtCauHinh.TabIndex = 18;
            // 
            // frmHuanLuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 500);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmHuanLuyen";
            this.Text = "Phầm mềm huấn luyện";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmSac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTocDo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lưuToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoNhom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTaoBang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSendMorse;
        private System.Windows.Forms.Button btnApDung;
        private System.Windows.Forms.NumericUpDown txtAmSac;
        private System.Windows.Forms.NumericUpDown txtTocDo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbTienTrinh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbBangDienPhat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCauHinh;
    }
}

