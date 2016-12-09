using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class PhieuKhamBenh
    {
        public String MaPhieuKhamBenh { get; set; }
        public DateTime NgayKham { get; set;}
        public String ChanDoan { get; set; }
        public String LoiDan { get; set; }
        public String MaBenhNhan { get; set; }
        public String MaBacSi { get; set; }
    }
}