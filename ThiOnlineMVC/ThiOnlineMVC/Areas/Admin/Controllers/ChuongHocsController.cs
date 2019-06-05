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
    public class ChuongHocsController : Controller
    {
        private ThiOnlineEntities db = new ThiOnlineEntities();

        // GET: Admin/ChuongHocs
        public ActionResult Index()
        {
            var chuongHocs = db.ChuongHocs.Include(c => c.MonHoc);
            return View(chuongHocs.ToList());
        }

        // GET: Admin/ChuongHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuongHoc chuongHoc = db.ChuongHocs.Find(id);
            if (chuongHoc == null)
            {
                return HttpNotFound();
            }
            return View(chuongHoc);
        }

        // GET: Admin/ChuongHocs/Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.IDMonHoc = new SelectList(db.MonHocs.Where(n => n.IDMonHoc == id), "IDMonHoc", "TenMonHoc");
            }
            else
                ViewBag.IDMonHoc = new SelectList(db.MonHocs, "IDMonHoc", "TenMonHoc");
            return View();
        }

        // POST: Admin/ChuongHocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDChuongHoc,TenChuong,MoTa,IDMonHoc")] ChuongHoc chuongHoc)
        {
            if (ModelState.IsValid)
            {
                db.ChuongHocs.Add(chuongHoc);
                DoanVan cauhoichuong = new DoanVan();
                cauhoichuong.TenDoanVan = "Câu hỏi chương";
                cauhoichuong.MoTa = "Các câu hỏi của chương đặt ở đây";
               
                db.SaveChanges();
                cauhoichuong.IDChuongHoc = chuongHoc.IDChuongHoc;
                db.DoanVans.Add(cauhoichuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMonHoc = new SelectList(db.MonHocs, "IDMonHoc", "TenMonHoc", chuongHoc.IDMonHoc);
            return View(chuongHoc);
        }

        // GET: Admin/ChuongHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuongHoc chuongHoc = db.ChuongHocs.Find(id);
            if (chuongHoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMonHoc = new SelectList(db.MonHocs, "IDMonHoc", "TenMonHoc", chuongHoc.IDMonHoc);
            return View(chuongHoc);
        }

        // POST: Admin/ChuongHocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDChuongHoc,TenChuong,MoTa,IDMonHoc")] ChuongHoc chuongHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuongHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMonHoc = new SelectList(db.MonHocs, "IDMonHoc", "TenMonHoc", chuongHoc.IDMonHoc);
            return View(chuongHoc);
        }

        // GET: Admin/ChuongHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuongHoc chuongHoc = db.ChuongHocs.Find(id);
            if (chuongHoc == null)
            {
                return HttpNotFound();
            }
            return View(chuongHoc);
        }

        // POST: Admin/ChuongHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuongHoc chuongHoc = db.ChuongHocs.Find(id);
            db.ChuongHocs.Remove(chuongHoc);
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
        class DoanVanJson
        {
            public int IDDoanVan { get; set; }
            public string TenDoanVan { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">IDChuongHoc</param>
        /// <returns></returns>
        public ActionResult GetDoanVanCombobox(int id)
        {
            var chuonghoc = db.ChuongHocs.Find(id);
            var chuonghocs = chuonghoc.DoanVans;
            List<DoanVanJson> doanVanJsons = (from obj in chuonghocs select new DoanVanJson { IDDoanVan = obj.IDDoanVan, TenDoanVan = obj.TenDoanVan }).ToList();
            return this.Json(doanVanJsons, JsonRequestBehavior.AllowGet);
        }
    }
}
