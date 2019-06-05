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
    public class MonHocsController : Controller
    {
        private ThiOnlineEntities db = new ThiOnlineEntities();

        // GET: Admin/MonHocs
        public ActionResult Index()
        {
            var monHocs = db.MonHocs.Include(m => m.Khoa);
            return View(monHocs.ToList());
        }

        // GET: Admin/MonHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // GET: Admin/MonHocs/Create
        public ActionResult Create(int? id)
        {
            if(id != null)
            {
                ViewBag.IDKhoa = new SelectList( db.Khoas.Where(n => n.IDKhoa == id), "IDKhoa", "TenKhoa" );
            }
            else
            {
                ViewBag.IDKhoa = new SelectList(db.Khoas, "IDKhoa", "TenKhoa");
            }
           
            return View();
        }

        // POST: Admin/MonHocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenMonHoc,MoTa,IDKhoa")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.MonHocs.Add(monHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDKhoa = new SelectList(db.Khoas, "IDKhoa", "TenKhoa", monHoc.IDKhoa);
            return View(monHoc);
        }

        // GET: Admin/MonHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } 
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKhoa = new SelectList(db.Khoas, "IDKhoa", "TenKhoa", monHoc.IDKhoa);
            return View(monHoc);
        }

        // POST: Admin/MonHocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMonHoc,TenMonHoc,MoTa,IDKhoa")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDKhoa = new SelectList(db.Khoas, "IDKhoa", "TenKhoa", monHoc.IDKhoa);
            return View(monHoc);
        }

        // GET: Admin/MonHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // POST: Admin/MonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonHoc monHoc = db.MonHocs.Find(id);
            db.MonHocs.Remove(monHoc);
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

        class ChuongHocJson
        {
            public int IDChuongHoc { get; set; }
            public string TenChuong { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">IDMonHoc</param>
        /// <returns></returns>
        public ActionResult GetChuongHocCombobox(int id)
        {

            var monhoc = db.MonHocs.Find(id);
            var chuonghocs = monhoc.ChuongHocs;
            List<ChuongHocJson> chuongHocJsons = (from obj in chuonghocs  select new ChuongHocJson { IDChuongHoc = obj.IDChuongHoc, TenChuong = obj.TenChuong }).ToList();
            return this.Json(chuongHocJsons, JsonRequestBehavior.AllowGet);
        }
    }
}
