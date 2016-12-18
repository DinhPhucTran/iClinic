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
    public class DichVuController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /DichVu/

        public ActionResult Index()
        {
            return View(db.DbSetDichVu.ToList());
        }

        //
        // GET: /DichVu/Details/5

        public ActionResult Details(int id = 0)
        {
            DichVu dichvu = db.DbSetDichVu.Find(id);
            if (dichvu == null)
            {
                return HttpNotFound();
            }
            return View(dichvu);
        }

        //
        // GET: /DichVu/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DichVu/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DichVu dichvu)
        {
            if (ModelState.IsValid)
            {
                db.DbSetDichVu.Add(dichvu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dichvu);
        }

        //
        // GET: /DichVu/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DichVu dichvu = db.DbSetDichVu.Find(id);
            if (dichvu == null)
            {
                return HttpNotFound();
            }
            return View(dichvu);
        }

        //
        // POST: /DichVu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DichVu dichvu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dichvu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dichvu);
        }

        //
        // GET: /DichVu/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DichVu dichvu = db.DbSetDichVu.Find(id);
            if (dichvu == null)
            {
                return HttpNotFound();
            }
            return View(dichvu);
        }

        //
        // POST: /DichVu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DichVu dichvu = db.DbSetDichVu.Find(id);
            db.DbSetDichVu.Remove(dichvu);
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