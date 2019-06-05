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
    public partial class frmMaHoaSo : Form
    {
        public frmMaHoaSo()
        {
            InitializeComponent();
        }
        RSAAlgorithm rSA;
        public  bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
        private void btnMaHoa_Click(object sender, EventArgs e)
        {


            try
            {
                int m;
                if(txtM.Text.Length==1 && 'a'<= txtM.Text[0] && txtM.Text[0] <= 'z')
                {
                    m = (int)(txtM.Text[0]);   
                }
                else
                {
                    m = int.Parse(txtM.Text);
                }
                int p = int.Parse(txtP.Text);
                int q = int.Parse(txtQ.Text);

                

                

                if (!IsPrime(p) || !IsPrime(q))
                {
                    MessageBox.Show("P và Q phải là số nguyên tố");
                    return;
                }
                rSA = new RSAAlgorithm(p, q);
                txtC.Text  = rSA.Encrypt(m).ToString();
                
            }
            catch(Exception ex)
            {
                
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnGiaiMa_Click(object sender, EventArgs e)
        {
            try
            {
                int c = int.Parse(txtC.Text);
                var h = rSA.Decrypt(c);
                if (txtM.Text.Length == 1 && 'a' <= txtM.Text[0] && txtM.Text[0] <= 'z')
                {
                    txtGiaiMa.Text = ((char)h).ToString();
                }
                else
                {
                    txtGiaiMa.Text = h.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
