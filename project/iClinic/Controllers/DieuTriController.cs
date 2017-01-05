using iClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;

namespace iClinic.Controllers
{
    public class DieuTriController : Controller
    {
        private Entities db = new Entities();
        //
        // GET: /DieuTri/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
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

            var patients = from p in db.DbSetHoSoDieuTriNoiTru where p.NgayKetThucDieuTri == null
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(p => p.BenhNhan.TenBenhNhan.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    patients = patients.OrderByDescending(p => p.BenhNhan.TenBenhNhan);
                    break;
                case "Date":
                    patients = patients.OrderBy(p => p.NgayBatDauDieuTri);
                    break;
                case "date_desc":
                    patients = patients.OrderByDescending(p => p.NgayBatDauDieuTri);
                    break;
                default:
                    patients = patients.OrderBy(p => p.BenhNhan.MaBenhNhan);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //return View(db.DbSetBenhNhan.ToList());
            return View(patients.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult NhapVien(int MaBN = 0, int MaBS = 0, string ChanDoan = "", string GhiChu = "")
        {
            ViewBag.Saved = TempData["saved"];
            GiayNhapVien gnv = new GiayNhapVien();
            gnv.BenhNhanID = MaBN;
            gnv.BacSiDieuTriID = MaBS;

            NhanVien bs = db.DbSetNhanVien.Find(MaBS);
            if(bs != null)
                gnv.BacSiDieuTri = bs;

            BenhNhan bn = db.DbSetBenhNhan.Find(MaBN);
            if (bn != null)
                gnv.BenhNhan = bn;
            gnv.NgayNhapVien = DateTime.Now;
            return View(gnv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhapVien(GiayNhapVien gnv)
        {
            if (ModelState.IsValid)
            {
                db.DbSetGiayNhapVien.Add(gnv);
                db.SaveChanges();

                HoSoDieuTriNoiTru hoSo = new HoSoDieuTriNoiTru
                {
                    BenhNhanID = gnv.BenhNhanID,
                    NgayBatDauDieuTri = DateTime.Now,
                    ChanDoan = gnv.ChanDoan,
                    GiayNhapVienID = gnv.MaGiayNhapVien,
                    BacSiDieuTriID = gnv.BacSiDieuTriID,
                    NgayKetThucDieuTri = null
                };

                db.DbSetHoSoDieuTriNoiTru.Add(hoSo);
                db.SaveChanges();
                TempData["saved"] = true;
                return RedirectToAction("NhapVien", new { MaBN = gnv.BenhNhanID, MaBS = gnv.BacSiDieuTriID, ChanDoan = gnv.ChanDoan, GhiChu = gnv.GhiChu });
            }
            
            return View(gnv);
        }

        public ActionResult XuatVien(string chanDoan, string loiDan, int maGiayNhapVien = 0, int maBN = 0, int maBS = 0)
        {
            ViewBag.Saved = TempData["saved"];
            GiayRaVien grv = new GiayRaVien
            {
                GiayNhapVienID = maGiayNhapVien,
                BacSiDieuTriID = maBS,
                BenhNhanID = maBN,
                ChanDoan = chanDoan,
                NgayRaVien = DateTime.Today,
                LoiDan = loiDan,
            };

            grv.BenhNhan = db.DbSetBenhNhan.Find(maBN);
            grv.BacSiDieuTri = db.DbSetNhanVien.Find(maBS);

            return View(grv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XuatVien(GiayRaVien grv)
        {
            if (ModelState.IsValid)
            {
                db.DbSetGiayRaVien.Add(grv);                                
                db.SaveChanges();

                HoSoDieuTriNoiTru hs = (HoSoDieuTriNoiTru)db.DbSetHoSoDieuTriNoiTru.Where(h => h.GiayNhapVienID == grv.GiayNhapVienID).First();
                if (hs != null)
                {
                    hs.NgayKetThucDieuTri = DateTime.Now;
                    db.Entry(hs).State = EntityState.Modified;
                    db.SaveChanges();
                }

                TempData["saved"] = true;
                return RedirectToAction("XuatVien", new { chanDoan = grv.ChanDoan, maBN = grv.BenhNhanID, maBS = grv.BacSiDieuTriID, loiDan = grv.LoiDan });
            }
            return View(grv);
        }

        public ActionResult ChuyenVien(int maGiayNhapVien = 0)
        {
            GiayNhapVien gnv = db.DbSetGiayNhapVien.Find(maGiayNhapVien);
            if (gnv == null)
            {
                return HttpNotFound();
            }

            GiayChuyenVien gcv = new GiayChuyenVien
            {
                GiayNhapVienID = gnv.MaGiayNhapVien,
                BenhNhanID = gnv.BenhNhanID,
                BacSiID = gnv.BacSiDieuTriID,
                NgayChuyenVien = DateTime.Today,
                ChanDoan = gnv.ChanDoan
            };
            return View(gcv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChuyenVien(GiayChuyenVien gcv)
        {
            if (ModelState.IsValid)
            {
                db.DbSetGiayChuyenVien.Add(gcv);
                db.SaveChanges();
            }
            return View(gcv);
        }

        public ActionResult CapNhatTinhTrang(int maHoSo = 0)
        {
            ViewBag.Msg = (Message)TempData["msg"];
            HoSoDieuTriNoiTru hs = db.DbSetHoSoDieuTriNoiTru.Find(maHoSo);
            var dsChiTiet = db.DbSetChiTietDieuTri.ToList().FindAll(c => c.HoSoDieuTriNoiTruID == maHoSo);
            ViewBag.dsChiTiet = dsChiTiet;
            ChiTietDieuTri ct = new ChiTietDieuTri();
            ct.HoSoDieuTriNoiTruID = maHoSo;
            ct.HoSoDieuTriNoiTru = hs;
            return View(ct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhatTinhTrang(ChiTietDieuTri ct)
        {
            if (ModelState.IsValid)
            {
                ct.NgayDieuTri = DateTime.Now;
                if(db.DbSetChiTietDieuTri.Find(ct.MaCTDT) != null)
                {
                    db.Entry(ct).State = EntityState.Modified;
                    db.SaveChanges();
                    return View(ct);
                }

                db.DbSetChiTietDieuTri.Add(ct);
                db.SaveChanges();
                Message msg = new Message();
                msg.Type = "success";
                msg.Title = "Thành công";
                msg.Content = "Đã cập nhật tình trạng bệnh nhân";
                TempData["msg"] = msg;
                return RedirectToAction("CapNhatTinhTrang", new { maHoSo = ct.HoSoDieuTriNoiTruID });
            }

            Message msg2 = new Message();
            msg2.Type = "error";
            msg2.Title = "Lỗi";
            msg2.Content = "Đã có lỗi xảy ra. Vui lòng thử lại sau.";
            TempData["msg"] = msg2;
            return RedirectToAction("CapNhatTinhTrang", new { maHoSo = ct.HoSoDieuTriNoiTruID });
        }
    }
}
