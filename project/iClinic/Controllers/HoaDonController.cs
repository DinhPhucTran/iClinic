using iClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Script.Serialization;

namespace iClinic.Controllers
{
    public class HoaDonController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /HoaDon/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create (HoaDon hd)
        {
            if (ModelState.IsValid)
            {
                hd.NgayThanhToan = DateTime.Now;
                db.DbSetHoaDon.Add(hd);
                db.SaveChanges();
                var maPhieu = hd.PhieuKhamBenhID;
                //chuyển trạng thái phiếu khám bệnh thành đã thanh toán
                var queryPKB = from x in db.DbSetPhieuKhamBenh where x.MaPhieuKhamBenh == maPhieu select x;
                var queryPKBDC = from y in db.DbSetPhieuKhamBenhDangCho where y.PhieuKhamBenhID == maPhieu select y;
                foreach (var item in queryPKB)
                {
                    item.TinhTrangThanhToan = 1;
                }
                foreach (var item in queryPKBDC)
                {
                    item.TinhTrangThanhToan = 1;
                }
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(hd);
        }

        public ActionResult _SidePhieuKhamBenh(string sortOrder, string currentFilter, string searchString, int? page)
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

            var dsPhieuKhamDangCho = from x in db.DbSetPhieuKhamBenhDangCho where x.TinhTrangThanhToan == 0 select x.PhieuKhamBenhID;
            var dsPhieuKham = from p in db.DbSetPhieuKhamBenh
                              where (dsPhieuKhamDangCho.Contains(p.MaPhieuKhamBenh) && p.TinhTrangThanhToan == 0)
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

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView("_SidePhieuKhamBenh", dsPhieuKham.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetDanhSachDichVu(String MaPhieuKham)
        {
            var objData = db.DbSetPhieuYeuCauDichVu.ToList().FindAll(n => n.PhieuKhamBenhID == int.Parse(MaPhieuKham));
            var objDataCustom = new List<dynamic>();
            foreach (var item in objData)
            {
                objDataCustom.Add(new { MaPhieuDichVu = item.MaPhieuYeuCauDichVu, DichVu = item.DichVu });
            }
            return Json(new JavaScriptSerializer().Serialize(objDataCustom));
        }
    }
}
