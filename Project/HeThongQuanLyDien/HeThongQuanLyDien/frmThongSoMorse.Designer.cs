namespace HeThongQuanLyDien
{
    partial class frmThongSoMorse
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
            this.txtAmThanh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDoDaiDot = new System.Windows.Forms.TextBox();
            this.txtDoDaiDash = new System.Windows.Forms.TextBox();
            this.txtDotDash = new System.Windows.Forms.TextBox();
            this.txtKCChu = new System.Windows.Forms.TextBox();
            this.txtKCTu = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAmThanh
            // 
            this.txtAmThanh.Location = new System.Drawing.Point(189, 21);
            this.txtAmThanh.Name = "txtAmThanh";
            this.txtAmThanh.Size = new System.Drawing.Size(142, 20);
            this.txtAmThanh.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tần số âm thanh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Độ dài dot";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Độ dài dash";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Khoảng cách dot dash";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Khoảng cách giữa các chữ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Khoảng cách giữa các từ";
            // 
            // txtDoDaiDot
            // 
            this.txtDoDaiDot.Location = new System.Drawing.Point(189, 61);
            this.txtDoDaiDot.Name = "txtDoDaiDot";
            this.txtDoDaiDot.Size = new System.Drawing.Size(142, 20);
            this.txtDoDaiDot.TabIndex = 7;
            // 
            // txtDoDaiDash
            // 
            this.txtDoDaiDash.Location = new System.Drawing.Point(189, 98);
            this.txtDoDaiDash.Name = "txtDoDaiDash";
            this.txtDoDaiDash.Size = new System.Drawing.Size(142, 20);
            this.txtDoDaiDash.TabIndex = 8;
            // 
            // txtDotDash
            // 
            this.txtDotDash.Location = new System.Drawing.Point(189, 136);
            this.txtDotDash.Name = "txtDotDash";
            this.txtDotDash.Size = new System.Drawing.Size(142, 20);
            this.txtDotDash.TabIndex = 9;
            // 
            // txtKCChu
            // 
            this.txtKCChu.Location = new System.Drawing.Point(189, 176);
            this.txtKCChu.Name = "txtKCChu";
            this.txtKCChu.Size = new System.Drawing.Size(142, 20);
            this.txtKCChu.TabIndex = 10;
            // 
            // txtKCTu
            // 
            this.txtKCTu.Location = new System.Drawing.Point(189, 216);
            this.txtKCTu.Name = "txtKCTu";
            this.txtKCTu.Size = new System.Drawing.Size(142, 20);
            this.txtKCTu.TabIndex = 11;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(256, 255);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 32);
            this.btnLuu.TabIndex = 12;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmThongSoMorse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 311);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtKCTu);
            this.Controls.Add(this.txtKCChu);
            this.Controls.Add(this.txtDotDash);
            this.Controls.Add(this.txtDoDaiDash);
            this.Controls.Add(this.txtDoDaiDot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAmThanh);
            this.Name = "frmThongSoMorse";
            this.Text = "Thông số cấu hình morse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmThanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDoDaiDot;
        private System.Windows.Forms.TextBox txtDoDaiDash;
        private System.Windows.Forms.TextBox txtDotDash;
        private System.Windows.Forms.TextBox txtKCChu;
        private System.Windows.Forms.TextBox txtKCTu;
        private System.Windows.Forms.Button btnLuu;
    }
}