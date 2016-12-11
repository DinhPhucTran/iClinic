using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class LoaiNhanVien
    {
        [Key]
        public int MaLoaiNhanVien { get; set; }
        [Display(Name="Loại Nhân Viên")]
        public String TenLoaiNhanVien { get; set; }

        public virtual ICollection<NhanVien> DanhSachNhanVien { get; set; }
    }
}