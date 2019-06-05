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
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Xml.Serialization;
using System.Threading;

namespace HeThongQuanLyDien
{
    public partial class frmMorse : Form
    {
        Dictionary<string, string> mMorseTable;
        List<tblMay> mayDatabase;
        public frmMorse()
        {
            mMorseTable = new Dictionary<string, string>();
            InitializeComponent();
            LoadMorseTable();
            LoadDataMay();
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

        private void địnhNghĩaBảngMãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongSoMorse frm = new frmThongSoMorse();
            frm.ShowDialog();
        }

        private void thiếtLậpTầnSốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMorseTable frm = new frmMorseTable();
            frm.ShowDialog();
        }

        private void mởToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtVanBan.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                   
                }
            }
        }

        private string TransFormMorse(string text)
        {
            string morseResult = "";
            foreach (char c in text)
            {
                if (c >= 'a' && c <= 'z')
                {
                    char upperC = (char)(c - 32);
                    morseResult += mMorseTable[upperC.ToString()] + " ";
                }
                else if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z'))
                {
                    morseResult += mMorseTable[c.ToString()] + " ";
                }
                else if (c == ' ')
                {
                    morseResult += "/";
                }
            }
            return morseResult;
        } 
        private void btnTransform_Click(object sender, EventArgs e)
        {
            
            
        }
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
        string morseText ="";
        private void btnPhat_Click(object sender, EventArgs e)
        {
            var morseText = TransFormMorse(txtVanBan.Text);
            foreach (tblMay may in mayDatabase)
            {
                Thread thread = new Thread(SendDataSocket);
                thread.Start(may.IP);
            }
            //SerialPort serial = new SerialPort("COM1", 9600);
            //serial.Open();
            //try
            //{
            //    foreach (char c in rtbMaMorse.Text)
            //    {
            //        serial.Write(c.ToString());
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Send to serial error !");
            //}
        }
        private void SendDataSocket(object ip)
        {
            string ips = (string)ip;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(ips.ToString()), int.Parse(ConfigurationManager.AppSettings["portremote"]));
            try
            {
               
                socket.Connect(iPEnd);
                byte[] buff = new byte[morseText.Length + 2];
                buff = Encoding.ASCII.GetBytes(morseText);
                socket.Send(buff, morseText.Length, SocketFlags.None);
               
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                socket.Close();
            }
           
        }

        private void btnPhatTin_Click(object sender, EventArgs e)
        {

           
            morseText =  TransFormMorse(txtVanBan.Text);
            SendDataSocket("169.254.32.133");
        }
    }
}