using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class DonThuoc
    {
        public String MaDonThuoc { get; set; }
        public DateTime NgayKeDon { get; set; }
        public double TongTien { get; set; }
        public String MaPhieuKhambenh { get; set; }
        public String MaBacSiKeDon { get; set; }
    }
}