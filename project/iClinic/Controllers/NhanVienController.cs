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
    public class NhanVienController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /NhanVien/

        public ActionResult Index()
        {
            var dbsetnhanvien = db.DbSetNhanVien.Include(n => n.LoaiNhanVien).Include(n => n.BoPhan).Include(n => n.ChucVu);
            //var dbsetnhanvien = db.DbSetNhanVien.Include(n => n.LoaiNhanVien).Include(n => n.ChucVu).Include(n => n.BoPhan);
            return View(dbsetnhanvien.ToList());
        }

        //
        // GET: /NhanVien/Details/5

        public ActionResult Details(int id = 0)
        {
            NhanVien nhanvien = db.DbSetNhanVien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        //
        // GET: /NhanVien/Create

        public ActionResult Create()
        {
            IEnumerable<String> gioiTinh = new List<String> {"Nam", "Nữ"};
            ViewBag.GioiTinhID = GetSelectListItems(gioiTinh);
            ViewBag.LoaiNhanVienID = new SelectList(db.DbSetLoaiNhanVien, "MaLoaiNhanVien", "TenLoaiNhanVien");
            ViewBag.ChucVuID = new SelectList(db.DbSetChucVu, "MaChucVu", "TenChucVu");
            //var membersPhong = db.DbSetPhong.Select(s => new { 
            //    Id = s.MaPhong,
            //    NamePhong = s.TenPhong + " - " + s.BoPhan.TenBoPhan
            //}).ToList();
            //ViewBag.PhongID = new SelectList(membersPhong, "Id", "NamePhong");
            ViewBag.BoPhanID = new SelectList(db.DbSetBoPhan, "MaBoPhan", "TenBoPhan");
            return View();
        }

        //
        // POST: /NhanVien/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.DbSetNhanVien.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            IEnumerable<String> gioiTinh = new List<String> { "Nam", "Nữ" };
            ViewBag.GioiTinhID = GetSelectListItems(gioiTinh);
            ViewBag.LoaiNhanVienID = new SelectList(db.DbSetLoaiNhanVien, "MaLoaiNhanVien", "TenLoaiNhanVien", nhanvien.LoaiNhanVienID);
            ViewBag.ChucVuID = new SelectList(db.DbSetChucVu, "MaChucVu", "TenChucVu", nhanvien.ChucVuID);
            ViewBag.BoPhanID = new SelectList(db.DbSetBoPhan, "MaBoPhan", "TenBoPhan", nhanvien.BoPhanID);
            //var membersPhong = db.DbSetPhong.Select(s => new
            //{
            //    Id = s.MaPhong,
            //    NamePhong = s.TenPhong + " - " + s.BoPhan.TenBoPhan
            //}).ToList();
            //ViewBag.PhongID = new SelectList(membersPhong, "Id", "NamePhong");
            return View(nhanvien);
        }

        //
        // GET: /NhanVien/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NhanVien nhanvien = db.DbSetNhanVien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiNhanVienID = new SelectList(db.DbSetLoaiNhanVien, "MaLoaiNhanVien", "TenLoaiNhanVien", nhanvien.LoaiNhanVienID);
            ViewBag.ChucVuID = new SelectList(db.DbSetChucVu, "MaChucVu", "TenChucVu", nhanvien.ChucVuID);
            ViewBag.BoPhanID = new SelectList(db.DbSetBoPhan, "MaBoPhan", "TenBoPhan", nhanvien.BoPhanID);
            return View(nhanvien);
        }

        //
        // POST: /NhanVien/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiNhanVienID = new SelectList(db.DbSetLoaiNhanVien, "MaLoaiNhanVien", "TenLoaiNhanVien", nhanvien.LoaiNhanVienID);
            ViewBag.ChucVuID = new SelectList(db.DbSetChucVu, "MaChucVu", "TenChucVu", nhanvien.ChucVuID);
            ViewBag.BoPhanID = new SelectList(db.DbSetBoPhan, "MaBoPhan", "TenBoPhan", nhanvien.BoPhanID);
            return View(nhanvien);
        }

        //
        // GET: /NhanVien/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NhanVien nhanvien = db.DbSetNhanVien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        //
        // POST: /NhanVien/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanvien = db.DbSetNhanVien.Find(id);
            db.DbSetNhanVien.Remove(nhanvien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //add bussiness

        public IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<String> elements)
        {
            var result = new List<SelectListItem>();
            foreach (var item in elements)
            {
                result.Add(new SelectListItem
                {
                    Text = item,
                    Value = item
                });
            }
            return result;
        }

    }
}