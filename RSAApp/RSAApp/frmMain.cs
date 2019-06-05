using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSo_Click(object sender, EventArgs e)
        {
            frmMaHoaSo frm = new frmMaHoaSo();
            frm.ShowDialog();
        }

        private void btnVanBan_Click(object sender, EventArgs e)
        {
            frmMaHoaVanBan frm = new frmMaHoaVanBan();
            frm.ShowDialog();
        }
    }
}
