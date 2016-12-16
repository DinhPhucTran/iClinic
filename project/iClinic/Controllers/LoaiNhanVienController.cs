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
    public class LoaiNhanVienController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /LoaiNhanVien/

        public ActionResult Index()
        {
            return View(db.DbSetLoaiNhanVien.ToList());
        }

        //
        // GET: /LoaiNhanVien/Details/5

        public ActionResult Details(int id = 0)
        {
            LoaiNhanVien loainhanvien = db.DbSetLoaiNhanVien.Find(id);
            if (loainhanvien == null)
            {
                return HttpNotFound();
            }
            return View(loainhanvien);
        }

        //
        // GET: /LoaiNhanVien/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LoaiNhanVien/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiNhanVien loainhanvien)
        {
            if (ModelState.IsValid)
            {
                db.DbSetLoaiNhanVien.Add(loainhanvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loainhanvien);
        }

        //
        // GET: /LoaiNhanVien/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LoaiNhanVien loainhanvien = db.DbSetLoaiNhanVien.Find(id);
            if (loainhanvien == null)
            {
                return HttpNotFound();
            }
            return View(loainhanvien);
        }

        //
        // POST: /LoaiNhanVien/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiNhanVien loainhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loainhanvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loainhanvien);
        }

        //
        // GET: /LoaiNhanVien/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LoaiNhanVien loainhanvien = db.DbSetLoaiNhanVien.Find(id);
            if (loainhanvien == null)
            {
                return HttpNotFound();
            }
            return View(loainhanvien);
        }

        //
        // POST: /LoaiNhanVien/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiNhanVien loainhanvien = db.DbSetLoaiNhanVien.Find(id);
            db.DbSetLoaiNhanVien.Remove(loainhanvien);
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