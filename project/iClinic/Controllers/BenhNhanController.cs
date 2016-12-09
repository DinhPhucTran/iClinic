using iClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iClinic.Controllers
{
    public class BenhNhanController : Controller
    {
        //
        // GET: /BenhNhan/

        public ActionResult Index()
        {
            var employees = from e in GetEmployeeList() orderby e.MaBenhNhan select e;
            return View(employees);
        }

        [NonAction]
        public List<BenhNhan> GetEmployeeList() 
        {
            return new List<BenhNhan>{
                new BenhNhan{
                    MaBenhNhan = "1",
                    TenBenhNhan = "Nguyen Mot",
                    NgaySinh = DateTime.Now,
                    NgheNghiep = "Unknown",
                    DiaChi = "quan 1 tphcm",
                    SoDT = "0909090909",
                    TienSuBenh = "...",
                    NgayTiepNhan = DateTime.Now
                },
                new BenhNhan{
                    MaBenhNhan = "1",
                    TenBenhNhan = "Nguyen Hai",
                    NgaySinh = DateTime.Now,
                    NgheNghiep = "Unknown",
                    DiaChi = "quan 1 tphcm",
                    SoDT = "0909090909",
                    TienSuBenh = "...",
                    NgayTiepNhan = DateTime.Now
                },
                new BenhNhan{
                    MaBenhNhan = "3",
                    TenBenhNhan = "Nguyen Ba",
                    NgaySinh = DateTime.Now,
                    NgheNghiep = "Unknown",
                    DiaChi = "quan 1 tphcm",
                    SoDT = "0909090909",
                    TienSuBenh = "...",
                    NgayTiepNhan = DateTime.Now
                }
            };
        }
    }
}
