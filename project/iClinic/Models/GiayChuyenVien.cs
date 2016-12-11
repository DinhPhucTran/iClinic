using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("GiayChuyenVien")]
    public class GiayChuyenVien
    {
        [Key]
        public int MaGiayChuyenVien { get; set; }
        
        public int BenhNhanID { get; set; }
        
        public int BacSiID { get; set; }
        
        public int GiayNhapVienID { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name="Ngày Chuyển Viện")]
        public DateTime NgayChuyenVien { get; set; }
        
        [Display(Name="Chẩn Đoán")]
        public String ChanDoan { get; set; }
        
        [Display(Name="Tình Trạng Lúc Chuyển Viện")]
        public String TinhTrangLucChuyenVien { get; set; }
        
        [Display(Name="Lý Do Chuyển Viện")]
        public String LyDoChuyenVien { get; set; }
        
        [Display(Name="Phương Tiện Chuyển Viện")]
        public String PhuongTienChuyenVien { get; set; }
        
        [Display(Name="Người Đưa Đi")]
        public String TenNguoiDuaDi { get; set; }
        
        [Display(Name="Bệnh Viện Chuyển Đến")]
        public String TenBVChuyenDen { get; set; }
        
        [Display(Name="Ghi Chú")]
        public String GhiChu { get; set; }

        [ForeignKey("GiayNhapVienID")]
        public virtual GiayNhapVien GiayNhapVien { get; set; }

        [ForeignKey("BenhNhanID")]
        public virtual BenhNhan BenhNhan { get; set; }

        [ForeignKey("BacSiID")]
        public virtual NhanVien BacSiDieuTri { get; set; }
    }
}