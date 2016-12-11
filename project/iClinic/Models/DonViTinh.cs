using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class DonViTinh
    {
        [Key]
        public int MaDonViTinh { get; set; }

        [Display(Name="Tên Đơn Vị Tính")]
        public String TenDonViTinh { get; set; }

        public virtual ICollection<Thuoc> Thuocs { get; set; }
        
        public virtual ICollection<ChiTietDonThuoc> ChiTietDonThuocs { get; set; }
    }
}