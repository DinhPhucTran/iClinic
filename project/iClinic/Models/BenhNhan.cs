using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class BenhNhan
    {
        public String MaBenhNhan { get; set; }
        public String TenBenhNhan { get; set; }
        public String GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public String NgheNghiep { get; set; }
        public String DiaChi { get; set; }
        public String SoDT { get; set; }
        public String TienSuBenh { get; set; }
        public DateTime NgayTiepNhan { get; set; }
    }
}