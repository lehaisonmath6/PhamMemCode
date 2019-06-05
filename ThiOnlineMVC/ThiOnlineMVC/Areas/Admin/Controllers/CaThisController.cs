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
    public class CaThisController : Controller
    {
        private ThiOnlineEntities db = new ThiOnlineEntities();

        // GET: Admin/CaThis
        public ActionResult Index()
        {
            return View(db.CaThis.ToList());
        }

        // GET: Admin/CaThis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaThi caThi = db.CaThis.Find(id);
            if (caThi == null)
            {
                return HttpNotFound();
            }
            return View(caThi);
        }

        // GET: Admin/CaThis/Create
        public ActionResult Create()
        {
            ViewBag.IDKyThi = new SelectList(db.KyThis, "IDKyThi", "TenKyThi");
            return View();
        }

        // POST: Admin/CaThis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenCa,MoTa,ThoiGianBatDau,ThoiGianKetThuc,IDKyThi")] CaThi caThi)
        {
            if (ModelState.IsValid)
            {
                db.CaThis.Add(caThi);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            ViewBag.IDKyThi = new SelectList(db.KyThis, "IDKyThi", "TenKyThi", caThi.IDKyThi);
            return View(caThi);
        }

        // GET: Admin/CaThis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CaThi caThi = db.CaThis.Find(id);
            if (caThi == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKyThi = new SelectList(db.KyThis, "IDKyThi", "TenKyThi", caThi.IDKyThi);
            return View(caThi);
        }

        // POST: Admin/CaThis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCa,TenCa,MoTa,ThoiGianBatDau,ThoiGianKetThuc,IDKyThi")] CaThi caThi)
        {
            ViewBag.IDKyThi = new SelectList(db.KyThis, "IDKyThi", "TenKyThi", caThi.IDKyThi);
            if (ModelState.IsValid)
            {
                db.Entry(caThi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caThi);
        }

        // GET: Admin/CaThis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaThi caThi = db.CaThis.Find(id);
            if (caThi == null)
            {
                return HttpNotFound();
            }
            return View(caThi);
        }

        // POST: Admin/CaThis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaThi caThi = db.CaThis.Find(id);
            db.CaThis.Remove(caThi);
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
