using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("LoaiNhanVien")]
    public class LoaiNhanVien
    {
        [Key]
        public int MaLoaiNhanVien { get; set; }
        [Display(Name="Loại Nhân Viên")]
        public String TenLoaiNhanVien { get; set; }
    }
}