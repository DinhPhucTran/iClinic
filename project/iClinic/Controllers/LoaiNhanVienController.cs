using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iClinic.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace iClinic.Controllers
{
    [Authorize(Roles = "1")]
    public class LoaiNhanVienController : Controller
    {
        private Entities db = new Entities();
        ApplicationDbContext context = new ApplicationDbContext();

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
                try
                {
                    db.DbSetLoaiNhanVien.Add(loainhanvien);
                    db.SaveChanges();

                    var role = new IdentityRole();
                    role.Name = loainhanvien.MaLoaiNhanVien.ToString();
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
                catch (Exception e)
                {

                }

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
                try
                {
                    db.Entry(loainhanvien).State = EntityState.Modified;
                    db.SaveChanges();

                    var role = context.Roles.First(r => r.Name == loainhanvien.TenLoaiNhanVien);
                    context.Entry(role).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {

                }

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