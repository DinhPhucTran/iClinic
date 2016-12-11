using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaCTHD { get; set; }

        public int HoaDonID { get; set; }

        public int PhieuKhamBenhID { get; set; }

        [Display(Name="Số Lượng")]
        public int SoLuong { get; set; }

        [Display(Name="Đơn Giá")]
        public Double DonGia { get; set; }

        [ForeignKey("HoaDonID")]
        public virtual HoaDon HoaDon { get; set; }
        
        [ForeignKey("PhieuKhamBenhID")]
        public virtual PhieuKhamBenh PhieuKhamBenh { get; set; }
    }
}