using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class GiayNhapVien
    {
        public String MaGiayNhapVien { get; set; }
        public String MaBenhNhan { get; set; }
        public String MaBacSiDieuTri { get; set; }
        public String MaNguoiTiepNhan { get; set; }
        public String ChanDoan { get; set; }
        public DateTime NgayNhapVien { get; set; }
        public String GhiChu { get; set; }
    }
}