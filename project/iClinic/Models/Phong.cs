using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("Phong")]
    public class Phong
    {
        [Key]
        public int MaPhong { get; set; }
       
        [Display(Name="Tên Phòng")]
        public String TenPhong { get; set; }
        
        public int BoPhanID { get; set; }
        
        [ForeignKey("BoPhanID")]
        public virtual BoPhan BoPhan { get; set; }
    }
}