using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Management;
using System.Security.Cryptography;
using System.Text;
namespace Test
{
    [Serializable()]
    public class tblBangDien
    {
        public string SoDien { get; set; }
        public string SoNhom { get; set; }
        public string NoiDung { get; set; }
        public string DoKhan { get; set; }
        public string SoLanPhat { get; set; }
        public string GioBatDau { get; set; }
        public string GioKetThuc { get; set; }
        public Nullable<bool> PhatTuDong { get; set; }
        public string NguoiPhat { get; set; }
        public int IDMay { get; set; }
    }
    [Serializable()]
    public class tblMay
    {
        public int IDMay { get; set; }
        public string IP { get; set; }
        public string TenMay { get; set; }
    }


    class Program
    {
        public static string GetProcessorID()
        {
            string sProcessorID = "";
            string sQuery = "SELECT ProcessorId FROM Win32_Processor";
            ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);
            ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();
            foreach (ManagementObject oManagementObject in oCollection)
            {
                sProcessorID = (string)oManagementObject["ProcessorId"];
            }
            return sProcessorID;
        }


    public static string CreateSerialKey()
    {
        string str = GetProcessorID();
        StringBuilder builder = new StringBuilder();
        int num;
        for (int j = 0; j < 10; j = num + 1)
        {
            builder.Append(str);
            num = j;
        }
        str = builder.ToString();
        byte[] data = null;
        using (MD5 md5 = MD5.Create())
        {
            data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        }
        builder.Clear();
        for (int i = 0; i < 12; i += 3)
        {
            if (i != 0)
            {
                builder.Append("-");
            }
            builder.Append(data[i].ToString("X2"));
            builder.Append(data[i + 1].ToString("X2"));
            builder.Append(data[i + 2].ToString("X2"));
        }
        return builder.ToString();
    }
        private static string GetMd5Hash(byte[] data)
        {
            StringBuilder sBuilder = new StringBuilder();
            int num;
            for (int i = 0; i < data.Length; i = num + 1)
            {
                sBuilder.Append(data[i].ToString("x2"));
                num = i;
            }
            return sBuilder.ToString();
        }
        public static string CreateLicence(string serial)
        {
            return Hash(serial);
        }

        public static string Hash(string data)
        {
            using (MD5 md5 = MD5.Create())
            {
                return GetMd5Hash(md5.ComputeHash(Encoding.UTF8.GetBytes(data)));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetProcessorID());
            string key = CreateLicence(CreateSerialKey());
            Console.WriteLine(key);
            Console.ReadLine();
            
        }
    }
}
