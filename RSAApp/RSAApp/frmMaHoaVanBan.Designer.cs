namespace RSAApp
{
    partial class frmMaHoaVanBan
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
            this.rtbBanRo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMaHoa = new System.Windows.Forms.Button();
            this.btnGiaiMa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbBanMa = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbGiaiMa = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbBanRo
            // 
            this.rtbBanRo.Location = new System.Drawing.Point(23, 45);
            this.rtbBanRo.Name = "rtbBanRo";
            this.rtbBanRo.Size = new System.Drawing.Size(417, 60);
            this.rtbBanRo.TabIndex = 0;
            this.rtbBanRo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bản rõ";
            // 
            // btnMaHoa
            // 
            this.btnMaHoa.Location = new System.Drawing.Point(446, 45);
            this.btnMaHoa.Name = "btnMaHoa";
            this.btnMaHoa.Size = new System.Drawing.Size(75, 60);
            this.btnMaHoa.TabIndex = 2;
            this.btnMaHoa.Text = "Mã hóa";
            this.btnMaHoa.UseVisualStyleBackColor = true;
            this.btnMaHoa.Click += new System.EventHandler(this.btnMaHoa_Click);
            // 
            // btnGiaiMa
            // 
            this.btnGiaiMa.Location = new System.Drawing.Point(447, 140);
            this.btnGiaiMa.Name = "btnGiaiMa";
            this.btnGiaiMa.Size = new System.Drawing.Size(75, 60);
            this.btnGiaiMa.TabIndex = 5;
            this.btnGiaiMa.Text = "Giải mã";
            this.btnGiaiMa.UseVisualStyleBackColor = true;
            this.btnGiaiMa.Click += new System.EventHandler(this.btnGiaiMa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bản mã";
            // 
            // rtbBanMa
            // 
            this.rtbBanMa.Location = new System.Drawing.Point(24, 140);
            this.rtbBanMa.Name = "rtbBanMa";
            this.rtbBanMa.Size = new System.Drawing.Size(417, 60);
            this.rtbBanMa.TabIndex = 3;
            this.rtbBanMa.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bản giải mã";
            // 
            // rtbGiaiMa
            // 
            this.rtbGiaiMa.Location = new System.Drawing.Point(24, 239);
            this.rtbGiaiMa.Name = "rtbGiaiMa";
            this.rtbGiaiMa.Size = new System.Drawing.Size(417, 60);
            this.rtbGiaiMa.TabIndex = 6;
            this.rtbGiaiMa.Text = "";
            // 
            // frmMaHoaVanBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 347);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbGiaiMa);
            this.Controls.Add(this.btnGiaiMa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbBanMa);
            this.Controls.Add(this.btnMaHoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbBanRo);
            this.Name = "frmMaHoaVanBan";
            this.Text = "Mã hóa văn bản RSA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbBanRo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMaHoa;
        private System.Windows.Forms.Button btnGiaiMa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbBanMa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbGiaiMa;
    }
}