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
    [Authorize]
    public class BenhNhanController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /BenhNhan/

        public ActionResult Index()
        {
            return View(db.DbSetBenhNhan.ToList());
        }

        //
        // GET: /BenhNhan/Details/5

        public ActionResult Details(int id = 0)
        {
            BenhNhan benhnhan = db.DbSetBenhNhan.Find(id);
            if (benhnhan == null)
            {
                return HttpNotFound();
            }
            return View(benhnhan);
        }

        //
        // GET: /BenhNhan/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BenhNhan/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BenhNhan benhnhan)
        {
            if (ModelState.IsValid)
            {
                db.DbSetBenhNhan.Add(benhnhan);
                db.SaveChanges();
                db.DbSetBenhNhanChoKham.Add(new BenhNhanChoKham
                {
                    BenhNhanID = benhnhan.MaBenhNhan,
                    DiaChi = benhnhan.DiaChi,
                    GioiTinh = benhnhan.GioiTinh,
                    NgaySinh = benhnhan.NgaySinh,
                    NgayTiepNhan = benhnhan.NgayTiepNhan,
                    NgheNghiep = benhnhan.NgheNghiep,
                    SoDT = benhnhan.SoDT,
                    TenBenhNhan = benhnhan.TenBenhNhan,
                    TienSuBenh = benhnhan.TienSuBenh
                });
                return RedirectToAction("Index");
            }

            return View(benhnhan);
        }

        //
        // GET: /BenhNhan/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BenhNhan benhnhan = db.DbSetBenhNhan.Find(id);
            if (benhnhan == null)
            {
                return HttpNotFound();
            }
            return View(benhnhan);
        }

        //
        // POST: /BenhNhan/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BenhNhan benhnhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benhnhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(benhnhan);
        }

        //
        // GET: /BenhNhan/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BenhNhan benhnhan = db.DbSetBenhNhan.Find(id);
            if (benhnhan == null)
            {
                return HttpNotFound();
            }
            return View(benhnhan);
        }

        //
        // POST: /BenhNhan/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BenhNhan benhnhan = db.DbSetBenhNhan.Find(id);
            var dsBenhNhanChoKham = db.DbSetBenhNhanChoKham.Where(m => m.BenhNhanID == benhnhan.MaBenhNhan).ToList();
            for (int i = 0; i < dsBenhNhanChoKham.Count; i++)
            {
                db.DbSetBenhNhanChoKham.Remove(db.DbSetBenhNhanChoKham.Find(dsBenhNhanChoKham[i].MaBenhNhan));
            }
            db.SaveChanges();
            db.DbSetBenhNhan.Remove(benhnhan);
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