using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ThiOnlineMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Yêu cầu nhập tên đăng nhập")]
        public string TenDangNhap { get; set; }
        [Required(ErrorMessage ="Yêu cầu nhập mật khẩu")]
        public string MatKhau { get; set; }
        public bool NhoMatKhau { get; set; }
    }
}