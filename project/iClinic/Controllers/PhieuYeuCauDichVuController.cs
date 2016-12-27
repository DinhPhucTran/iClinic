using iClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace iClinic.Controllers
{
    public class PhieuYeuCauDichVuController : Controller
    {
        private Entities db = new Entities();
        //
        // GET: /PhieuYeuCauDichVu/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(PhieuYeuCauDichVu phieu)
        {
            if (ModelState.IsValid)
            {
                var phieuDichVu = from x in db.DbSetPhieuYeuCauDichVu where x.MaPhieuYeuCauDichVu == phieu.MaPhieuYeuCauDichVu select x;
                foreach (var item in phieuDichVu)
                {
                    item.TinhTrangKham = 1;
                    item.ChiSo = phieu.ChiSo;
                    item.BacSiID = 1;
                    item.KetQua = phieu.KetQua;
                    item.ThoiGianThucHien = DateTime.Now;
                }
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(phieu);
        }

        public ActionResult _SideBenhNhanCho(string sortOrder, string currentFilter, string searchString, int? page)
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
            var dsPhieuYeuCau = from p in db.DbSetPhieuYeuCauDichVu
                              where (dsPhieuKhamDangCho.Contains(p.PhieuKhamBenhID) && p.TinhTrangKham == 0)
                              select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                dsPhieuYeuCau = dsPhieuYeuCau.Where(p => p.PhieuKhamBenh.BenhNhan.TenBenhNhan.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    dsPhieuYeuCau = dsPhieuYeuCau.OrderByDescending(p => p.PhieuKhamBenh.BenhNhan.TenBenhNhan);
                    break;
                case "Date":
                    dsPhieuYeuCau = dsPhieuYeuCau.OrderBy(p => p.PhieuKhamBenh.BenhNhan.NgaySinh);
                    break;
                case "date_desc":
                    dsPhieuYeuCau = dsPhieuYeuCau.OrderByDescending(p => p.PhieuKhamBenh.BenhNhan.NgaySinh);
                    break;
                default:
                    dsPhieuYeuCau = dsPhieuYeuCau.OrderBy(p => p.PhieuKhamBenh.BenhNhan.TenBenhNhan);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView("_SideBenhNhanCho", dsPhieuYeuCau.ToPagedList(pageNumber, pageSize));
        }
    }
}
