using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSAApp
{
    public class RSAAlgorithm
    {
        public int p;
        public int q;
        public int n;
        public int lamda; // UCLN cua p-1, q-1;
        public int e;
        public int d;

        // UCLN
        private int GCD(int a, int h)
        {
            while (a != 0 && h != 0)
            {
                if (a > h)
                {
                    a %= h;
                }
                else
                {
                    h %= a;
                }
            }
            return a == 0 ? h : a;
        }

        // BCNN
        private int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }

        // Chon P , Q tai day nhe em
        public RSAAlgorithm(int p, int q)
        {
            this.p = p;
            this.q = q;
            this.n = this.p * this.q;
            lamda = LCM(this.p - 1, this.q - 1);
            e = 2;
            while (e < lamda)
            {
                if (GCD(e, lamda) == 1)
                {
                    break;
                }
                e++;
            }
            int k = 1;
            while (true)
            {
                if ((k * this.lamda + 1) % this.e == 0)
                {
                    break;
                }
                k++;
            }
            d = ((k * lamda + 1) / e);
        }
        // ma hoa ky tu
        private int EncryptChar(byte ch)
        {
            int msg = (int)ch;
            BigInteger c = BigInteger.Pow(msg, e);
            var rs = (int)(c % n);
            return rs;


        }

        // giai ma ky tu
        private int DecrypChar(byte ch)
        {
            int cipher = (int)ch;
            var m = BigInteger.Pow(cipher, d);
            var rs = (int)(m % n);
            return rs;

        }

        public int Encrypt(int m)
        {
            BigInteger c = BigInteger.Pow(m, e);
            return (int)(c % n);
        }

        public int Decrypt(int c)
        {
            var m = BigInteger.Pow(c, d);
            return (int)(m % n);
        }

        // ma hoa doan string
        public string Encrypt(string plaintxt)
        {
            string encryptData = "";


            byte[] plaintByte = Encoding.ASCII.GetBytes(plaintxt);
            byte[] encryptByte = new byte[plaintByte.Length];

            for (int i = 0; i < plaintByte.Length; i++)
            {
                encryptByte[i] = (byte)EncryptChar(plaintByte[i]);
            }
            var test = Encoding.ASCII.GetString(encryptByte, 0, encryptByte.Length);
            return test;
        }

        // giai ma doan string
        public string Decrypt(string ciphertxt)
        {
            string plaintxt = "";

            byte[] cipherbyte = Encoding.ASCII.GetBytes(ciphertxt);
            byte[] plaintbyte = new byte[cipherbyte.Length];
            for (int i = 0; i < cipherbyte.Length; i++)
            {
                plaintbyte[i] = (byte)DecrypChar(cipherbyte[i]);
            }
            return Encoding.ASCII.GetString(plaintbyte, 0, plaintbyte.Length);
        }
    }
}
