using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThiOnlineMVC.Controllers
{
    public class GiamThiController : Controller
    {
        ThiOnlineEntities db = new ThiOnlineEntities();
        // GET: GiamThi
        public ActionResult Index()
        {
            var giamthi = Session[ThiOnlineMVC.Common.CommonConstants.NGUOIDUNG_SESSION] as Common.NguoiDungLogin;
            if (giamthi == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.IDKhoa = new SelectList(db.Khoas, "IDKhoa", "TenKhoa");
            ViewBag.IDKyThi = new SelectList(db.KyThis, "IDKyThi", "TenKyThi");
            return View();
        }

        [HttpPost]
        public ActionResult ChonMonThi(ThiOnlineMVC.Models.ChonMonThiModel chonMonThiModel)
        {
            var giamthi = Session[ThiOnlineMVC.Common.CommonConstants.NGUOIDUNG_SESSION] as Common.NguoiDungLogin;
            if (giamthi == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var listbaithi = db.BaiThis.Where(n => n.IDCaThi == chonMonThiModel.IDCaThi);
            return View(listbaithi);
            
        }
    }
}