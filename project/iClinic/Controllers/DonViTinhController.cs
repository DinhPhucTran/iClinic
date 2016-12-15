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
    public class DonViTinhController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /DonViTinh/

        public ActionResult Index()
        {
            return View(db.DbSetDonViTinh.ToList());
        }

        //
        // GET: /DonViTinh/Details/5

        public ActionResult Details(int id = 0)
        {
            DonViTinh donvitinh = db.DbSetDonViTinh.Find(id);
            if (donvitinh == null)
            {
                return HttpNotFound();
            }
            return View(donvitinh);
        }

        //
        // GET: /DonViTinh/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DonViTinh/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DonViTinh donvitinh)
        {
            if (ModelState.IsValid)
            {
                db.DbSetDonViTinh.Add(donvitinh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donvitinh);
        }

        //
        // GET: /DonViTinh/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DonViTinh donvitinh = db.DbSetDonViTinh.Find(id);
            if (donvitinh == null)
            {
                return HttpNotFound();
            }
            return View(donvitinh);
        }

        //
        // POST: /DonViTinh/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DonViTinh donvitinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donvitinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donvitinh);
        }

        //
        // GET: /DonViTinh/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DonViTinh donvitinh = db.DbSetDonViTinh.Find(id);
            if (donvitinh == null)
            {
                return HttpNotFound();
            }
            return View(donvitinh);
        }

        //
        // POST: /DonViTinh/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonViTinh donvitinh = db.DbSetDonViTinh.Find(id);
            db.DbSetDonViTinh.Remove(donvitinh);
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