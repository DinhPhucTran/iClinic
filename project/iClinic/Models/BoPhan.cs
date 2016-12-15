using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("BoPhan")]
    public class BoPhan
    {
        [Key]
        public int MaBoPhan { get; set; }

        [Display(Name = "Tên Bộ Phận")]
        public String TenBoPhan { get; set; }

        [Display(Name = "Ghi Chú")]
        public String GhiChu { get; set; }

        [Display(Name = "Trưởng Bộ Phận")]
        public Nullable<int> NhanVienID { get; set; }

        [ForeignKey("NhanVienID")]
        public virtual NhanVien NhanVien { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }
}