namespace HeThongQuanLyDien
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
            this.btnMaMorse = new System.Windows.Forms.Button();
            this.btnBaoDien = new System.Windows.Forms.Button();
            this.btnDieuKhienTanSo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMaMorse
            // 
            this.btnMaMorse.Location = new System.Drawing.Point(39, 32);
            this.btnMaMorse.Name = "btnMaMorse";
            this.btnMaMorse.Size = new System.Drawing.Size(176, 39);
            this.btnMaMorse.TabIndex = 0;
            this.btnMaMorse.Text = "Phát morse trực tiếp";
            this.btnMaMorse.UseVisualStyleBackColor = true;
            this.btnMaMorse.Click += new System.EventHandler(this.btnMaMorse_Click);
            // 
            // btnBaoDien
            // 
            this.btnBaoDien.Location = new System.Drawing.Point(39, 109);
            this.btnBaoDien.Name = "btnBaoDien";
            this.btnBaoDien.Size = new System.Drawing.Size(176, 39);
            this.btnBaoDien.TabIndex = 1;
            this.btnBaoDien.Text = "Phát morse lịch trình";
            this.btnBaoDien.UseVisualStyleBackColor = true;
            this.btnBaoDien.Click += new System.EventHandler(this.btnBaoDien_Click);
            // 
            // btnDieuKhienTanSo
            // 
            this.btnDieuKhienTanSo.Location = new System.Drawing.Point(39, 183);
            this.btnDieuKhienTanSo.Name = "btnDieuKhienTanSo";
            this.btnDieuKhienTanSo.Size = new System.Drawing.Size(176, 39);
            this.btnDieuKhienTanSo.TabIndex = 2;
            this.btnDieuKhienTanSo.Text = "Điều khiển tần số";
            this.btnDieuKhienTanSo.UseVisualStyleBackColor = true;
            this.btnDieuKhienTanSo.Click += new System.EventHandler(this.btnDieuKhienTanSo_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 307);
            this.Controls.Add(this.btnDieuKhienTanSo);
            this.Controls.Add(this.btnBaoDien);
            this.Controls.Add(this.btnMaMorse);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMaMorse;
        private System.Windows.Forms.Button btnBaoDien;
        private System.Windows.Forms.Button btnDieuKhienTanSo;
    }
}