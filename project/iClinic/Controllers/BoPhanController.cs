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
    public class BoPhanController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /BoPhan/

        public ActionResult Index()
        {
            var dbsetbophan = db.DbSetBoPhan.Include(b => b.NhanVien);
            return View(dbsetbophan.ToList());
        }

        //
        // GET: /BoPhan/Details/5

        public ActionResult Details(int id = 0)
        {
            BoPhan bophan = db.DbSetBoPhan.Find(id);
            if (bophan == null)
            {
                return HttpNotFound();
            }
            return View(bophan);
        }

        //
        // GET: /BoPhan/Create

        public ActionResult Create()
        {
            ViewBag.NhanVienID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien");
            return View();
        }

        //
        // POST: /BoPhan/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoPhan bophan)
        {
            if (ModelState.IsValid)
            {
                db.DbSetBoPhan.Add(bophan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NhanVienID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", bophan.NhanVienID);
            return View(bophan);
        }

        //
        // GET: /BoPhan/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BoPhan bophan = db.DbSetBoPhan.Find(id);
            if (bophan == null)
            {
                return HttpNotFound();
            }
            ViewBag.NhanVienID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", bophan.NhanVienID);
            return View(bophan);
        }

        //
        // POST: /BoPhan/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BoPhan bophan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bophan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NhanVienID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", bophan.NhanVienID);
            return View(bophan);
        }

        //
        // GET: /BoPhan/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BoPhan bophan = db.DbSetBoPhan.Find(id);
            if (bophan == null)
            {
                return HttpNotFound();
            }
            return View(bophan);
        }

        //
        // POST: /BoPhan/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoPhan bophan = db.DbSetBoPhan.Find(id);
            db.DbSetBoPhan.Remove(bophan);
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