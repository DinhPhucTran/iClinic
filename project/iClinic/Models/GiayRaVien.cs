using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class GiayRaVien
    {
        public String MaGiayRaVien { get; set; }
        public String MaBenhNhan { get; set; }
        public String MaBacSiDieuTri { get; set; }
        public String MaGiayNhapVien { get; set; }
        public DateTime NgayRaVien { get; set; }
        public String ChanDoan { get; set; }
        public String LoiDan { get; set; }
    }
}