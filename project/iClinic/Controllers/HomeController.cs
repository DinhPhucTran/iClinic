using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;
using iClinic.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

namespace iClinic.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("abc")]
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString("T");
        }

        public string GetSoBenhNhanCho()
        {
            string count = "0";
            int c = db.DbSetPhieuKhamBenhDangCho.Count();
            count = c.ToString();
            return count;
        }

        public string GetDoanhThuTheoNgay()
        {
            string income = "0";
            double i = db.DbSetHoaDon.Where(h => DbFunctions.TruncateTime(h.NgayThanhToan) < (DateTime?)DateTime.Today).Sum(h => (double?)h.TongTien) ?? 0;
            income = i.ToString("N0");
            return income;
        }
    }
}
