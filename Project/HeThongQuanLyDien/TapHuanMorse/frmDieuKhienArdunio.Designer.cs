namespace TapHuanMorse
{
    partial class frmDieuKhienArdunio
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
            this.txtAmSac = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBaseTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtAmSac
            // 
            this.txtAmSac.Location = new System.Drawing.Point(136, 34);
            this.txtAmSac.Name = "txtAmSac";
            this.txtAmSac.Size = new System.Drawing.Size(126, 20);
            this.txtAmSac.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Âm sắc";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(136, 146);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(126, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Áp dụng";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số chữ /phút";
            // 
            // txtBaseTime
            // 
            this.txtBaseTime.Location = new System.Drawing.Point(136, 88);
            this.txtBaseTime.Name = "txtBaseTime";
            this.txtBaseTime.Size = new System.Drawing.Size(126, 20);
            this.txtBaseTime.TabIndex = 4;
            // 
            // frmDieuKhienArdunio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 198);
            this.Controls.Add(this.txtBaseTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAmSac);
            this.Name = "frmDieuKhienArdunio";
            this.Text = "Điều khiển thông số";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmSac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBaseTime;
    }
}