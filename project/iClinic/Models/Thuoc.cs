using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("Thuoc")]
    public class Thuoc
    {
        [Key]
        public int MaThuoc { get; set; }
        
        [Display(Name="Tên Thuốc")]
        [Required]
        public String TenThuoc { get; set; }
        
        [Display(Name="Đơn Giá")]
        public Double DonGia { get; set; }
        
        [Display(Name="Số Lượng")]
        public int SoLuong { get; set; }
        
        public int DonViTinhID { get; set; }
        
        [ForeignKey("DonViTinhID")]
        public virtual DonViTinh DonViTinh { get; set; }
    }
}