using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class ChiTietHoaDon
    {
        public String MaHoaDon { get; set; }
        public String MaPhieuYeuCauDichVu { get; set; }
        public int SoLuong { get; set; }
        public Double DonGia { get; set; }
    }
}