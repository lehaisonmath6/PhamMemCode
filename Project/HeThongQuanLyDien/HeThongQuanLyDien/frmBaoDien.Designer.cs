namespace HeThongQuanLyDien
{
    partial class frmBaoDien
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tùyChọnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvBangDien = new System.Windows.Forms.DataGridView();
            this.SoDien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoKhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLanPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhatTuDong = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NguoiPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cboMay = new System.Windows.Forms.ComboBox();
            this.cboDoKhan = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoNhom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.txtNguoiPhat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenTextDien = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chkPhatTuDong = new System.Windows.Forms.CheckBox();
            this.rtbNoiDungDien = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoLanPhat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoDien = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBatHenPhat = new System.Windows.Forms.Button();
            this.btnXoaBangDien = new System.Windows.Forms.Button();
            this.btnSuaBangDien = new System.Windows.Forms.Button();
            this.btnThemBangDien = new System.Windows.Forms.Button();
            this.btnTatMayPhat = new System.Windows.Forms.Button();
            this.btnBatMayPhat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bindingSourceBangDien = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnPhatNgay = new System.Windows.Forms.Button();
            this.cấuHìnhMáyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDien)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBangDien)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tùyChọnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1271, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tùyChọnToolStripMenuItem
            // 
            this.tùyChọnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cấuHìnhMáyToolStripMenuItem});
            this.tùyChọnToolStripMenuItem.Name = "tùyChọnToolStripMenuItem";
            this.tùyChọnToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.tùyChọnToolStripMenuItem.Text = "Tùy chọn";
            // 
            // dgvBangDien
            // 
            this.dgvBangDien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangDien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBangDien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangDien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoDien,
            this.SoNhom,
            this.NoiDung,
            this.DoKhan,
            this.SoLanPhat,
            this.GioBatDau,
            this.GioKetThuc,
            this.PhatTuDong,
            this.NguoiPhat});
            this.dgvBangDien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBangDien.Location = new System.Drawing.Point(0, 0);
            this.dgvBangDien.Name = "dgvBangDien";
            this.dgvBangDien.ReadOnly = true;
            this.dgvBangDien.RowHeadersVisible = false;
            this.dgvBangDien.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBangDien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBangDien.Size = new System.Drawing.Size(1271, 119);
            this.dgvBangDien.TabIndex = 19;
            this.dgvBangDien.Click += new System.EventHandler(this.dgvBangDien_Click);
            // 
            // SoDien
            // 
            this.SoDien.DataPropertyName = "SoDien";
            this.SoDien.HeaderText = "Số điện";
            this.SoDien.Name = "SoDien";
            this.SoDien.ReadOnly = true;
            // 
            // SoNhom
            // 
            this.SoNhom.DataPropertyName = "SoNhom";
            this.SoNhom.HeaderText = "Số nhóm";
            this.SoNhom.Name = "SoNhom";
            this.SoNhom.ReadOnly = true;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội dung điện";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            // 
            // DoKhan
            // 
            this.DoKhan.DataPropertyName = "DoKhan";
            this.DoKhan.HeaderText = "Độ khẩn";
            this.DoKhan.Name = "DoKhan";
            this.DoKhan.ReadOnly = true;
            // 
            // SoLanPhat
            // 
            this.SoLanPhat.DataPropertyName = "SoLanPhat";
            this.SoLanPhat.HeaderText = "Số lần phát";
            this.SoLanPhat.Name = "SoLanPhat";
            this.SoLanPhat.ReadOnly = true;
            // 
            // GioBatDau
            // 
            this.GioBatDau.DataPropertyName = "GioBatDau";
            this.GioBatDau.HeaderText = "Giờ bắt đầu";
            this.GioBatDau.Name = "GioBatDau";
            this.GioBatDau.ReadOnly = true;
            // 
            // GioKetThuc
            // 
            this.GioKetThuc.DataPropertyName = "GioKetThuc";
            this.GioKetThuc.HeaderText = "Giờ kết thúc";
            this.GioKetThuc.Name = "GioKetThuc";
            this.GioKetThuc.ReadOnly = true;
            // 
            // PhatTuDong
            // 
            this.PhatTuDong.DataPropertyName = "PhatTuDong";
            this.PhatTuDong.FalseValue = "False";
            this.PhatTuDong.HeaderText = "Phát tự động";
            this.PhatTuDong.Name = "PhatTuDong";
            this.PhatTuDong.ReadOnly = true;
            this.PhatTuDong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PhatTuDong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PhatTuDong.TrueValue = "True";
            // 
            // NguoiPhat
            // 
            this.NguoiPhat.DataPropertyName = "NguoiPhat";
            this.NguoiPhat.HeaderText = "Người phát";
            this.NguoiPhat.Name = "NguoiPhat";
            this.NguoiPhat.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cboMay);
            this.panel1.Controls.Add(this.cboDoKhan);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtSoNhom);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dtpKetThuc);
            this.panel1.Controls.Add(this.dtpBatDau);
            this.panel1.Controls.Add(this.txtNguoiPhat);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnOpenTextDien);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.chkPhatTuDong);
            this.panel1.Controls.Add(this.rtbNoiDungDien);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSoLanPhat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSoDien);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1271, 307);
            this.panel1.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(409, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Máy";
            // 
            // cboMay
            // 
            this.cboMay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMay.FormattingEnabled = true;
            this.cboMay.Location = new System.Drawing.Point(553, 223);
            this.cboMay.Name = "cboMay";
            this.cboMay.Size = new System.Drawing.Size(129, 28);
            this.cboMay.TabIndex = 20;
            // 
            // cboDoKhan
            // 
            this.cboDoKhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoKhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDoKhan.FormattingEnabled = true;
            this.cboDoKhan.Items.AddRange(new object[] {
            "TKZ",
            "TK",
            "TgK",
            "K"});
            this.cboDoKhan.Location = new System.Drawing.Point(131, 147);
            this.cboDoKhan.Name = "cboDoKhan";
            this.cboDoKhan.Size = new System.Drawing.Size(186, 28);
            this.cboDoKhan.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Độ khẩn";
            // 
            // txtSoNhom
            // 
            this.txtSoNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoNhom.Location = new System.Drawing.Point(131, 91);
            this.txtSoNhom.Name = "txtSoNhom";
            this.txtSoNhom.Size = new System.Drawing.Size(186, 26);
            this.txtSoNhom.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Số nhóm";
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.CustomFormat = "HH:mm:ss";
            this.dtpKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKetThuc.Location = new System.Drawing.Point(553, 91);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(129, 26);
            this.dtpKetThuc.TabIndex = 6;
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.CustomFormat = "HH:mm:ss";
            this.dtpBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBatDau.Location = new System.Drawing.Point(553, 28);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(129, 26);
            this.dtpBatDau.TabIndex = 5;
            // 
            // txtNguoiPhat
            // 
            this.txtNguoiPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoiPhat.Location = new System.Drawing.Point(131, 220);
            this.txtNguoiPhat.Name = "txtNguoiPhat";
            this.txtNguoiPhat.Size = new System.Drawing.Size(186, 26);
            this.txtNguoiPhat.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Người phát";
            // 
            // btnOpenTextDien
            // 
            this.btnOpenTextDien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenTextDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenTextDien.Location = new System.Drawing.Point(794, 89);
            this.btnOpenTextDien.Name = "btnOpenTextDien";
            this.btnOpenTextDien.Size = new System.Drawing.Size(75, 31);
            this.btnOpenTextDien.TabIndex = 9;
            this.btnOpenTextDien.Text = "Mở file";
            this.btnOpenTextDien.UseVisualStyleBackColor = true;
            this.btnOpenTextDien.Click += new System.EventHandler(this.btnOpenTextDien_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(790, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nội dung điện";
            // 
            // chkPhatTuDong
            // 
            this.chkPhatTuDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPhatTuDong.AutoSize = true;
            this.chkPhatTuDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPhatTuDong.Location = new System.Drawing.Point(794, 149);
            this.chkPhatTuDong.Name = "chkPhatTuDong";
            this.chkPhatTuDong.Size = new System.Drawing.Size(119, 24);
            this.chkPhatTuDong.TabIndex = 10;
            this.chkPhatTuDong.Text = "Phát tự động";
            this.chkPhatTuDong.UseVisualStyleBackColor = true;
            // 
            // rtbNoiDungDien
            // 
            this.rtbNoiDungDien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNoiDungDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNoiDungDien.Location = new System.Drawing.Point(928, 28);
            this.rtbNoiDungDien.Name = "rtbNoiDungDien";
            this.rtbNoiDungDien.Size = new System.Drawing.Size(331, 218);
            this.rtbNoiDungDien.TabIndex = 8;
            this.rtbNoiDungDien.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(407, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Thời gian kết thúc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(407, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Thời gian bắt đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(409, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số lần phát";
            // 
            // txtSoLanPhat
            // 
            this.txtSoLanPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLanPhat.Location = new System.Drawing.Point(553, 147);
            this.txtSoLanPhat.Name = "txtSoLanPhat";
            this.txtSoLanPhat.Size = new System.Drawing.Size(129, 26);
            this.txtSoLanPhat.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số điện";
            // 
            // txtSoDien
            // 
            this.txtSoDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDien.Location = new System.Drawing.Point(131, 30);
            this.txtSoDien.Name = "txtSoDien";
            this.txtSoDien.Size = new System.Drawing.Size(186, 26);
            this.txtSoDien.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Controls.Add(this.btnPhatNgay);
            this.panel3.Controls.Add(this.btnHuy);
            this.panel3.Controls.Add(this.btnLuu);
            this.panel3.Controls.Add(this.btnBatHenPhat);
            this.panel3.Controls.Add(this.btnXoaBangDien);
            this.panel3.Controls.Add(this.btnSuaBangDien);
            this.panel3.Controls.Add(this.btnThemBangDien);
            this.panel3.Controls.Add(this.btnTatMayPhat);
            this.panel3.Controls.Add(this.btnBatMayPhat);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 269);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1271, 38);
            this.panel3.TabIndex = 0;
            // 
            // btnHuy
            // 
            this.btnHuy.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(660, 0);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 38);
            this.btnHuy.TabIndex = 16;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(585, 0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 38);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnBatHenPhat
            // 
            this.btnBatHenPhat.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBatHenPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatHenPhat.Location = new System.Drawing.Point(441, 0);
            this.btnBatHenPhat.Name = "btnBatHenPhat";
            this.btnBatHenPhat.Size = new System.Drawing.Size(144, 38);
            this.btnBatHenPhat.TabIndex = 14;
            this.btnBatHenPhat.Text = "Bật hẹn phát";
            this.btnBatHenPhat.UseVisualStyleBackColor = true;
            this.btnBatHenPhat.Click += new System.EventHandler(this.btnCapNhatBangDien_Click);
            // 
            // btnXoaBangDien
            // 
            this.btnXoaBangDien.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXoaBangDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaBangDien.Location = new System.Drawing.Point(290, 0);
            this.btnXoaBangDien.Name = "btnXoaBangDien";
            this.btnXoaBangDien.Size = new System.Drawing.Size(151, 38);
            this.btnXoaBangDien.TabIndex = 13;
            this.btnXoaBangDien.Text = "Xóa bảng điện";
            this.btnXoaBangDien.UseVisualStyleBackColor = true;
            this.btnXoaBangDien.Click += new System.EventHandler(this.btnXoaBangDien_Click);
            // 
            // btnSuaBangDien
            // 
            this.btnSuaBangDien.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSuaBangDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaBangDien.Location = new System.Drawing.Point(145, 0);
            this.btnSuaBangDien.Name = "btnSuaBangDien";
            this.btnSuaBangDien.Size = new System.Drawing.Size(145, 38);
            this.btnSuaBangDien.TabIndex = 12;
            this.btnSuaBangDien.Text = "Sửa bảng điện";
            this.btnSuaBangDien.UseVisualStyleBackColor = true;
            this.btnSuaBangDien.Click += new System.EventHandler(this.btnSuaBangDien_Click);
            // 
            // btnThemBangDien
            // 
            this.btnThemBangDien.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThemBangDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemBangDien.Location = new System.Drawing.Point(0, 0);
            this.btnThemBangDien.Name = "btnThemBangDien";
            this.btnThemBangDien.Size = new System.Drawing.Size(145, 38);
            this.btnThemBangDien.TabIndex = 11;
            this.btnThemBangDien.Text = "Thêm bảng điện";
            this.btnThemBangDien.UseVisualStyleBackColor = true;
            this.btnThemBangDien.Click += new System.EventHandler(this.btnThemBangDien_Click);
            // 
            // btnTatMayPhat
            // 
            this.btnTatMayPhat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTatMayPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTatMayPhat.Location = new System.Drawing.Point(1015, 0);
            this.btnTatMayPhat.Name = "btnTatMayPhat";
            this.btnTatMayPhat.Size = new System.Drawing.Size(136, 38);
            this.btnTatMayPhat.TabIndex = 17;
            this.btnTatMayPhat.Text = "Tắt máy phát";
            this.btnTatMayPhat.UseVisualStyleBackColor = true;
            this.btnTatMayPhat.Click += new System.EventHandler(this.btnTatMayPhat_Click);
            // 
            // btnBatMayPhat
            // 
            this.btnBatMayPhat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBatMayPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatMayPhat.Location = new System.Drawing.Point(1151, 0);
            this.btnBatMayPhat.Name = "btnBatMayPhat";
            this.btnBatMayPhat.Size = new System.Drawing.Size(120, 38);
            this.btnBatMayPhat.TabIndex = 18;
            this.btnBatMayPhat.Text = "Bật máy phát";
            this.btnBatMayPhat.UseVisualStyleBackColor = true;
            this.btnBatMayPhat.Click += new System.EventHandler(this.btnBatMayPhat_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvBangDien);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 331);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1271, 119);
            this.panel2.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnPhatNgay
            // 
            this.btnPhatNgay.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPhatNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhatNgay.Location = new System.Drawing.Point(735, 0);
            this.btnPhatNgay.Name = "btnPhatNgay";
            this.btnPhatNgay.Size = new System.Drawing.Size(144, 38);
            this.btnPhatNgay.TabIndex = 19;
            this.btnPhatNgay.Text = "Phát ngay";
            this.btnPhatNgay.UseVisualStyleBackColor = true;
            this.btnPhatNgay.Click += new System.EventHandler(this.btnPhatNgay_Click);
            // 
            // cấuHìnhMáyToolStripMenuItem
            // 
            this.cấuHìnhMáyToolStripMenuItem.Name = "cấuHìnhMáyToolStripMenuItem";
            this.cấuHìnhMáyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cấuHìnhMáyToolStripMenuItem.Text = "Cấu hình máy";
            this.cấuHìnhMáyToolStripMenuItem.Click += new System.EventHandler(this.cấuHìnhMáyToolStripMenuItem_Click);
            // 
            // frmBaoDien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmBaoDien";
            this.Text = "Báo điện";
            this.Load += new System.EventHandler(this.frmBaoDien_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDien)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBangDien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tùyChọnToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvBangDien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource bindingSourceBangDien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkPhatTuDong;
        private System.Windows.Forms.RichTextBox rtbNoiDungDien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoLanPhat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoDien;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBatHenPhat;
        private System.Windows.Forms.Button btnXoaBangDien;
        private System.Windows.Forms.Button btnSuaBangDien;
        private System.Windows.Forms.Button btnThemBangDien;
        private System.Windows.Forms.Button btnTatMayPhat;
        private System.Windows.Forms.Button btnBatMayPhat;
        private System.Windows.Forms.Button btnOpenTextDien;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.TextBox txtNguoiPhat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoNhom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.ComboBox cboDoKhan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDien;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoKhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLanPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioKetThuc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PhatTuDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiPhat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboMay;
        private System.Windows.Forms.Button btnPhatNgay;
        private System.Windows.Forms.ToolStripMenuItem cấuHìnhMáyToolStripMenuItem;
    }
}