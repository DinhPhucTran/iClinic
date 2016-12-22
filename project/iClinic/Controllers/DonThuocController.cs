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
    public class DonThuocController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /DonThuoc/

        public ActionResult Index()
        {
            var dbsetdonthuoc = db.DbSetDonThuoc.Include(d => d.BacSiKeDon).Include(d => d.PhieuKhamBenh);
            return View(dbsetdonthuoc.ToList());
        }

        //
        // GET: /DonThuoc/Details/5

        public ActionResult Details(int id = 0)
        {
            DonThuoc donthuoc = db.DbSetDonThuoc.Find(id);
            if (donthuoc == null)
            {
                return HttpNotFound();
            }
            return View(donthuoc);
        }

        //
        // GET: /DonThuoc/Create

        public ActionResult Create()
        {
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien");
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "TienSuBenh");
            return View();
        }

        //
        // POST: /DonThuoc/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DonThuoc donthuoc)
        {
            if (ModelState.IsValid)
            {
                db.DbSetDonThuoc.Add(donthuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", donthuoc.BacSiID);
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "TienSuBenh", donthuoc.PhieuKhamBenhID);
            return View(donthuoc);
        }

        //
        // GET: /DonThuoc/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DonThuoc donthuoc = db.DbSetDonThuoc.Find(id);
            if (donthuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", donthuoc.BacSiID);
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "TienSuBenh", donthuoc.PhieuKhamBenhID);
            return View(donthuoc);
        }

        //
        // POST: /DonThuoc/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DonThuoc donthuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donthuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", donthuoc.BacSiID);
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "TienSuBenh", donthuoc.PhieuKhamBenhID);
            return View(donthuoc);
        }

        //
        // GET: /DonThuoc/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DonThuoc donthuoc = db.DbSetDonThuoc.Find(id);
            if (donthuoc == null)
            {
                return HttpNotFound();
            }
            return View(donthuoc);
        }

        //
        // POST: /DonThuoc/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonThuoc donthuoc = db.DbSetDonThuoc.Find(id);
            db.DbSetDonThuoc.Remove(donthuoc);
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