using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class GiayPhauThuat
    {
        [Key]
        public int MaGiayPhauThuat { get; set; }
        
        public int BacSiChiDinhID { get; set; }
        
        public int BenhNhanID { get; set; }
        
        public int DichVuID { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name="Thời Gian Thực Hiện")]
        public DateTime ThoigianThucHien { get; set; }
        
        [ForeignKey("BacSiChiDinhID")]
        public virtual NhanVien BacSiChiDinh { get; set; }
        
        [ForeignKey("BenhNhanID")]
        public virtual BenhNhan BenhNhan { get; set; }
        
        [ForeignKey("DichVuID")]
        public virtual DichVu DichVu { get; set; }
    }
}