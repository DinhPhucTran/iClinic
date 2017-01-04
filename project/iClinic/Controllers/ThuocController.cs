using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iClinic.Models;
using System.Dynamic;

namespace iClinic.Controllers
{
    public class ThuocController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Thuoc/

        public ActionResult Index()
        {
            var dbsetthuoc = db.DbSetThuoc.Include(t => t.DonViTinh);
            return View(dbsetthuoc.ToList());
        }

        //
        // GET: /Thuoc/Details/5

        public ActionResult Details(int id = 0)
        {
            Thuoc thuoc = db.DbSetThuoc.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        //
        // GET: /Thuoc/Create
        [Authorize(Roles = "5")]
        public ActionResult Create()
        {
            ViewBag.DonViTinhID = new SelectList(db.DbSetDonViTinh, "MaDonViTinh", "TenDonViTinh");
            return View();
        }

        //
        // POST: /Thuoc/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "5")]
        public ActionResult Create(Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                db.DbSetThuoc.Add(thuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonViTinhID = new SelectList(db.DbSetDonViTinh, "MaDonViTinh", "TenDonViTinh", thuoc.DonViTinhID);
            return View(thuoc);
        }

        //
        // GET: /Thuoc/Edit/5
        [Authorize(Roles = "5")]
        public ActionResult Edit(int id = 0)
        {
            Thuoc thuoc = db.DbSetThuoc.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonViTinhID = new SelectList(db.DbSetDonViTinh, "MaDonViTinh", "TenDonViTinh", thuoc.DonViTinhID);
            return View(thuoc);
        }

        //
        // POST: /Thuoc/Edit/5
        [Authorize(Roles = "5")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonViTinhID = new SelectList(db.DbSetDonViTinh, "MaDonViTinh", "TenDonViTinh", thuoc.DonViTinhID);
            return View(thuoc);
        }

        //
        // GET: /Thuoc/Delete/5
        [Authorize(Roles = "5")]
        public ActionResult Delete(int id = 0)
        {
            Thuoc thuoc = db.DbSetThuoc.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        //
        // POST: /Thuoc/Delete/5
        [Authorize(Roles = "5")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thuoc thuoc = db.DbSetThuoc.Find(id);
            db.DbSetThuoc.Remove(thuoc);
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