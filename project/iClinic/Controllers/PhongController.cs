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
    public class PhongController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Phong/

        public ActionResult Index()
        {
            //var dbsetphong = db.DbSetPhong.Include(p => p.BoPhan);
            return View(db.DbSetPhong.ToList());
        }

        //
        // GET: /Phong/Details/5

        public ActionResult Details(int id = 0)
        {
            Phong phong = db.DbSetPhong.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        //
        // GET: /Phong/Create

        public ActionResult Create()
        {
            ViewBag.DichVuID = new SelectList(db.DbSetDichVu, "MaDichVu", "TenDichVu");
            return View();
        }

        //
        // POST: /Phong/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.DbSetPhong.Add(phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DichVuID = new SelectList(db.DbSetDichVu, "MaDichVu", "TenDichVu", phong.DichVuID);
            return View(phong);
        }

        //
        // GET: /Phong/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Phong phong = db.DbSetPhong.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            //ViewBag.BoPhanID = new SelectList(db.DbSetBoPhan, "MaBoPhan", "TenBoPhan", phong.BoPhanID);
            return View(phong);
        }

        //
        // POST: /Phong/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.BoPhanID = new SelectList(db.DbSetBoPhan, "MaBoPhan", "TenBoPhan", phong.BoPhanID);
            return View(phong);
        }

        //
        // GET: /Phong/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Phong phong = db.DbSetPhong.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        //
        // POST: /Phong/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phong phong = db.DbSetPhong.Find(id);
            db.DbSetPhong.Remove(phong);
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