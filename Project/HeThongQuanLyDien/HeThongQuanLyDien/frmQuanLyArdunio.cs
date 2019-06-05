using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HeThongQuanLyDien
{
    public partial class frmQuanLyArdunio : Form
    {
        enum TuyChon
        {
            Them,
            Sua,
            Xoa,
            Luu,
            Huy,
        }

        TuyChon tuyChon;

        public frmQuanLyArdunio()
        {
            InitializeComponent();
        }
        List<tblMay> mayDatabase;
        public void LoadDataMay()
        {

            mayDatabase = new List<tblMay>();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<tblMay>));
                using (FileStream stream = File.OpenRead("mays.xml"))
                {
                    mayDatabase = (List<tblMay>)serializer.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
        }
        public void SaveDataMay()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<tblMay>));

           
            using (FileStream stream = File.Create("mays.xml"))
            {
                serializer.Serialize(stream, mayDatabase);
            }
        }
        private void frmQuanLyArdunio_Load(object sender, EventArgs e)
        {
            LoadDataMay();
            ChiDoc();
            cboDanhSachMay.DataSource = mayDatabase;
            cboDanhSachMay.DisplayMember = "TenMay";
            cboDanhSachMay.ValueMember = "IDMay";
        }

        private void cboDanhSachMay_Click(object sender, EventArgs e)
        {
            //txtIDMay.Text = cboDanhSachMay.SelectedValue.ToString();
            //int id = int.Parse(txtIDMay.Text);
            //tblMay may = mayDatabase.SingleOrDefault(n => n.IDMay == id);
            //txtTenMay.Text = may.TenMay;
            //txtDiaChi.Text = may.IP;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ChoViet();
            tuyChon = TuyChon.Sua;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaText();
            ChoViet();
            tuyChon = TuyChon.Them;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("delete item ","Delete item",MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                int id = int.Parse(txtIDMay.Text);
                tblMay may = mayDatabase.SingleOrDefault(n => n.IDMay == id);
                mayDatabase.Remove(may);
                SaveDataMay();
                MessageBox.Show("Delete item ok");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            switch (tuyChon)
            {
                case TuyChon.Them:
                    tblMay may = new tblMay { IDMay = int.Parse(txtIDMay.Text), IP = txtDiaChi.Text, TenMay = txtTenMay.Text };
                    mayDatabase.Add(may);
                    SaveDataMay();
                    break;
                case TuyChon.Sua:
                    int id = int.Parse(txtIDMay.Text);
                    tblMay may2 = mayDatabase.SingleOrDefault(n => n.IDMay == id);
                    if(may2 == null)
                    {
                        MessageBox.Show("Lỗi rồi");
                        return;
                    }
                    may2.IDMay = int.Parse(txtIDMay.Text);
                    may2.IP = txtDiaChi.Text;
                    may2.TenMay = txtTenMay.Text;
                    SaveDataMay();
                    break;
            }
            MessageBox.Show("OK");
            frmQuanLyArdunio_Load(null, null);


        }

        void XoaText()
        {
            txtDiaChi.Text = "";
            txtIDMay.Text = "";
            txtTenMay.Text = "";
        }
        void ChiDoc()
        {
            txtIDMay.ReadOnly = true;
            txtTenMay.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
        }
        void ChoViet()
        {
            txtIDMay.ReadOnly = false;
            txtTenMay.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
        }

        private void cboDanhSachMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDMay.Text = cboDanhSachMay.SelectedValue.ToString();
            try
            {
                int id = int.Parse(txtIDMay.Text);
                tblMay may = mayDatabase.SingleOrDefault(n => n.IDMay == id);
                txtTenMay.Text = may.TenMay;
                txtDiaChi.Text = may.IP;
            }
            catch
            {
                return;
            }
            
        }
    }
}
