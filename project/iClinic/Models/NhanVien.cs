using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class NhanVien
    {
        public String MaNhanVien { get; set; }
        public String LoaiNhanVien { get; set; }
        public String TenNhanVien { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public String SoDT { get; set; }
        public String DiaChi { get; set; }
        public String MaChucVu { get; set; }
        public String MaPhong { get; set; }
    }
}