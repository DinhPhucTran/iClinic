using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iClinic.Models;

namespace iClinic.Controllers
{
    public class BaoCaoController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /BaoCao/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDoanhThuThang(int thang)
        {
            double i = db.DbSetHoaDon.Where(h => h.NgayThanhToan.Month == thang).Sum(h => (double?)h.TongTien) ?? 0;
            return View(i);
        }

    }
}
