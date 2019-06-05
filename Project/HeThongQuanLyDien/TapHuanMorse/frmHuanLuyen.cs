using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TapHuanMorse
{
    public partial class frmHuanLuyen : Form
    {
   
        Dictionary<char, int> numCharacter;
        Dictionary<string, string> mMorseTable;
        BlockingCollection<byte> fifo_queue;
        SerialPort serial;
        int timedot = 40;
        string BangDien;
        string BangDienHienThi;
        public frmHuanLuyen()
        {

            InitializeComponent();
            try
            {
                serial = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
                mMorseTable = new Dictionary<string, string>();
                numCharacter = new Dictionary<char, int>();
                LoadMorseTable();
                fifo_queue = new BlockingCollection<byte>();
                serial.ReadTimeout = 2000;
                serial.Open();
                serial.DataReceived += ReceviedData;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
           
           
        }
        void ReceviedData(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[serial.BytesToRead];
            serial.Read(buffer, 0, serial.BytesToRead);
            string converted = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
            rtbTienTrinh.Invoke((MethodInvoker)(() => rtbTienTrinh.Text += converted));
        }
        Dictionary<char, int> MapCharToNumber;
        void ParseConfig()
        {
            try
            {
                numCharacter = new Dictionary<char, int>();
                int tongsochu = 0;
                var listconfig = txtCauHinh.Text.Split(';');
                foreach(var config in listconfig)
                {
                    var keyvalue = config.Split('=');
                    numCharacter.Add(keyvalue[0][0], int.Parse(keyvalue[1]));
                    tongsochu += int.Parse(keyvalue[1]);
                }
                int sochutrungbinhconlai = (int.Parse(txtSoNhom.Text) * 5 - tongsochu) / (26 - listconfig.Length);
                char extrachar='z';
                for(char i = 'a';i<='z';i++)
                {
                    if (numCharacter.ContainsKey(i)) continue;
                    numCharacter.Add(i, sochutrungbinhconlai);
                    extrachar = i;
                    tongsochu += sochutrungbinhconlai;
                }
                int phanthua = int.Parse(txtSoNhom.Text) * 5 - tongsochu;
                numCharacter[extrachar] += phanthua;
                string sampleText = "";
                for(char i = 'a';i < 'z';i++)
                {
                    numCharacter[i] = numCharacter
                }
           
            }
            catch (Exception ex)
            {

            }
           
        }
        void ParseConfigProb(string textConfig)
        {
            try
            {
                probCharacter = new Dictionary<char, float>();
                int tong = 0;
                
                for (char i = 'a'; i <= 'z'; i++)
                {
                    probCharacter.Add(i, 0);
                }
                
                var mapProb = textConfig.Split(';');
                float sumProb = 0;
          
                foreach (var w in mapProb)
                {
                    var maping = w.Split('=');
                    probCharacter[maping[0][0]] = float.Parse(maping[1]);
                    sumProb += float.Parse(maping[1]);
                }
                  
                float rprob = (1 - sumProb) / (probCharacter.Count - mapProb.Length);
                for (char i = 'a';i <= 'z'; i++)
                {
                    if (probCharacter[i] == 0)
                    {
                        probCharacter[i] = rprob;
                    }
                    
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private static Random random = new Random();
        private static string GenerateNhomChu()
        {
            const string chars = "QWERTYUIOPASDFGHJKLZXCVBNM";
            return new string(Enumerable.Repeat(chars, 5).Select(n => n[random.Next(n.Length)]).ToArray());
        }
        private static string GenerateNhomSo()
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 5).Select(n => n[random.Next(n.Length)]).ToArray());
        }
        private static  string GenerateTableElect(int sonhom)
        {
            string rs = "";
            for (int i = 0; i < sonhom; i++)
            {
                rs += GenerateNhomChu() + " ";
            }
            rs = rs.Trim();
            return rs;
          
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
        private void btnSendMorse_Click(object sender, EventArgs e)
        {
            try
            {
                rtbTienTrinh.Text = "";
                
                string toSerial = "[vvv vvv = " + rtbBangDienPhat.Text.ToLower() +" +]";
                for(int i = 0;i < toSerial.Length; i++)
                {
                    serial.Write(toSerial[i].ToString());
                }
                
            }
            catch
            {
                MessageBox.Show("Send to serial error !");

            }
           

        }
        private void btnTaoBang_Click(object sender, EventArgs e)
        {
            int sonhom;
            if(! int.TryParse(txtSoNhom.Text, out sonhom))
            {
                MessageBox.Show("Nhập dữ liệu sai");
            }
            rtbBangDienPhat.Text = GenerateTableElect(sonhom);
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(rtbBangDienPhat.Text == "")
                {
                    MessageBox.Show("Không có gì để tính");
                    return;
                }
                var morsecode = TransFormMorse(rtbBangDienPhat.Text);
                int sodot = 0;
                for(int i = 0; i < morsecode.Length;i++)
                {
                    sodot += 1;
                    if(morsecode[i]=='.')
                    {
                        sodot += 1;
                    }
                    if(morsecode[i]=='-')
                    {
                        sodot += 3;
                    }
                    if(morsecode[i]==' ')
                    {
                        sodot += 2;
                    }
                    if(morsecode[i]=='/')
                    {
                        sodot += 5;
                    }
                }
                int chuperdot = sodot / rtbBangDienPhat.Text.Length;
                int sochuperphut = (int)txtTocDo.Value;
              
                timedot = 60000 / (sochuperphut * chuperdot) + 5;

                //MessageBox.Show("timedot : " + timedot.ToString());
                serial.Write("[v:" +timedot.ToString() + "]");
                
                serial.Write("[f:" + txtAmSac.Value.ToString() + "]");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }

       
    }
}
