using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class Thuoc
    {
        public String MaThuoc { get; set; }
        public String TenThuoc { get; set; }
        public Double DonGia { get; set; }
        public String MaDonViTinh { get; set; }
        public int SoLuong { get; set; }
    }
}