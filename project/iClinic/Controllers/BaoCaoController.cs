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

        public ActionResult DoanhThu()
        {
            return View();
        }

        public ActionResult KhamBenh()
        {
            return View();
        }

        public string GetDoanhThuThang(int thang = 1, int nam = 2016)
        {
            double i = db.DbSetHoaDon.Where(h => h.NgayThanhToan.Month == thang && h.NgayThanhToan.Year == nam).Sum(h => (double?)h.TongTien) ?? 0;
            return i.ToString();
        }

        public string GetTongDoanhThuNam(int nam = 2016)
        {
            double i = db.DbSetHoaDon.Where(h => h.NgayThanhToan.Year == nam).Sum(h => (double?)h.TongTien) ?? 0;
            return i.ToString();
        }

        public string GetSoLuotKhamThang(int thang = 1, int nam = 2016)
        {
            int c = db.DbSetPhieuKhamBenh.Count(p => p.NgayKham.Month == thang && p.NgayKham.Year == nam);
            return c.ToString();
        }

        public string GetSoLuotKhamNam(int nam = 2016)
        {
            int c = db.DbSetPhieuKhamBenh.Count(p => p.NgayKham.Year == nam);
            return c.ToString();
        }

        public string GetSoLuotDieuTriThang(int thang = 1, int nam = 2016)
        {
            int c = db.DbSetGiayNhapVien.Count(p => p.NgayNhapVien.Month == thang && p.NgayNhapVien.Year == nam);
            return c.ToString();
        }

        public string GetSoLuotDieuTriNam(int nam = 2016)
        {
            int c = db.DbSetGiayNhapVien.Count(g => g.NgayNhapVien.Year == nam);
            return c.ToString();
        }

        public string GetDoanhThu()
        {
            string data = "[";

            double[] t = new double[13];
            for (int i = 1; i < 13; i++)
            {
                //t[i] = db.DbSetHoaDon.Where(h => h.NgayThanhToan.Month == i && h.NgayThanhToan.Year == 2016).Sum(h => (double?)h.TongTien) ?? 0;
                t[i] = db.DbSetHoaDon.Where(h => h.NgayThanhToan.Month == i && h.NgayThanhToan.Year == DateTime.Today.Year).Sum(h => (double?)h.TongTien) ?? 0;
            }

            for (int i = 1; i < 12; i++)
            {
                data += (t[i] + ",");
            }
            data += (t[12] + "]");

            return data;
        }

        public string GetSoLuotKham()
        {
            string data = "[";

            int[] t = new int[13];
            for (int i = 1; i < 13; i++)
            {
                //t[i] = db.DbSetPhieuKhamBenh.Count(p => p.NgayKham.Month == i && p.NgayKham.Year == 2016);
                t[i] = db.DbSetPhieuKhamBenh.Count(p => p.NgayKham.Month == i && p.NgayKham.Year == DateTime.Now.Year);
            }

            for (int i = 1; i < 12; i++)
            {
                data += (t[i] + ",");
            }
            data += (t[12] + "]");
            
            return data;
        }

        public string GetSoLuotDieuTri()
        {
            string data = "[";

            int[] t = new int[13];
            for (int i = 1; i < 13; i++)
            {
                t[i] = db.DbSetGiayNhapVien.Count(g => g.NgayNhapVien.Month == i && g.NgayNhapVien.Year == DateTime.Today.Year);
                //t[i] = db.DbSetGiayNhapVien.Count(p => p.NgayNhapVien.Month == i && p.NgayNhapVien.Year == 2017);
            }

            for (int i = 1; i < 12; i++)
            {
                data += (t[i] + ",");
            }
            data += (t[12] + "]");

            return data;
        }

    }
}
