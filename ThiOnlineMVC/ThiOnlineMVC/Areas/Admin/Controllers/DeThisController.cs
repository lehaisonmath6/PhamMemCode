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
    public class DeThisController : Controller
    {
        private ThiOnlineEntities db = new ThiOnlineEntities();

        // GET: Admin/DeThis
        public ActionResult Index()
        {
            var deThis = db.DeThis.Include(d => d.CaThi);
            return View(deThis.ToList());
        }

        // GET: Admin/DeThis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeThi deThi = db.DeThis.Find(id);
           
            if (deThi == null)
            {
                return HttpNotFound();
            }
            return View(deThi);
        }

        // GET: Admin/DeThis/Create
        public ActionResult Create()
        {
            //ViewBag.IDCaThi = new SelectList(db.CaThis, "IDCa", "TenCa");
            ViewBag.IDMonHoc = new SelectList(db.MonHocs, "IDMonHoc", "TenMonHoc");
            return View();
        }

        // POST: Admin/DeThis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMonHoc,MoTa,ThoiGian,TenDe,IDCaThi,ThoiGian,DSIDCauHoi")] DeThiModel deThiModel)
        {
            
            if (ModelState.IsValid)
            {
                DeThi deThi = new DeThi { IDMonHoc = deThiModel.IDMonHoc, IDCaThi = deThiModel.IDCaThi, MoTa = deThiModel.MoTa, TenDe = deThiModel.TenDe , ThoiGian = deThiModel.ThoiGian };
                db.DeThis.Add(deThi);
                db.SaveChanges();
                string[] idcauhois = deThiModel.DSIDCauHoi.Split(';');
                for(int i=0;i<idcauhois.Length-1;i++)
                {
                    int id = int.Parse(idcauhois[i]);
                    
                    DeThi_CauHoi deThi_CauHoi = new DeThi_CauHoi { IDDeThi = deThi.IDDeThi, IDCauHoi = id };
                    db.DeThi_CauHoi.Add(deThi_CauHoi);
                }
                db.SaveChanges();
               
                return RedirectToAction("Index");
            }

            //ViewBag.IDCaThi = new SelectList(db.CaThis, "IDCa", "TenCa", deThiModel.IDCaThi);
            ViewBag.IDMonHoc = new SelectList(db.MonHocs, "IDMonHoc", "TenMonHoc",deThiModel.IDMonHoc);
            return View(deThiModel);
        }

        // GET: Admin/DeThis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeThi deThi = db.DeThis.Find(id);
           
            if (deThi == null)
            {
                return HttpNotFound();
            }
            List<int> listcauhoi = db.DeThi_CauHoi.Where(n => n.IDDeThi == id).Select(n => n.IDCauHoi).ToList();
            ViewBag.IDDanhSachThi = listcauhoi;
            //List<string> lscauhois = (from cauhoi in listcauhoi select cauhoi.ToString()).ToList();
            var sds = String.Join(";", listcauhoi) +";";

            DeThiModel deThiModel = new DeThiModel
            {
                IDDeThi = deThi.IDDeThi,
                IDCaThi = deThi.IDCaThi,
                IDMonHoc = deThi.IDMonHoc,
                MoTa = deThi.MoTa,
                TenDe = deThi.TenDe,
                ThoiGian = deThi.ThoiGian,
                DSIDCauHoi = sds,
            };

            return View(deThiModel);
        }

        // POST: Admin/DeThis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDeThi,IDMonHoc,MoTa,ThoiGian,TenDe,IDCaThi,DSIDCauHoi")] DeThiModel deThimodel)
        {
            var deThi = db.DeThis.Find(deThimodel.IDDeThi);
            List<int> listcauhoi = db.DeThi_CauHoi.Where(n => n.IDDeThi == deThi.IDDeThi).Select(n => n.IDCauHoi).ToList();
            if (ModelState.IsValid)
            {
               
                deThi.MoTa = deThimodel.MoTa;
                deThi.TenDe = deThimodel.TenDe;
                deThi.ThoiGian = deThimodel.ThoiGian;
                db.Entry(deThi).State = EntityState.Modified;
                db.SaveChanges();
                string[] idcauhois = deThimodel.DSIDCauHoi.Split(';');
                List<int> listidnew = new List<int>();
                for (int i = 0; i < idcauhois.Length - 1; i++)
                {
                    int id;
                    if( !int.TryParse(idcauhois[i], out id)){
                        continue;
                    }
                    
                    listidnew.Add(id);
                    var olddethi = db.DeThi_CauHoi.SingleOrDefault(n => n.IDDeThi == deThimodel.IDDeThi && n.IDCauHoi == id);
                    if(olddethi == null)
                    {
                        DeThi_CauHoi deThi_CauHoi = new DeThi_CauHoi { IDDeThi = deThi.IDDeThi, IDCauHoi = id };
                        db.DeThi_CauHoi.Add(deThi_CauHoi);
                    }
                }
                foreach(var id in listcauhoi)
                {
                    if (!listidnew.Contains(id))
                    {
                        
                        DeThi_CauHoi deThi_CauHoi = db.DeThi_CauHoi.SingleOrDefault(n => n.IDCauHoi == id && n.IDDeThi == deThimodel.IDDeThi);
                        db.DeThi_CauHoi.Remove(deThi_CauHoi);
                    }
                }

                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            
            ViewBag.IDDanhSachThi = listcauhoi;
            return View(deThimodel);
        }

        // GET: Admin/DeThis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeThi deThi = db.DeThis.Find(id);
            if (deThi == null)
            {
                return HttpNotFound();
            }
            return View(deThi);
        }

        // POST: Admin/DeThis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeThi deThi = db.DeThis.Find(id);
            db.DeThis.Remove(deThi);
            var dethicauhois = db.DeThi_CauHoi.Where(n => n.IDDeThi == id);
            foreach(var cauhoi in dethicauhois)
            {
                db.DeThi_CauHoi.Remove(cauhoi);
            }
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
