using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyDien
{
    public partial class frmQuanLyDien : Form
    {
        public frmQuanLyDien()
        {
            InitializeComponent();
            txtIP.Text = ConfigurationManager.AppSettings["hostremote"];
        }
        string concatString = "";
        int maxLenght = 4;
        private void btn5_Click(object sender, EventArgs e)
        {
            if( concatString.Length > maxLenght)
            {
                MessageBox.Show("Độ dài không được vượt quá " + maxLenght.ToString());
                return;
            }
            concatString += "5";
            
            txtHienThi.Text = concatString + "Khz";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (concatString.Length > maxLenght)
            {
                MessageBox.Show("Độ dài không được vượt quá " + maxLenght.ToString());
                return;
            }
            concatString += "0";
            txtHienThi.Text =  concatString + "Khz";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (concatString.Length > maxLenght)
            {
                MessageBox.Show("Độ dài không được vượt quá " + maxLenght.ToString());
                return;
            }
            concatString += "1";
            txtHienThi.Text = concatString + "Khz";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (concatString.Length > maxLenght)
            {
                MessageBox.Show("Độ dài không được vượt quá " + maxLenght.ToString());
                return;
            }
            concatString += "2";
            txtHienThi.Text = concatString+"Khz";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (concatString.Length > maxLenght)
            {
                MessageBox.Show("Độ dài không được vượt quá " + maxLenght.ToString());
                return;
            }
            concatString += "3";
            txtHienThi.Text =concatString +"Khz";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (concatString.Length > maxLenght)
            {
                MessageBox.Show("Độ dài không được vượt quá " + maxLenght.ToString());
                return;
            }
            concatString += "7";
            txtHienThi.Text = concatString + "Khz";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (concatString.Length > maxLenght)
            {
                MessageBox.Show("Độ dài không được vượt quá " + maxLenght.ToString());
                return;
            }
            concatString += "6";
            txtHienThi.Text = concatString +"Khz";
        }

        private void btnTX_Click(object sender, EventArgs e)
        {
           
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (concatString.Length > maxLenght)
            {
                MessageBox.Show("Độ dài không được vượt quá " + maxLenght.ToString());
                return;
            }
            concatString += "4";
            txtHienThi.Text = concatString +"Khz";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (concatString.Length > maxLenght)
            {
                MessageBox.Show("Độ dài không được vượt quá " + maxLenght.ToString());
                return;
            }
            concatString += "8";
            txtHienThi.Text = concatString + "Khz";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (concatString.Length > maxLenght)
            {
                MessageBox.Show("Độ dài không được vượt quá " + maxLenght.ToString());
                return;
            }
            concatString += "9";
            txtHienThi.Text = concatString +"Khz";
        }

        private void btnRX_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            concatString = concatString.Insert(2, ".");
            MessageBox.Show("DataSend : " + concatString);
            SendDataSocket(concatString);
        }

        private void btnTune_Click(object sender, EventArgs e)
        {

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            concatString = "";
            txtHienThi.Text = "Khz";
        }
        private void SendDataSocket(string data)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(txtIP.Text), int.Parse(ConfigurationManager.AppSettings["portremote"]));
            try
            {
                
                socket.Connect(iPEnd);
                byte[] buff = new byte[data.Length + 2];
                buff = Encoding.ASCII.GetBytes(data);
                socket.Send(buff, data.Length, SocketFlags.None);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                socket.Close();
            }

        }
    }
}
