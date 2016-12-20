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
        [Required(ErrorMessage="Vui lòng nhập tên thuốc")]
        public String TenThuoc { get; set; }
        
        [Display(Name="Đơn Giá")]
        [Required(ErrorMessage="Vui lòng nhập đơn giá")]
        public Double DonGia { get; set; }
        
        [Display(Name="Số Lượng")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        public int SoLuong { get; set; }
        
        public int DonViTinhID { get; set; }
        
        [ForeignKey("DonViTinhID")]
        public virtual DonViTinh DonViTinh { get; set; }
    }
}