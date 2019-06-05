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
    public class CauHoisController : Controller
    {
        private ThiOnlineEntities db = new ThiOnlineEntities();
        public class ChonDapAn
        {
            public string IDChon { get; set; }
            public string Chon { get; set; }
        }
        private List<ChonDapAn> dapans = new List<ChonDapAn> {
            new ChonDapAn {IDChon ="A",Chon="A" } ,
            new ChonDapAn { IDChon = "B" ,Chon = "B"},
            new ChonDapAn {IDChon = "C",Chon = "C"},
            new ChonDapAn {IDChon = "D",Chon = "D"},
        };
        // GET: Admin/CauHois
        public ActionResult Index(int? id)
        {
            if(id != null)
            {
                var cauhoi = db.CauHois.Find(id);
                return View(cauhoi);
            }
            if(db.CauHois.Count() >= 1)
            {
                var cauhoi2 = db.CauHois.First();
                return View(cauhoi2);
            }
            return View(new CauHoi());
           
        }

        // GET: Admin/CauHois/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHoi cauHoi = db.CauHois.Find(id);
            if (cauHoi == null)
            {
                return HttpNotFound();
            }
            return View(cauHoi);
        }

        // GET: Admin/CauHois/Create
        public ActionResult Create(int? id)
        {
            if(id != null)
            {
                ViewBag.IDDoanVan = new SelectList(db.DoanVans.Where(n => n.IDDoanVan == id), "IDDoanVan", "TenDoanVan");
            }
            else
            ViewBag.IDDoanVan = new SelectList(db.DoanVans, "IDDoanVan", "TenDoanVan");
            ViewBag.DapAn = new SelectList(dapans, "IDChon", "Chon");
            ViewBag.IDDoKho = new SelectList(db.DoKhoes, "IDDoKho", "TenDoKho");
            return View();
        }

        // POST: Admin/CauHois/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCauHoi,TenCauHoi,MoTa,DapAn,TracNghiemA,TracNghiemB,TracNghiemC,TracNghiemD,IDDoanVan,IDDoKho")] CauHoi cauHoi)
        {
            if (ModelState.IsValid)
            {
                
                db.CauHois.Add(cauHoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.IDDoanVan = new SelectList(db.DoanVans, "IDDoanVan", "TenDoanVan", cauHoi.IDDoanVan);
            ViewBag.DapAn = new SelectList(dapans, "IDChon", "Chon");
            return View(cauHoi);
        }

        // GET: Admin/CauHois/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHoi cauHoi = db.CauHois.Find(id);
            if (cauHoi == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDoanVan = new SelectList(db.DoanVans, "IDDoanVan", "TenDoanVan", cauHoi.IDDoanVan);
            ViewBag.DapAn = new SelectList(dapans, "IDChon", "Chon");
            ViewBag.IDDoKho = new SelectList(db.DoKhoes, "IDDoKho", "TenDoKho");
            return View(cauHoi);
        }

        // POST: Admin/CauHois/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCauHoi,TenCauHoi,MoTa,DapAn,TracNghiemA,TracNghiemB,TracNghiemC,TracNghiemD,IDDoanVan")] CauHoi cauHoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cauHoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDoanVan = new SelectList(db.DoanVans, "IDDoanVan", "TenDoanVan", cauHoi.IDDoanVan);
            return View(cauHoi);
        }

        // GET: Admin/CauHois/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHoi cauHoi = db.CauHois.Find(id);
            if (cauHoi == null)
            {
                return HttpNotFound();
            }
            return View(cauHoi);
        }

        // POST: Admin/CauHois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CauHoi cauHoi = db.CauHois.Find(id);
            db.CauHois.Remove(cauHoi);
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
