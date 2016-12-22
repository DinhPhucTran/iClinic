using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iClinic.Models;
using PagedList;

namespace iClinic.Controllers
{
    public class DonThuocController : Controller
    {
        private Entities db = new Entities();
        private int idPhieuKham = 0;
        //
        // GET: /DonThuoc/

        public ActionResult Index()
        {
            var dbsetdonthuoc = db.DbSetDonThuoc.Include(d => d.BacSiKeDon).Include(d => d.PhieuKhamBenh);
            return View(dbsetdonthuoc.ToList());
        }

        //
        // GET: /DonThuoc/Details/5

        public ActionResult Details(int id = 0)
        {
            DonThuoc donthuoc = db.DbSetDonThuoc.Find(id);
            if (donthuoc == null)
            {
                return HttpNotFound();
            }
            return View(donthuoc);
        }

        //
        // GET: /DonThuoc/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien");
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "TienSuBenh");
            return View();
        }

        //
        // POST: /DonThuoc/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DonThuoc donthuoc)
        {
            if (ModelState.IsValid)
            {
                db.DbSetDonThuoc.Add(donthuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", donthuoc.BacSiID);
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "TienSuBenh", donthuoc.PhieuKhamBenhID);
            return View(donthuoc);
        }

        //
        // GET: /DonThuoc/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DonThuoc donthuoc = db.DbSetDonThuoc.Find(id);
            if (donthuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", donthuoc.BacSiID);
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "TienSuBenh", donthuoc.PhieuKhamBenhID);
            return View(donthuoc);
        }

        //
        // POST: /DonThuoc/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DonThuoc donthuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donthuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", donthuoc.BacSiID);
            ViewBag.PhieuKhamBenhID = new SelectList(db.DbSetPhieuKhamBenh, "MaPhieuKhamBenh", "TienSuBenh", donthuoc.PhieuKhamBenhID);
            return View(donthuoc);
        }

        //
        // GET: /DonThuoc/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DonThuoc donthuoc = db.DbSetDonThuoc.Find(id);
            if (donthuoc == null)
            {
                return HttpNotFound();
            }
            return View(donthuoc);
        }

        //
        // POST: /DonThuoc/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonThuoc donthuoc = db.DbSetDonThuoc.Find(id);
            db.DbSetDonThuoc.Remove(donthuoc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult _SideDanhSachPhieuKhamBenh(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var dsPhieuKhamDangCho = from x in db.DbSetPhieuKhamBenhDangCho select x.PhieuKhamBenhID;
            var dsPhieuKham = from p in db.DbSetPhieuKhamBenh
                              where dsPhieuKhamDangCho.Contains(p.MaPhieuKhamBenh)
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                dsPhieuKham = dsPhieuKham.Where(p => p.BenhNhan.TenBenhNhan.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    dsPhieuKham = dsPhieuKham.OrderByDescending(p => p.BenhNhan.TenBenhNhan);
                    break;
                case "Date":
                    dsPhieuKham = dsPhieuKham.OrderBy(p => p.BenhNhan.NgaySinh);
                    break;
                case "date_desc":
                    dsPhieuKham = dsPhieuKham.OrderByDescending(p => p.BenhNhan.NgaySinh);
                    break;
                default:
                    dsPhieuKham = dsPhieuKham.OrderBy(p => p.BenhNhan.TenBenhNhan);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return PartialView("_SideDanhSachPhieuKhamBenh", dsPhieuKham.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult _SideDanhSachPhieuDichVu()
        {
            var dsPhieuDichVu = from p in db.DbSetPhieuYeuCauDichVu where p.PhieuKhamBenhID == idPhieuKham select p;
            return PartialView("_SideDanhSachDichVu", dsPhieuDichVu.ToList());
        }

        public ActionResult ShowResult(int id)
        {
            idPhieuKham = id;
            return RedirectToAction("_SideDanhSachPhieuDichVu");
        }
    }
}