using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyDien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBaoDien_Click(object sender, EventArgs e)
        {
            frmBaoDien frm = new frmBaoDien();
            frm.ShowDialog();
        }

        private void btnMaMorse_Click(object sender, EventArgs e)
        {
            frmMorse frm = new frmMorse();
            frm.Show();
        }

        private void btnDieuKhienTanSo_Click(object sender, EventArgs e)
        {
            frmQuanLyDien frm = new frmQuanLyDien();
            frm.Show();
        }
    }
}
