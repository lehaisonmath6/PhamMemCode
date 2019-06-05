using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThiOnlineMVC.Models;
namespace ThiOnlineMVC.Controllers
{
    public class HomeController : Controller
    {
        public ThiOnlineEntities db = new ThiOnlineEntities();
        
        public ActionResult Index()
        {
            var sinhvien = Session[Common.CommonConstants.NGUOIDUNG_SESSION] as Common.NguoiDungLogin;
            if(sinhvien == null)
            {
                return RedirectToAction("Index", "Login");
            }
            
            return View(sinhvien.nguoiDung);
        }

        public ActionResult DangXuat()
        {
            Session.Remove(ThiOnlineMVC.Common.CommonConstants.NGUOIDUNG_SESSION);
            return RedirectToAction("Index","Login");
        }
        public ActionResult ChonMonThi()
        {
            var sinhvien = Session[ThiOnlineMVC.Common.CommonConstants.NGUOIDUNG_SESSION] as Common.NguoiDungLogin;
            if(sinhvien == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.IDKhoa = new SelectList(db.Khoas, "IDKhoa", "TenKhoa");
            ViewBag.IDKyThi = new SelectList(db.KyThis, "IDKyThi", "TenKyThi");

            return View();
        }

        [HttpPost]
        public ActionResult ChonMonThi(ChonMonThiModel model)
        {
            var sinhvien = Session[ThiOnlineMVC.Common.CommonConstants.NGUOIDUNG_SESSION] as Common.NguoiDungLogin;
            if (sinhvien == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<DeThi> deThis = db.DeThis.Where(n => n.IDMonHoc == model.IDMonHoc).ToList();
            if(deThis == null)
            {
                return View();
            }
            var ran = new Random();
            int index = ran.Next(deThis.Count);
            BaiThi baiThi = db.BaiThis.SingleOrDefault(n => n.IDNguoiDung == sinhvien.nguoiDung.IDNguoiDung && n.IDCaThi == model.IDCaThi && model.IDMonHoc == model.IDMonHoc);
            if(baiThi != null)
            {
                return View("ThongBaoDathi");
            }
            DeThiModel deThi = new DeThiModel();
            int selectidde = deThis[index].IDDeThi;
            List<int> idcauhois = db.DeThi_CauHoi.Where(n => n.IDDeThi == selectidde).Select(n => n.IDCauHoi).ToList();
            deThi.deThi = deThis[index];
            deThi.idCauHois = idcauhois;
           
            return View("TrangThi",deThi);
        }

        [HttpGet]
        public ActionResult TrangThi(DeThiModel deThiModel)
        {
            var sinhvien = Session[ThiOnlineMVC.Common.CommonConstants.NGUOIDUNG_SESSION] as Common.NguoiDungLogin;
            if (sinhvien == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.DeThi = deThiModel.deThi;
            return View(deThiModel);
        }

        [HttpPost]
        public ActionResult TrangThi(List<BaiThiModel> baiThiModels)
        {
            
            var sinhvien = Session[ThiOnlineMVC.Common.CommonConstants.NGUOIDUNG_SESSION] as Common.NguoiDungLogin;
            if (sinhvien == null)
            {
                return RedirectToAction("Index", "Login");
            }
            
            BaiThi baiThi = new BaiThi();
            baiThi.IDDeThi = baiThiModels[0].IDDeThi;
            baiThi.IDCaThi = baiThiModels[0].IDCaThi;
            baiThi.IDNguoiDung = sinhvien.nguoiDung.IDNguoiDung;
            baiThi.TongSoCau = baiThiModels.Count;
            baiThi.ThoiGianNopBai = DateTime.Now;
            db.BaiThis.Add(baiThi);
            db.SaveChanges();
            int socaudung = 0;
            foreach (BaiThiModel bailam in baiThiModels)
            {
                var cauhoigoc = db.CauHois.SingleOrDefault(n => n.IDCauHoi == bailam.IDCauHoi);
                BaiThi_DapAn thi_DapAn = new BaiThi_DapAn();
                thi_DapAn.IDBaiThi = baiThi.IDBaiThi;
                thi_DapAn.IDCauHoi = cauhoigoc.IDCauHoi;
                thi_DapAn.DapAn = cauhoigoc.DapAn;
                thi_DapAn.TraLoi = bailam.CauTraLoi;
                db.BaiThi_DapAn.Add(thi_DapAn);
                if (cauhoigoc.DapAn == bailam.CauTraLoi)
                {
                    socaudung++;
                }
            }
            baiThi.SoCauDung = socaudung;
            db.SaveChanges();
            return Json(Url.Action("TrangKetQua", "Home", new { id = baiThi.IDBaiThi }));
        }

        [HttpGet]
        public ActionResult TrangKetQua(int? id)
        {
            var sinhvien = Session[ThiOnlineMVC.Common.CommonConstants.NGUOIDUNG_SESSION] as Common.NguoiDungLogin;
            if (sinhvien == null)
            {
                return RedirectToAction("Index", "Login");
            }

            BaiThi baiThi = db.BaiThis.SingleOrDefault(n => n.IDBaiThi == id);

            
            return View(baiThi);

        }


        
   
    }
}