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
    public class DoanVansController : Controller
    {
        private ThiOnlineEntities db = new ThiOnlineEntities();

        // GET: Admin/DoanVans
        public ActionResult Index()
        {
            var doanVans = db.DoanVans.Include(d => d.ChuongHoc);
            return View(doanVans.ToList());
        }

        // GET: Admin/DoanVans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanVan doanVan = db.DoanVans.Find(id);
            if (doanVan == null)
            {
                return HttpNotFound();
            }
            return View(doanVan);
        }

        // GET: Admin/DoanVans/Create
        public ActionResult Create(int? id)
        {
            if(id != null)
            {
                ViewBag.IDChuongHoc = new SelectList(db.ChuongHocs.Where(n => n.IDChuongHoc == id), "IDChuongHoc", "TenChuong");
            }
            else
            ViewBag.IDChuongHoc = new SelectList(db.ChuongHocs, "IDChuongHoc", "TenChuong");
            return View();
        }

        // POST: Admin/DoanVans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDoanVan,TenDoanVan,MoTa,IDChuongHoc")] DoanVan doanVan)
        {
            if (ModelState.IsValid)
            {
                db.DoanVans.Add(doanVan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDChuongHoc = new SelectList(db.ChuongHocs, "IDChuongHoc", "TenChuong", doanVan.IDChuongHoc);
            return View(doanVan);
        }

        // GET: Admin/DoanVans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanVan doanVan = db.DoanVans.Find(id);
            if (doanVan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDChuongHoc = new SelectList(db.ChuongHocs, "IDChuongHoc", "TenChuong", doanVan.IDChuongHoc);
            return View(doanVan);
        }

        // POST: Admin/DoanVans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDoanVan,TenDoanVan,MoTa,IDChuongHoc")] DoanVan doanVan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doanVan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDChuongHoc = new SelectList(db.ChuongHocs, "IDChuongHoc", "TenChuong", doanVan.IDChuongHoc);
            return View(doanVan);
        }

        // GET: Admin/DoanVans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoanVan doanVan = db.DoanVans.Find(id);
            if (doanVan == null)
            {
                return HttpNotFound();
            }
            return View(doanVan);
        }

        // POST: Admin/DoanVans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoanVan doanVan = db.DoanVans.Find(id);
            db.DoanVans.Remove(doanVan);
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
