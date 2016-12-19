using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iClinic.Models;

namespace iClinic.Controllers
{
    public class PhieuYeuCauDichVuController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /PhieuYeuCauDichVu/

        public ActionResult Index()
        {
            var dbsetphieuyeucaudichvu = db.DbSetPhieuYeuCauDichVu.Include(p => p.BacSi).Include(p => p.DichVu).Include(p => p.PhieuKhamBenh);
            return View(dbsetphieuyeucaudichvu.ToList());
        }

        //
        // GET: /PhieuYeuCauDichVu/Details/5

        public ActionResult Details(int id = 0)
        {
            PhieuYeuCauDichVu phieuyeucaudichvu = db.DbSetPhieuYeuCauDichVu.Find(id);
            if (phieuyeucaudichvu == null)
            {
                return HttpNotFound();
            }
            return View(phieuyeucaudichvu);
        }

        //
        // GET: /PhieuYeuCauDichVu/Create

        public ActionResult Create()
        {
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien");
            ViewBag.DichVuID = new SelectList(db.DbSetDichVu, "MaDichVu", "TenDichVu");
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "ChanDoan");
            return View();
        }

        //
        // POST: /PhieuYeuCauDichVu/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhieuYeuCauDichVu phieuyeucaudichvu)
        {
            if (ModelState.IsValid)
            {
                db.DbSetPhieuYeuCauDichVu.Add(phieuyeucaudichvu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", phieuyeucaudichvu.BacSiID);
            ViewBag.DichVuID = new SelectList(db.DbSetDichVu, "MaDichVu", "TenDichVu", phieuyeucaudichvu.DichVuID);
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "ChanDoan", phieuyeucaudichvu.PhieuKhamBenhID);
            return View(phieuyeucaudichvu);
        }

        //
        // GET: /PhieuYeuCauDichVu/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PhieuYeuCauDichVu phieuyeucaudichvu = db.DbSetPhieuYeuCauDichVu.Find(id);
            if (phieuyeucaudichvu == null)
            {
                return HttpNotFound();
            }
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", phieuyeucaudichvu.BacSiID);
            ViewBag.DichVuID = new SelectList(db.DbSetDichVu, "MaDichVu", "TenDichVu", phieuyeucaudichvu.DichVuID);
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "ChanDoan", phieuyeucaudichvu.PhieuKhamBenhID);
            return View(phieuyeucaudichvu);
        }

        //
        // POST: /PhieuYeuCauDichVu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhieuYeuCauDichVu phieuyeucaudichvu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuyeucaudichvu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", phieuyeucaudichvu.BacSiID);
            ViewBag.DichVuID = new SelectList(db.DbSetDichVu, "MaDichVu", "TenDichVu", phieuyeucaudichvu.DichVuID);
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "ChanDoan", phieuyeucaudichvu.PhieuKhamBenhID);
            return View(phieuyeucaudichvu);
        }

        //
        // GET: /PhieuYeuCauDichVu/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PhieuYeuCauDichVu phieuyeucaudichvu = db.DbSetPhieuYeuCauDichVu.Find(id);
            if (phieuyeucaudichvu == null)
            {
                return HttpNotFound();
            }
            return View(phieuyeucaudichvu);
        }

        //
        // POST: /PhieuYeuCauDichVu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuYeuCauDichVu phieuyeucaudichvu = db.DbSetPhieuYeuCauDichVu.Find(id);
            db.DbSetPhieuYeuCauDichVu.Remove(phieuyeucaudichvu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}