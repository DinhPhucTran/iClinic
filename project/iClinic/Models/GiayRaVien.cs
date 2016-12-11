using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class GiayRaVien
    {
        [Key]
        public int MaGiayRaVien { get; set; }
        
        public int BenhNhanID { get; set; }
        
        public int BacSiDieuTriID { get; set; }
        
        public int GiayNhapVienID { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name="Ngày Ra Viện")]
        public DateTime NgayRaVien { get; set; }
        
        [Display(Name="Chẩn Đoán")]
        public String ChanDoan { get; set; }
        
        [Display(Name="Lời Dặn")]
        public String LoiDan { get; set; }
        
        [ForeignKey("BenhNhanID")]
        public virtual BenhNhan BenhNhan { get; set; }
        
        [ForeignKey("BacSiDieuTriID")]
        public virtual NhanVien BacSiDieuTri { get; set; }
        
        [ForeignKey("GiayNhapVienID")]
        public virtual GiayNhapVien GiayNhapVien { get; set; }
    }
}