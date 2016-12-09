using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class GiayPhauThuat
    {
        public String MaGiayPhauThuat { get; set; }
        public String MaBacSiChiDinh { get; set; }
        public String MaBenhNhan { get; set; }
        public String MaDichVu { get; set; }
        public DateTime ThoigianThucHien { get; set; }
    }
}