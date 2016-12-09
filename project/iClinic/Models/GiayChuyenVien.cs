using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class GiayChuyenVien
    {
        public String MaGiayChuyenVien { get; set; }
        public String MaBenhNhan { get; set; }
        public String MaBacSiDieuTri { get; set; }
        public String MaGiayNhapVien { get; set; }
        public DateTime NgayChuyenVien { get; set; }
        public String ChanDoan { get; set; }
        public String TinhTrangLucChuyenVien { get; set; }
        public String LyDoChuyenVien { get; set; }
        public String PhuongTienChuyenVien { get; set; }
        public String TenNguoiDuaDi { get; set; }
        public String TenBVChuyenDen { get; set; }
        public String GhiChu { get; set; }
    }
}