using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iClinic.Models;
using System.Web.Script.Serialization;
using PagedList;

namespace iClinic.Controllers
{
    public class KhamBenhController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /KhamBenh/

        public ActionResult Index()
        {
            var dbsetphieukhambenh = db.DbSetPhieuKhamBenh.Include(p => p.BenhNhan).Include(p => p.BacSi);
            return View(dbsetphieukhambenh.ToList());
        }

        //
        // GET: /KhamBenh/Details/5

        public ActionResult Details(int id = 0)
        {
            PhieuKhamBenh phieukhambenh = db.DbSetPhieuKhamBenh.Find(id);
            if (phieukhambenh == null)
            {
                return HttpNotFound();
            }
            return View(phieukhambenh);
        }

        //
        // GET: /KhamBenh/Create

        public ActionResult Create()
        {
            ViewBag.BenhNhanID = new SelectList(db.DbSetBenhNhan, "MaBenhNhan", "TenBenhNhan");
            var dsNhanVien = db.DbSetNhanVien.ToList().Select(s => new
            {
                IdNV = s.MaNhanVien,
                InfoNV = s.TenNhanVien + " - " + "NV" + s.MaNhanVien + " - " + s.BoPhan.TenBoPhan
            });
            ViewBag.BacSiID = new SelectList(dsNhanVien, "IdNV", "InfoNV");
            ViewBag.DichVuID = db.DbSetDichVu;
            ViewBag.DanhSachBacSi = db.DbSetNhanVien; //phải lọc: theo loại nhân viên, loại dịch vụ, 
            ViewBag.DanhSachPhong = db.DbSetPhong;
            return View();

            //PhieuKhamBenh phieu = new PhieuKhamBenh();
            //phieu.BenhNhanID = MaBenhNhan;
            //phieu.BenhNhan = db.DbSetBenhNhan.Find(MaBenhNhan);
            //return View(phieu);
        }

        //
        // POST: /KhamBenh/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhieuKhamBenh phieukhambenh, List<PhieuYeuCauDichVu> dsPhieuYeuCauDichVu)
        {

            if (ModelState.IsValid)
            {
                db.DbSetPhieuKhamBenh.Add(phieukhambenh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BenhNhanID = new SelectList(db.DbSetBenhNhan, "MaBenhNhan", "TenBenhNhan", phieukhambenh.BenhNhanID);
            var dsNhanVien = db.DbSetNhanVien.ToList().Select(s => new
            {
                IdNV = s.MaNhanVien,
                InfoNV = s.TenNhanVien + " - " + "NV" + s.MaNhanVien + " - " + s.BoPhan.TenBoPhan
            });
            ViewBag.DichVuID = db.DbSetDichVu;
            ViewBag.BacSiID = new SelectList(dsNhanVien, "IdNV", "InfoNV"); //bác sĩ đang đăng nhập để tạo. (ko dc chọn)
            ViewBag.DanhSachBacSi = db.DbSetNhanVien; 
            ViewBag.DanhSachPhong = db.DbSetPhong.Where(n => n.DichVuID == 1);
            return View(phieukhambenh);
        }

        //
        // GET: /KhamBenh/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PhieuKhamBenh phieukhambenh = db.DbSetPhieuKhamBenh.Find(id);
            if (phieukhambenh == null)
            {
                return HttpNotFound();
            }
            ViewBag.BenhNhanID = new SelectList(db.DbSetBenhNhan, "MaBenhNhan", "TenBenhNhan", phieukhambenh.BenhNhanID);
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", phieukhambenh.BacSiID);
            return View(phieukhambenh);
        }

        //
        // POST: /KhamBenh/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhieuKhamBenh phieukhambenh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieukhambenh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BenhNhanID = new SelectList(db.DbSetBenhNhan, "MaBenhNhan", "TenBenhNhan", phieukhambenh.BenhNhanID);
            ViewBag.BacSiID = new SelectList(db.DbSetNhanVien, "MaNhanVien", "TenNhanVien", phieukhambenh.BacSiID);
            return View(phieukhambenh);
        }

        //
        // GET: /KhamBenh/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PhieuKhamBenh phieukhambenh = db.DbSetPhieuKhamBenh.Find(id);
            if (phieukhambenh == null)
            {
                return HttpNotFound();
            }
            return View(phieukhambenh);
        }

        //
        // POST: /KhamBenh/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuKhamBenh phieukhambenh = db.DbSetPhieuKhamBenh.Find(id);
            db.DbSetPhieuKhamBenh.Remove(phieukhambenh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult GetPhongByIdDichVu(String dichVuID)
        {
            var objData = db.DbSetPhong.ToList().Find(n => n.DichVuID == int.Parse(dichVuID));
            return Json(new JavaScriptSerializer().Serialize(objData));
        }

        public ActionResult _SideListBenhNhan(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var patients = from p in db.DbSetBenhNhan
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(p => p.TenBenhNhan.Contains(searchString));
            }

            patients = patients.OrderBy(p => p.TenBenhNhan);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView(patients.ToPagedList(pageNumber, pageSize));
        }
    }
}