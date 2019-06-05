namespace RSAApp
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
            this.btnVanBan = new System.Windows.Forms.Button();
            this.btnSo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVanBan
            // 
            this.btnVanBan.Location = new System.Drawing.Point(56, 45);
            this.btnVanBan.Name = "btnVanBan";
            this.btnVanBan.Size = new System.Drawing.Size(159, 40);
            this.btnVanBan.TabIndex = 0;
            this.btnVanBan.Text = "Mã hóa văn bản";
            this.btnVanBan.UseVisualStyleBackColor = true;
            this.btnVanBan.Click += new System.EventHandler(this.btnVanBan_Click);
            // 
            // btnSo
            // 
            this.btnSo.Location = new System.Drawing.Point(56, 139);
            this.btnSo.Name = "btnSo";
            this.btnSo.Size = new System.Drawing.Size(159, 40);
            this.btnSo.TabIndex = 1;
            this.btnSo.Text = "Mã hóa số";
            this.btnSo.UseVisualStyleBackColor = true;
            this.btnSo.Click += new System.EventHandler(this.btnSo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 211);
            this.Controls.Add(this.btnSo);
            this.Controls.Add(this.btnVanBan);
            this.Name = "Form1";
            this.Text = "Thuật toán mã hóa RSA";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVanBan;
        private System.Windows.Forms.Button btnSo;
    }
}

