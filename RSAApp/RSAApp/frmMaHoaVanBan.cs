using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAApp
{
    public partial class frmMaHoaVanBan : Form
    {
        private RSAAlgorithm rSA;
        #region--variables area
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;
        #endregion
        public frmMaHoaVanBan()
        {
            InitializeComponent();
            rSA = new RSAAlgorithm(11, 13);
        }

        private void btnMaHoa_Click(object sender, EventArgs e)
        {
            //rtbBanMa.Text = rSA.Encrypt(rtbBanRo.Text);
            plaintext = Encoding.UTF8.GetBytes(rtbBanRo.Text);
            encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
            rtbBanMa.Text = Encoding.UTF8.GetString(encryptedtext);
        }
        #region-----Encryptionand Decryption Function-----
        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

        }
        #endregion

        private void btnGiaiMa_Click(object sender, EventArgs e)
        {
            //txtdecrypt.Text = rSA.Decrypt(txtencrypt.Text);
            byte[] decryptedtex = Decryption(encryptedtext, RSA.ExportParameters(true), false);
            rtbGiaiMa.Text = Encoding.UTF8.GetString(decryptedtex);
        }
    }
}
