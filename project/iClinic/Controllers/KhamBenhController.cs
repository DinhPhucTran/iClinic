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
    [Authorize]
    public class KhamBenhController : Controller
    {
        private Entities db = new Entities();
        private Message msg;

        //
        // GET: /KhamBenh/

        //public ActionResult Index()
        //{
        //    var dbsetphieukhambenh = db.DbSetPhieuKhamBenh.Include(p => p.BenhNhan).Include(p => p.BacSi);
        //    return View(dbsetphieukhambenh.ToList());
        //}
        public ActionResult Index(String sortOrder, String currentFilter, String searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var phieuKB = from s in db.DbSetPhieuKhamBenh select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                phieuKB = phieuKB.Where(s => s.BenhNhan.TenBenhNhan.Contains(searchString));
            }
            switch (sortOrder) { 
                case "name_desc":
                    phieuKB = phieuKB.OrderByDescending(s => s.BenhNhan.TenBenhNhan);
                    break;
                case "Date":
                    phieuKB = phieuKB.OrderBy(s => s.NgayKham);
                    break;
                case "date_desc":
                    phieuKB = phieuKB.OrderByDescending(s => s.NgayKham);
                    break;
                default:
                    phieuKB = phieuKB.OrderBy(s => s.BenhNhan.TenBenhNhan);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(phieuKB.ToPagedList(pageNumber, pageSize));
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

        public ActionResult Create(int maPhieuKham = 0)
        {
            Message msgThongBao = (Message)TempData["msg"];
            ViewBag.Msg = msgThongBao;

            List<ChiTietDonThuoc> ds = (List<ChiTietDonThuoc>)TempData["dsThuoc"];
            if (ds != null)
            {
                foreach (ChiTietDonThuoc ct in ds)
                {
                    ct.Thuoc = db.DbSetThuoc.Find(ct.ThuocID);
                }
            }
            ViewBag.dsThuoc = ds;

            PhieuKhamBenh pk = db.DbSetPhieuKhamBenh.Find(maPhieuKham);


            ViewBag.BenhNhanSelect = 0;
            ViewBag.DichVuID = db.DbSetDichVu;
            ViewBag.DanhSachThuoc = db.DbSetThuoc;

            if (pk != null)
                return View(pk);

            return View();
        }

        //
        // POST: /KhamBenh/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhieuKhamBenh phieukhambenh, List<PhieuYeuCauDichVu> dsPhieuYeuCauDichVu)
        {
            if (ModelState.IsValid)
            {
                if (phieukhambenh.MaPhieuKhamBenh > 0 && dsPhieuYeuCauDichVu.Count > 0)
                {
                    if (dsPhieuYeuCauDichVu != null)
                    {
                        foreach (var item in dsPhieuYeuCauDichVu)
                        {
                            item.PhieuKhamBenhID = phieukhambenh.MaPhieuKhamBenh;
                            item.NgayLap = DateTime.Now;
                            item.ThoiGianThucHien = DateTime.Now;
                            db.DbSetPhieuYeuCauDichVu.Add(item);
                        }
                        db.SaveChanges();
                    }
                    msg = new Message();
                    msg.Type = "success";
                    msg.Title = "Thành công";
                    msg.Content = "Đã lưu dịch vụ khám";
                    TempData["msg"] = msg;
                    //return RedirectToAction("Create", new { id =  });
                    return RedirectToAction("Create");
                }
            }
            var errors = ModelState.Values.SelectMany(m => m.Errors);
            ViewBag.DichVuID = db.DbSetDichVu;
            ViewBag.DanhSachThuoc = db.DbSetThuoc;
            return View(phieukhambenh);
        }

        [Authorize(Roles = "2")]
        public ActionResult CreateDonThuoc(PhieuKhamBenh phieuKham, List<ChiTietDonThuoc> dsChiTietDonThuoc) 
        {
            TempData["msg"] = msg;
            if (ModelState.IsValid)
            {
                if (phieuKham != null && dsChiTietDonThuoc != null)
                {
                    DonThuoc donThuoc = new DonThuoc {
                        BacSiID = 1,//todo
                        NgayKeDon = DateTime.Now,
                        PhieuKhamBenhID = phieuKham.MaPhieuKhamBenh,
                        TongTien = dsChiTietDonThuoc.Sum(i => i.DonGia * i.SoLuong)
                    };
                    db.DbSetDonThuoc.Add(donThuoc);
                    db.SaveChanges();

                    if (dsChiTietDonThuoc != null)
                    {
                        foreach (var item in dsChiTietDonThuoc)
                        {
                            item.DonThuocID = donThuoc.MaDonThuoc;
                            item.NgayDung = item.Sang + item.Trua + item.Chieu + item.Toi;
                            db.DbSetChiTietDonThuoc.Add(item);
                        }
                        db.SaveChanges();
                    }

                    var dsPhieuCho = db.DbSetPhieuKhamBenhDangCho.Where(m => m.PhieuKhamBenhID == phieuKham.MaPhieuKhamBenh).ToList();
                    if (dsPhieuCho != null)
                    {
                        for (int i = 0; i < dsPhieuCho.Count; i++)
                        {
                            db.DbSetPhieuKhamBenhDangCho.Remove(db.DbSetPhieuKhamBenhDangCho.Find(dsPhieuCho[i].MaPhieuKhamBenhDangCho));
                        }
                    }
                    db.SaveChanges();

                    var dsBNCho = db.DbSetBenhNhanChoKham.Where(m => m.BenhNhanID == phieuKham.BenhNhanID).ToList();
                    if (dsBNCho != null)
                    {
                        for (int i = 0; i < dsBNCho.Count; i++)
                        {
                            db.DbSetBenhNhanChoKham.Remove(db.DbSetBenhNhanChoKham.Find(dsBNCho[i].MaBenhNhan));
                        }
                    }

                    db.SaveChanges();
                    msg = new Message();
                    msg.Type = "success";
                    msg.Title = "Thành công";
                    msg.Content = "Đã lưu đơn thuốc.";
                    TempData["msg"] = msg;
                    TempData["dsThuoc"] = dsChiTietDonThuoc;
                    return RedirectToAction("Create", new { maPhieuKham = phieuKham.MaPhieuKhamBenh });
                }
            }
            var errors = ModelState.Values.SelectMany(m => m.Errors);
            ViewBag.DichVuID = db.DbSetDichVu;
            ViewBag.DanhSachThuoc = db.DbSetThuoc;
            msg = new Message();
            msg.Type = "error";
            msg.Title = "Lỗi";
            msg.Content = "Không thể lưu đơn thuốc.\n" + errors.ToString();
            TempData["msg"] = msg;
            return RedirectToAction("Create");
            //return View(phieuKham);
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
            if (phieukhambenh.PhieuYeuCauDichVus != null)
            {
                for (int i = 0; i < phieukhambenh.PhieuYeuCauDichVus.ToList().Count; i++)
                {
                    int index = phieukhambenh.PhieuYeuCauDichVus.ToList()[i].MaPhieuYeuCauDichVu;
                    db.DbSetPhieuYeuCauDichVu.Remove(db.DbSetPhieuYeuCauDichVu.Find(index));
                }
            }
            var dsPhieuCho = db.DbSetPhieuKhamBenhDangCho.Where(m => m.PhieuKhamBenhID == phieukhambenh.MaPhieuKhamBenh).ToList();
            if (dsPhieuCho != null)
            {
                for (int i = 0; i < dsPhieuCho.Count; i++)
                {
                    db.DbSetPhieuKhamBenhDangCho.Remove(db.DbSetPhieuKhamBenhDangCho.Find(dsPhieuCho[i].MaPhieuKhamBenhDangCho));
                }
            }
            db.SaveChanges();
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

        public ActionResult _SideListPhieuKham(string sortOrder, string currentFilter, string searchString, int? page)
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

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView("_SideListPhieuKham", dsPhieuKham.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetDanhSachDichVu(String MaPhieuKham)
        {
            var maPhieu = int.Parse(MaPhieuKham);
            var phieuKham = db.DbSetPhieuKhamBenhDangCho.Where(m => m.PhieuKhamBenhID == maPhieu).First();
            var objData = db.DbSetPhieuYeuCauDichVu.ToList().FindAll(n => n.PhieuKhamBenhID == maPhieu);
            var objDataCustom = new List<dynamic>();
            foreach (var item in objData)
            {
                objDataCustom.Add(new { MaPhieuDichVu = item.MaPhieuYeuCauDichVu, BacSi = item.BacSi, DichVu = item.DichVu, KetQua = item.KetQua, ChiSo = item.ChiSo, LyDoKham = phieuKham.LyDoKham, ChanDoan = phieuKham.ChanDoan, LoiDan = phieuKham.LoiDan});
            }
            return Json(new JavaScriptSerializer().Serialize(objDataCustom));
        }

        public ActionResult UpdatePhieuKham(String MaPhieuKhamBenh, String lyDokham, String chanDoan, String loiDan)
        {
            int maPhieu = int.Parse(MaPhieuKhamBenh);
            var queryPKB = from x in db.DbSetPhieuKhamBenh where x.MaPhieuKhamBenh == maPhieu select x;
            var queryPKBDC = from y in db.DbSetPhieuKhamBenhDangCho where y.PhieuKhamBenhID == maPhieu select y;
            foreach (var item in queryPKB)
            {
                item.LyDoKham = lyDokham;
                item.ChanDoan = chanDoan;
                item.LoiDan = loiDan;
            }
            foreach (var item in queryPKBDC)
            {
                item.LyDoKham = lyDokham;
                item.ChanDoan = chanDoan;
                item.LoiDan = loiDan;
            }
            db.SaveChanges();
            return Json(new JavaScriptSerializer().Serialize("Cập nhật thành công"));
        }
    }
}