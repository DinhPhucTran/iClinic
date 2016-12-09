using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class ChiTietDonThuoc
    {
        public String MaDonThuoc { get; set; }
        public String MaThuoc { get; set; }
        public Double DonGia { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayDung { get; set; }
        public int Sang { get; set; }
        public int Trua { get; set; }
        public int Chieu { get; set; }
        public int Toi { get; set; }
    }
}