using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Net.Sockets;
using System.Net;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HeThongQuanLyDien
{
    public partial class frmBaoDien : Form
    {
        Dictionary<string, string> mMorseTable;
        struct GioBatTatPhat
        {
           public  string SoDien;
           public  DateTime GioBatDau;
           public DateTime GioKetThuc;
        }

        List<GioBatTatPhat> danhsachphat; 
        enum TuyChon
        {
            Them,
            Sua,
            Xoa,
            Luu,
            Huy,
        }

        TuyChon tuyChon;

        List<tblBangDien> bangDienDatabase;
        List<tblMay> mayDatabase;
       

        public frmBaoDien()
        {
            InitializeComponent();
          
            dgvBangDien.DataSource = bindingSourceBangDien.DataSource;
            mMorseTable = new Dictionary<string, string>();
            LoadMorseTable();
            //danhsachphat = new List<GioBatTatPhat>();

        }



        private void LoadDanhSachPhat()
        {
            danhsachphat = new List<GioBatTatPhat>();
            foreach (var bd in bangDienDatabase)
            {
                if ( (bool)bd.PhatTuDong)
                {
                    GioBatTatPhat gioBatTatPhat = new GioBatTatPhat();
                    gioBatTatPhat.SoDien = bd.SoDien;
                    gioBatTatPhat.GioBatDau = DateTime.ParseExact(bd.GioBatDau, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    gioBatTatPhat.GioKetThuc = DateTime.ParseExact(bd.GioKetThuc, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    //MessageBox.Show(gioBatTatPhat.GioBatDau.Hour + ":" + gioBatTatPhat.GioBatDau.Minute + ":" + gioBatTatPhat.GioBatDau.Second);
                    danhsachphat.Add(gioBatTatPhat);
                }
            }
        }

        private void LoadMorseTable()
        {
            foreach (string k in ConfigurationManager.AppSettings.AllKeys)
            {
                if (k.Contains("morse_"))
                {
                    string val = ConfigurationManager.AppSettings[k];
                    mMorseTable.Add(k.Substring(6), val);
                }
            }
        }

        private string TranformToMorseCode(string text)
        {
            string output = "";
            foreach (char c in text)
            {
                if (c >= 'a' && c <= 'z')
                {
                    char upperC = (char)(c - 32);
                    output += mMorseTable[upperC.ToString()] + " ";
                }
                else if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z'))
                {
                    output += mMorseTable[c.ToString()] + " ";
                }
                else if (c == ' ')
                {
                    output += "/";
                }
            }
            return output;
        }


        private void SendDataSocket(string data,string ipadd)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(ipadd), int.Parse(ConfigurationManager.AppSettings["portremote"]));
            socket.Connect(iPEnd);
            byte[] buff = new byte[data.Length+2];
            buff = Encoding.ASCII.GetBytes(data);
            socket.Send(buff, data.Length, SocketFlags.None);
            socket.Close();
        }

        private void SendMorseData(object bangDien)
        {
            var bangDienP = (GioBatTatPhat)bangDien;
            tblBangDien bangDienT = bangDienDatabase.SingleOrDefault(n => n.SoDien == bangDienP.SoDien);
            string ipadd = mayDatabase.SingleOrDefault(n => n.IDMay == bangDienT.IDMay).IP;
           //MessageBox.Show("Send data of " + bangDienT.SoDien);
            try
            {
                SendDataSocket("B",ipadd);
                int solan = int.Parse(bangDienT.SoLanPhat);
                for (int i = 0; i < solan; i++)
                {
                    string morseCode = TranformToMorseCode(bangDienT.NoiDung);
                    SendDataSocket(morseCode,ipadd);
                }
                SendDataSocket("T",ipadd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void SendLenhTatMay(object sodien)
        {
            string sd = (string)sodien;
            int idmay = bangDienDatabase.SingleOrDefault(n => n.SoDien == sd).IDMay;
            string ip = mayDatabase.SingleOrDefault(n => n.IDMay == idmay).IP;
            try
            {
                SendDataSocket("T",ip);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
        }

        private void frmBaoDien_Load(object sender, EventArgs e)
        {
            ChiDoc();
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnXoaBangDien.Visible = true;
            btnSuaBangDien.Visible = true;
            btnThemBangDien.Visible = true;
            LoadDataBangDien();
            LoadDataMay();
            dgvBangDien.DataSource = bangDienDatabase;
            cboMay.DataSource = mayDatabase;
            cboMay.DisplayMember = "TenMay";
            cboMay.ValueMember = "IDMay";
            LoadDanhSachPhat();
        }

        void ThemDien()
        {
            tblBangDien bangDien = new tblBangDien();
            bangDien.SoDien = txtSoDien.Text;
            bangDien.SoNhom = txtSoNhom.Text;
            bangDien.NoiDung = rtbNoiDungDien.Text;
            bangDien.GioBatDau = dtpBatDau.Value.ToString("HH:mm:ss");
            bangDien.GioKetThuc = dtpKetThuc.Value.ToString("HH:mm:ss");
            bangDien.SoLanPhat = txtSoLanPhat.Text;
            bangDien.NguoiPhat = txtNguoiPhat.Text;
            bangDien.PhatTuDong = chkPhatTuDong.Checked;
            bangDien.DoKhan = cboDoKhan.Text;
            bangDien.IDMay = (int)cboMay.SelectedValue;
            bangDienDatabase.Add(bangDien);
            SaveDataBangDien();
        }

        void SuaDien()
        {
            tblBangDien bangDien = bangDienDatabase.SingleOrDefault(n => n.SoDien == txtSoDien.Text);
            bangDien.SoDien = txtSoDien.Text;
            bangDien.SoNhom = txtSoNhom.Text;
            bangDien.NoiDung = rtbNoiDungDien.Text;
            bangDien.GioBatDau = dtpBatDau.Value.ToString("HH:mm:ss");
            bangDien.GioKetThuc = dtpKetThuc.Value.ToString("HH:mm:ss");
            bangDien.SoLanPhat = txtSoLanPhat.Text;
            bangDien.NguoiPhat = txtNguoiPhat.Text;
            bangDien.PhatTuDong = chkPhatTuDong.Checked;
            bangDien.DoKhan = cboDoKhan.Text;
            bangDien.IDMay = (int)cboMay.SelectedValue;
            SaveDataBangDien();
        }

        private void btnTatMayPhat_Click(object sender, EventArgs e)
        {
           
            string ip = ConfigurationManager.AppSettings["ipremote"].ToString();

            try
            {
                SendDataSocket("T",ip);
                //MessageBox.Show("Tắt máy phát ok!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tắt máy phát thất bại");
                MessageBox.Show(ex.Message);
            }
        }

      
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtSoDien.Text=="" || txtSoNhom.Text=="" || txtSoLanPhat.Text == ""||txtNguoiPhat.Text =="" || rtbNoiDungDien.Text =="")
            {
                MessageBox.Show("Không được để trống một trường nào !");
                return;

            }
            int s;
            if (!int.TryParse(txtSoLanPhat.Text, out s))
            {
                MessageBox.Show("Sô lần phát phải là số ");
                return;
            }
            switch (tuyChon)
            {
                case TuyChon.Them:
                    ThemDien();
                    break;
                case TuyChon.Sua:
                    SuaDien();
                    break;
                case TuyChon.Huy:
                    break;
            }
            timer1.Stop();
            MessageBox.Show("Lưu thành công !, bộ hẹn phát mã đã tắt, yêu cầu bấm nút bật hẹn phát nếu muốn phát tự động ");
            frmBaoDien_Load(null, null);
        }

        private void btnCapNhatBangDien_Click(object sender, EventArgs e)
        {
            timer1.Start();
            MessageBox.Show("Bắt đầu bật bộ đếm thời gian");
        }

        private void btnXoaBangDien_Click(object sender, EventArgs e)
        {
            tuyChon = TuyChon.Xoa;
            if( MessageBox.Show("Bạn có chắc muốn xóa ? ","Xóa điện",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tblBangDien bangDien = bangDienDatabase.SingleOrDefault(n => n.SoDien == txtSoDien.Text);
                bangDienDatabase.Remove(bangDien);
                SaveDataBangDien();
            }
            
        }

        private void btnSuaBangDien_Click(object sender, EventArgs e)
        {
            ChoViet();
            tuyChon = TuyChon.Sua;
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnThemBangDien.Visible = false;
            btnXoaBangDien.Visible = false;
        }

        private void btnThemBangDien_Click(object sender, EventArgs e)
        {
            XoaTextBox();
            ChoViet();
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnXoaBangDien.Visible = false;
            btnSuaBangDien.Visible = false;
            tuyChon = TuyChon.Them;
        }


       

        private void btnOpenTextDien_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbNoiDungDien.Text = File.ReadAllText(openFileDialog1.FileName);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaTextBox();
            ChiDoc();
            btnThemBangDien.Visible = true;
            btnSuaBangDien.Visible = true;
            btnXoaBangDien.Visible = true;
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            tuyChon = TuyChon.Huy;

        }

        private void btnBatMayPhat_Click(object sender, EventArgs e)
        {

            string ip = ConfigurationManager.AppSettings["ipremote"].ToString();
            
            try
            {
                SendDataSocket("B",ip);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvBangDien_Click(object sender, EventArgs e)
        {
            var rowselected =  dgvBangDien.SelectedRows[0];
            txtSoDien.Text = rowselected.Cells["SoDien"].Value.ToString();
            txtSoNhom.Text = rowselected.Cells["SoNhom"].Value.ToString();
            DateTime t = DateTime.ParseExact(rowselected.Cells["GioBatDau"].Value.ToString(), "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            dtpBatDau.Value = t;
            t = DateTime.ParseExact(rowselected.Cells["GioKetThuc"].Value.ToString(), "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            dtpKetThuc.Value = t;
            txtSoLanPhat.Text = rowselected.Cells["SoLanPhat"].Value.ToString();
            rtbNoiDungDien.Text = rowselected.Cells["NoiDung"].Value.ToString();
            cboDoKhan.Text = rowselected.Cells["DoKhan"].Value.ToString();
            txtNguoiPhat.Text = rowselected.Cells["NguoiPhat"].Value.ToString();
            chkPhatTuDong.Checked = rowselected.Cells["PhatTuDong"].Value.ToString() == "True" ? true : false;
            cboMay.SelectedValue = rowselected.Cells["IDMay"].Value;
        }

        void XoaTextBox()
        {
            txtSoDien.Text = "";
            txtSoNhom.Text = "";
            txtNguoiPhat.Text = "";
            txtSoLanPhat.Text = "";
            rtbNoiDungDien.Text = "";
        }

        void ChiDoc()
        {
            txtSoDien.ReadOnly = true; 
            txtSoNhom.ReadOnly = true;
            txtNguoiPhat.ReadOnly = true;
            txtSoLanPhat.ReadOnly = true;
            rtbNoiDungDien.ReadOnly = true;
        }
        
        void ChoViet()
        {
            txtSoDien.ReadOnly = false;
            txtSoNhom.ReadOnly = false;
            txtNguoiPhat.ReadOnly = false;
            txtSoLanPhat.ReadOnly = false;
            rtbNoiDungDien.ReadOnly = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(var phat in danhsachphat)
            {

                if (DateTime.Now.Second == phat.GioBatDau.Second && DateTime.Now.Minute == phat.GioBatDau.Minute && DateTime.Now.Hour == phat.GioBatDau.Hour)
                {
                    Thread t = new Thread(SendMorseData);
                    t.Start(phat);
                }

                if (DateTime.Now.Second == phat.GioKetThuc.Second && DateTime.Now.Minute == phat.GioKetThuc.Minute && DateTime.Now.Hour == phat.GioKetThuc.Hour)
                {
                    Thread t = new Thread(SendLenhTatMay); 
                    t.Start(phat.SoDien);
                }

            }
        }

        public void LoadDataBangDien()
        {
            bangDienDatabase = new List<tblBangDien>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<tblBangDien>));
            using (FileStream stream = File.OpenRead("bangdiens.xml"))
            {
                bangDienDatabase = (List<tblBangDien>)serializer.Deserialize(stream);
            }
        }
        public void SaveDataBangDien()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<tblBangDien>));

            using (FileStream stream = File.Create("bangdiens.xml"))
            {
                serializer.Serialize(stream, bangDienDatabase);
            }
        }
        public void LoadDataMay()
        {
            mayDatabase = new List<tblMay>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<tblMay>));
            using (FileStream stream = File.OpenRead("mays.xml"))
            {
                mayDatabase = (List<tblMay>)serializer.Deserialize(stream);
            }
        }
        public void SaveDataMay()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<tblBangDien>));

            using (FileStream stream = File.Create("mays.xml"))
            {
                serializer.Serialize(stream, mayDatabase);
            }
        }

        private void btnPhatNgay_Click(object sender, EventArgs e)
        {
            List<tblBangDien> bangDiens = bangDienDatabase.Where(n => n.PhatTuDong == true).ToList();
            foreach (var phat in danhsachphat)
            {
                    Thread t = new Thread(SendMorseData);
                    t.Start(phat);

            }
            MessageBox.Show("Đã gửi tới các máy thu");
        }

        private void cấuHìnhMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyArdunio frmQuanLyArdunio = new frmQuanLyArdunio();
            frmQuanLyArdunio.ShowDialog();
            frmBaoDien_Load(null, null);
        }
    }
}
