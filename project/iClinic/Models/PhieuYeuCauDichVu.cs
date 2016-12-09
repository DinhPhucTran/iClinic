using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class PhieuYeuCauDichVu
    {
        public String MaPhieuYeuCauDichVu { get; set; }
        public DateTime ThoiGianThucHien { get; set; }
        public DateTime NgayLap { get; set; }
        public String ChanDoan { get; set; }
        public String LoiDan { get; set; }
        public String MaBenhNhan { get; set; }
        public String MaBacSi { get; set; }
        public String MaDichVu { get; set; }
    }
}