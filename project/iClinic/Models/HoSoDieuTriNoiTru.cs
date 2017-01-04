using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("HoSoDieuTriNoiTru")]
    public class HoSoDieuTriNoiTru
    {
        [Key]
        public int MaHoSo { get; set; }
        
        public int BenhNhanID { get; set; }
        
        public int BacSiDieuTriID { get; set; }
        
        public int? YTaDieuTriID { get; set; }
        
        public int? PhongID { get; set; }

        public int GiayNhapVienID { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name="Ngày Bắt Đầu Điều Trị")]
        public DateTime NgayBatDauDieuTri { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name="Ngày Kết Thúc Điều Trị")]
        public DateTime? NgayKetThucDieuTri { get; set; }
        
        [Display(Name="Chẩn Đoán")]
        public String ChanDoan { get; set; }
        
        [ForeignKey("BenhNhanID")]
        public virtual BenhNhan BenhNhan { get; set; }
        
        [ForeignKey("BacSiDieuTriID")]
        public virtual NhanVien BacSiDieuTri { get; set; }
        
        [ForeignKey("YTaDieuTriID")]
        public virtual NhanVien YTaDieuTri { get; set; }
        
        [ForeignKey("PhongID")]
        public virtual Phong Phong { get; set; }

        [ForeignKey("GiayNhapVienID")]
        public virtual GiayNhapVien GiayNhapVien { get; set;}
        
        public virtual ICollection<ChiTietDieuTri> ChiTietDieuTris { get; set; }
    }
}