using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class ChucVu
    {
        [Key]
        public int MaChucVu { get; set; }
        [Display(Name="Tên Chức Vụ")]
        public String TenChucVu { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}