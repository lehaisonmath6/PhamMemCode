using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiOnlineMVC.Common
{
    [Serializable]
    public class NguoiDungLogin
    {
        public NguoiDung nguoiDung { get; set; }
        public DateTime ThoiGianDangNhap { get; set; }
        
    }
}