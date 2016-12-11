using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class ChiTietDonThuoc
    {
        [Key]
        public int MaCTDT { get; set; }

        public int DonThuocID { get; set; }

        public int ThuocID { get; set; }

        [Display(Name="Đơn Giá")]
        public Double DonGia { get; set; }

        [Display(Name="Số Lượng")]
        public int SoLuong { get; set; }

        [Display(Name="Ngày Dùng")]
        public int NgayDung { get; set; }

        [Display(Name="Sáng")]
        public int Sang { get; set; }

        [Display(Name="Trưa")]
        public int Trua { get; set; }

        [Display(Name="Chiều")]
        public int Chieu { get; set; }

        [Display(Name="Tối")]
        public int Toi { get; set; }

        [ForeignKey("DonThuocID")]
        public virtual DonThuoc DonThuoc { get; set; }
        
        [ForeignKey("ThuocID")]
        public virtual Thuoc Thuoc { get; set; }
    }
}