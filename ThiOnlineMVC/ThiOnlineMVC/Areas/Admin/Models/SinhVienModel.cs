using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiOnlineMVC.Areas.Admin.Models
{
    public class SinhVienModel
    {
        public int IDNguoiDung { get; set; }
        public string HoTen { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public Nullable<bool> GioiTinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string UrlAnh { get; set; }
        public Nullable<bool> DuocPhepThi { get; set; }
    }
}