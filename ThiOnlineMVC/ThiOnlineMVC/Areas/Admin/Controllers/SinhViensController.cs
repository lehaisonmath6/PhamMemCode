using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThiOnlineMVC;
using ThiOnlineMVC.Areas.Admin.Models;
namespace ThiOnlineMVC.Areas.Admin.Controllers
{
    public class SinhViensController : Controller
    {
        private ThiOnlineEntities db = new ThiOnlineEntities();

        // GET: Admin/SinhViens
        public ActionResult Index()
        {
            var nguoiDungs = db.NguoiDungs.Where(n => n.IDVaiTro == 1);
            return View(nguoiDungs.ToList());
        }

        // GET: Admin/SinhViens/Details/5
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

        // GET: Admin/SinhViens/Create
        public ActionResult Create()
        {
            //ViewBag.IDVaiTro = new SelectList(db.VaiTroes, "IDVaiTro", "TenVaiTro");
            return View();
        }

        // POST: Admin/SinhViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HoTen,NgaySinh,QueQuan,GioiTinh,SDT,Email,TenDangNhap,MatKhau,UrlAnh,MoRong")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                nguoiDung.IDVaiTro = 1;
                db.NguoiDungs.Add(nguoiDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguoiDung);
        }

        // GET: Admin/SinhViens/Edit/5
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
           
            return View(nguoiDung);
        }

        // POST: Admin/SinhViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNguoiDung,HoTen,NgaySinh,QueQuan,TenDangNhap,MatKhau")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                nguoiDung.IDVaiTro = 1;
                db.Entry(nguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(nguoiDung);
        }

        // GET: Admin/SinhViens/Delete/5
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

        // POST: Admin/SinhViens/Delete/5
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
