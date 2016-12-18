using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("DonViTinh")]
    public class DonViTinh
    {
        [Key]
        public int MaDonViTinh { get; set; }

        [Display(Name="Tên Đơn Vị Tính")]
        [Required]
        public String TenDonViTinh { get; set; }
    }
}