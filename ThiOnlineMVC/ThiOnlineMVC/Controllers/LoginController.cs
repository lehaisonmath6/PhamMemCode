using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThiOnlineMVC;
using ThiOnlineMVC.Models;
using ThiOnlineMVC.Common;
namespace ThiOnlineMVC.Controllers
{
    public class LoginController : Controller
    {
        private ThiOnlineEntities db = new ThiOnlineEntities();


        public ActionResult Index()
        {
            return View();
        }
        // GET: Login
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = db.NguoiDungs.SingleOrDefault(n => n.TenDangNhap == loginModel.TenDangNhap && n.MatKhau == loginModel.MatKhau);
                if(user != null)
                {
                    NguoiDungLogin nguoiDungLogin = new NguoiDungLogin();
                    nguoiDungLogin.nguoiDung = user;
                    nguoiDungLogin.ThoiGianDangNhap = DateTime.Now;
                    Session.Add(CommonConstants.NGUOIDUNG_SESSION, nguoiDungLogin);
                    
                    // user is admin
                    if(user.IDVaiTro == 3)
                    {
                       return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    // user is supervisor
                    if(user.IDVaiTro == 2)
                    {
                        return RedirectToAction("Index", "GiamThi");
                    }
                    //  user is student
                    if(user.IDVaiTro == 1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("Index");
        }

       
    }
}
