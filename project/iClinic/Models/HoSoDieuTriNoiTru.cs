using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class HoSoDieuTriNoiTru
    {
        public String MaHoSo { get; set; }
        public String MaBenhNhan { get; set; }
        public String MaBSDieuTri { get; set; }
        public String MaYTaDieuTri { get; set; }
        public String MaPhong { get; set; }
        public String ChanDoan { get; set; }
        public DateTime NgayBatDauDieuTri { get; set; }
        public DateTime NgayKetThucDieuTri { get; set; }
    }
}