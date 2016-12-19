using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("DichVu")]
    public class DichVu
    {
        [Key]
        public int MaDichVu { get; set; }

        [Display(Name = "Tên Dịch Vụ")]
        public String TenDichVu { get; set; }

        [Display(Name = "Đơn Giá")]
        public Double DonGia { get; set; }

        //public int PhongID { get; set; }

        ////[ForeignKey("PhongID")]
        //[NotMapped]
        //public virtual Phong PhongThucHien { get; set; }

        //remove
        //public Nullable<int> BoPhanID { get; set; }

        //[ForeignKey("BoPhanID")]
        //public virtual BoPhan BoPhanDamNhiem { get; set; }
    }
}