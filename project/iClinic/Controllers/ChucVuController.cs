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
    public class ChucVuController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /ChucVu/

        public ActionResult Index()
        {
            return View(db.DbSetChucVu.ToList());
        }

        //
        // GET: /ChucVu/Details/5

        public ActionResult Details(int id = 0)
        {
            ChucVu chucvu = db.DbSetChucVu.Find(id);
            if (chucvu == null)
            {
                return HttpNotFound();
            }
            return View(chucvu);
        }

        //
        // GET: /ChucVu/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ChucVu/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChucVu chucvu)
        {
            if (ModelState.IsValid)
            {
                db.DbSetChucVu.Add(chucvu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chucvu);
        }

        //
        // GET: /ChucVu/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ChucVu chucvu = db.DbSetChucVu.Find(id);
            if (chucvu == null)
            {
                return HttpNotFound();
            }
            return View(chucvu);
        }

        //
        // POST: /ChucVu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChucVu chucvu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chucvu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chucvu);
        }

        //
        // GET: /ChucVu/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ChucVu chucvu = db.DbSetChucVu.Find(id);
            if (chucvu == null)
            {
                return HttpNotFound();
            }
            return View(chucvu);
        }

        //
        // POST: /ChucVu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChucVu chucvu = db.DbSetChucVu.Find(id);
            db.DbSetChucVu.Remove(chucvu);
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