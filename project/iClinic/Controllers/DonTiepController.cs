﻿using System;
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
    public class DonTiepController : Controller
    {
        private Entities db = new Entities();
        //private string msgType = "";
        //private string msgContent = "";
        //private string msgTitle = "";
        private Message msg;

        //
        // GET: /DonTiep/
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

            var patients = from p in db.DbSetBenhNhan
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(p => p.TenBenhNhan.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    patients = patients.OrderByDescending(p => p.TenBenhNhan);
                    break;
                case "Date":
                    patients = patients.OrderBy(p => p.NgayTiepNhan);
                    break;
                case "date_desc":
                    patients = patients.OrderByDescending(p => p.NgayTiepNhan);
                    break;
                default:
                    patients = patients.OrderBy(p => p.NgayTiepNhan);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //return View(db.DbSetBenhNhan.ToList());
            return View(patients.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /DonTiep/Details/5

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
        // GET: /DonTiep/Create

        public ActionResult Create(int id = 0)
        {
            Message msg = (Message)TempData["msg"];
            ViewBag.Msg = msg;
            BenhNhan benhnhan = db.DbSetBenhNhan.Find(id);
            DichVu dv = db.DbSetDichVu.Where(m => m.TenDichVu == "Dịch vụ khám").First();
            ViewBag.PhongKham = db.DbSetPhong.Where(m => m.DichVuID == dv.MaDichVu);//todo;
            return View(benhnhan);
        }

        public ActionResult _SideListBN(string sortOrder, string currentFilter, string searchString, int? page)
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

            var patients = from p in db.DbSetBenhNhan
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(p => p.TenBenhNhan.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    patients = patients.OrderByDescending(p => p.TenBenhNhan);
                    break;
                case "Date":
                    patients = patients.OrderBy(p => p.NgayTiepNhan);
                    break;
                case "date_desc":
                    patients = patients.OrderByDescending(p => p.NgayTiepNhan);
                    break;
                default:
                    patients = patients.OrderBy(p => p.NgayTiepNhan);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView(patients.ToPagedList(pageNumber, pageSize));
        }

        //
        // POST: /DonTiep/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BenhNhan benhnhan, String phongKham)
        {
            benhnhan.NgayTiepNhan = DateTime.Now;
            DichVu dv = db.DbSetDichVu.Where(m => m.TenDichVu == "Dịch vụ khám").First();
            Phong phongDV = db.DbSetPhong.Where(m => m.DichVuID == dv.MaDichVu).First();
            int maPhong;
            bool parsed = Int32.TryParse(phongKham, out maPhong);
            if (!parsed || maPhong <= 0)
                maPhong = phongDV.MaPhong;
            if (ModelState.IsValid)
            {
                var tienSuBenh = benhnhan.TienSuBenh;
                benhnhan.TienSuBenh = "";
                db.DbSetBenhNhan.Add(benhnhan);
                db.SaveChanges();
                var pk = new PhieuKhamBenh
                {
                    BenhNhanID = benhnhan.MaBenhNhan,
                    NgayKham = DateTime.Now,
                    TinhTrangThanhToan = 0,
                    LyDoKham = tienSuBenh
                };
                db.DbSetPhieuKhamBenh.Add(pk);
                db.SaveChanges();
                //them dich vu kham 
                
                var pkdv = new PhieuYeuCauDichVu { 
                    BenhNhanID = benhnhan.MaBenhNhan,
                    DichVuID = dv.MaDichVu,
                    DonGia = dv.DonGia,
                    NgayLap = DateTime.Now,
                    PhieuKhamBenhID = pk.MaPhieuKhamBenh,
                    PhongID = maPhong,
                    ThoiGianThucHien = DateTime.Now
                };
                db.DbSetPhieuYeuCauDichVu.Add(pkdv);
                db.DbSetPhieuKhamBenhDangCho.Add(new PhieuKhamBenhDangCho
                {
                    BenhNhanID = benhnhan.MaBenhNhan,
                    NgayKham = DateTime.Now,
                    TinhTrangThanhToan = 0,
                    PhieuKhamBenhID = pk.MaPhieuKhamBenh,
                    LyDoKham = pk.LyDoKham
                });
                db.SaveChanges();
                msg = new Message();
                msg.Type = "success";
                msg.Title = "Thành công";
                msg.Content = "Đã lưu thông tin bệnh nhân";
                TempData["msg"] = msg;
                return RedirectToAction("Create");
            }
            DichVu dvKham = db.DbSetDichVu.Where(m => m.TenDichVu == "Dịch vụ khám").First();
            ViewBag.PhongKham = db.DbSetPhong.Where(m => m.DichVuID == dvKham.MaDichVu);//todo;
            return View(benhnhan);
        }

        //
        // GET: /DonTiep/Edit/5
        [Authorize(Roles = "1")]
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
        // POST: /DonTiep/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "1")]
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
        // GET: /DonTiep/Delete/5

        [Authorize(Roles = "1")]
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
        // POST: /DonTiep/Delete/5
        [Authorize(Roles = "1")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BenhNhan benhnhan = db.DbSetBenhNhan.Find(id);
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

    public class Message
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}