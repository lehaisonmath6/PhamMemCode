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

namespace TapHuanMorse
{
    public partial class frmCauHinhXacSuat : Form
    {
        Dictionary<char, float> proCharacter;
        public frmCauHinhXacSuat()
        {
            InitializeComponent();
            proCharacter = new Dictionary<char, float>();

        }

        Dictionary<char,float>  ParseConfigProb(string path)
        {
            try
            {
                var probChar = new Dictionary<char, float>();
                var text = File.ReadAllText(path);
                var mapProb = txtConfig.Text.Split(';');
                foreach (var w in mapProb)
                {
                    var maping = w.Split('=');
                    probChar.Add(maping[0][0], float.Parse(maping[1]));
                }
                return probChar;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText("configProb", txtConfig.Text);
            MessageBox.Show("Save ok");
        }
    }
}
