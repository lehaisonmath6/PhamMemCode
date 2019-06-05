using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonVi
{
    public partial class Form1 : Form
    {
        enum CheckLenght
        {
            MAXLENGHT,
            OVERLENGHT,
            VALID,
        }
        public Form1()
        {
            InitializeComponent();
        }

        CheckLenght CheckTextLenght()
        {
            if (txtDisplay.Text.Length > 7)
            {
                txtDisplay.Text.Remove(6);
                txtDisplay.Text.Remove(7);
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            switch ( CheckTextLenght())
            {
                case CheckLenght.VALID :
                    txtDisplay.Text += "6";
                    break;
                case CheckLenght.OVERLENGHT:
                    break;
                case CheckLenght.MAXLENGHT:
                    txtDisplay.Text += "6";
                    txtDisplay.Text += "Khz";
                    break;
            }
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "3";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "7";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "0";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "5";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "4";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "9";
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "10";
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "11";
        }
    }
}
