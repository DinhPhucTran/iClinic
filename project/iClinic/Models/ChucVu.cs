using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        public int MaChucVu { get; set; }
        [Display(Name = "Tên Chức Vụ")]
        public String TenChucVu { get; set; }
    }
}