using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThiOnlineMVC;

namespace ThiOnlineMVC.Areas.Admin.Controllers
{
    public class GiamThisController : Controller
    {
        private ThiOnlineEntities db = new ThiOnlineEntities();

        // GET: Admin/GiamThis
        public ActionResult Index()
        {
            var nguoiDungs = db.NguoiDungs.Where(n => n.IDVaiTro == 2);
            return View(nguoiDungs.ToList());
        }

        // GET: Admin/GiamThis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // GET: Admin/GiamThis/Create
        public ActionResult Create()
        {
            ViewBag.IDVaiTro = new SelectList(db.VaiTroes, "IDVaiTro", "TenVaiTro");
            return View();
        }

        // POST: Admin/GiamThis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNguoiDung,HoTen,NgaySinh,QueQuan,GioiTinh,SDT,Email,TenDangNhap,MatKhau,UrlAnh,IDVaiTro,MoRong")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(nguoiDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDVaiTro = new SelectList(db.VaiTroes, "IDVaiTro", "TenVaiTro", nguoiDung.IDVaiTro);
            return View(nguoiDung);
        }

        // GET: Admin/GiamThis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDVaiTro = new SelectList(db.VaiTroes, "IDVaiTro", "TenVaiTro", nguoiDung.IDVaiTro);
            return View(nguoiDung);
        }

        // POST: Admin/GiamThis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNguoiDung,HoTen,NgaySinh,QueQuan,GioiTinh,SDT,Email,TenDangNhap,MatKhau,UrlAnh,IDVaiTro,MoRong")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDVaiTro = new SelectList(db.VaiTroes, "IDVaiTro", "TenVaiTro", nguoiDung.IDVaiTro);
            return View(nguoiDung);
        }

        // GET: Admin/GiamThis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // POST: Admin/GiamThis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NguoiDung nguoiDung = db.NguoiDungs.Find(id);
            db.NguoiDungs.Remove(nguoiDung);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
