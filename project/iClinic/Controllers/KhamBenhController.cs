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
    public class KhamBenhController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /KhamBenh/

        public ActionResult Index()
        {
            var dbsetphieukhambenh = db.DbSetPhieuKhamBenh.Include(p => p.BenhNhan).Include(p => p.BacSi);
            return View(dbsetphieukhambenh.ToList());
        }

        //
        // GET: /KhamBenh/Details/5

        public ActionResult Details(int id = 0)
        {
            PhieuKhamBenh phieukhambenh = db.DbSetPhieuKhamBenh.Find(id);
            if (phieukhambenh == null)
            {
                return HttpNotFound();
            }
            return View(phieukhambenh);
        }

        //
        // GET: /KhamBenh/Create

        public ActionResult Create()
        {
            ViewBag.BenhNhanID = new SelectList(db.DbSetBenhNhan, "MaBenhNhan", "TenBenhNhan");
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien");
            ViewBag.DichVuID = new SelectList(db.DbSetDichVu, "MaDichVu", "TenDichVu");
            return View();
        }

        //
        // POST: /KhamBenh/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhieuKhamBenh phieukhambenh)
        {
            if (ModelState.IsValid)
            {
                db.DbSetPhieuKhamBenh.Add(phieukhambenh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BenhNhanID = new SelectList(db.DbSetBenhNhan, "MaBenhNhan", "TenBenhNhan", phieukhambenh.BenhNhanID);
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", phieukhambenh.BacSiID);
            ViewBag.DichVuID = new SelectList(db.DbSetDichVu, "MaDichVu", "TenDichVu");
            return View(phieukhambenh);
        }

        //
        // GET: /KhamBenh/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PhieuKhamBenh phieukhambenh = db.DbSetPhieuKhamBenh.Find(id);
            if (phieukhambenh == null)
            {
                return HttpNotFound();
            }
            ViewBag.BenhNhanID = new SelectList(db.DbSetBenhNhan, "MaBenhNhan", "TenBenhNhan", phieukhambenh.BenhNhanID);
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", phieukhambenh.BacSiID);
            return View(phieukhambenh);
        }

        //
        // POST: /KhamBenh/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhieuKhamBenh phieukhambenh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieukhambenh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BenhNhanID = new SelectList(db.DbSetBenhNhan, "MaBenhNhan", "TenBenhNhan", phieukhambenh.BenhNhanID);
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", phieukhambenh.BacSiID);
            return View(phieukhambenh);
        }

        //
        // GET: /KhamBenh/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PhieuKhamBenh phieukhambenh = db.DbSetPhieuKhamBenh.Find(id);
            if (phieukhambenh == null)
            {
                return HttpNotFound();
            }
            return View(phieukhambenh);
        }

        //
        // POST: /KhamBenh/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuKhamBenh phieukhambenh = db.DbSetPhieuKhamBenh.Find(id);
            db.DbSetPhieuKhamBenh.Remove(phieukhambenh);
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