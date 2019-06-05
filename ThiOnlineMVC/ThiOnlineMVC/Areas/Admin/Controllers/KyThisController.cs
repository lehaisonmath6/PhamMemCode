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
    public class KyThisController : Controller
    {
        private ThiOnlineEntities db = new ThiOnlineEntities();

        // GET: Admin/KyThis
        public ActionResult Index()
        {
            return View(db.KyThis.ToList());
        }

        // GET: Admin/KyThis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KyThi kyThi = db.KyThis.Find(id);
            if (kyThi == null)
            {
                return HttpNotFound();
            }
            return View(kyThi);
        }

        // GET: Admin/KyThis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KyThis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenKyThi,MoTa,NgayBatDau,NgayKetThuc")] KyThi kyThi)
        {
            if (ModelState.IsValid)
            {
                db.KyThis.Add(kyThi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kyThi);
        }

        // GET: Admin/KyThis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KyThi kyThi = db.KyThis.Find(id);
            if (kyThi == null)
            {
                return HttpNotFound();
            }
            return View(kyThi);
        }

        // POST: Admin/KyThis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDKyThi,TenKyThi,MoTa")] KyThi kyThi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kyThi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kyThi);
        }

        // GET: Admin/KyThis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KyThi kyThi = db.KyThis.Find(id);
            if (kyThi == null)
            {
                return HttpNotFound();
            }
            return View(kyThi);
        }

        // POST: Admin/KyThis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KyThi kyThi = db.KyThis.Find(id);
            db.KyThis.Remove(kyThi);
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
        class CaThiJson
        {
            public int IDCa { get; set; }
            public string TenCa { get; set; }
        }
        public ActionResult GetCaThiCombobox(int id)
        {

            var kythi = db.KyThis.Find(id);
            var cathi = kythi.CaThis;
            List<CaThiJson> caThiJsons = (from obj in cathi select new CaThiJson { IDCa = obj.IDCa, TenCa = obj.TenCa }).ToList();
            return this.Json(caThiJsons, JsonRequestBehavior.AllowGet);
        }
    }
}
