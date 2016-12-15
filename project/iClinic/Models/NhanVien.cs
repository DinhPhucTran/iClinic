using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public int MaNhanVien { get; set; }
        public int LoaiNhanVienID { get; set; }
        public int ChucVuID { get; set; }
        public int PhongID { get; set; }

        [Display(Name = "Tên Nhân Viên")]
        public String TenNhanVien { get; set; }

        [Display(Name = "Giới Tính")]
        public String GioiTinh { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Số Điện Thoại")]
        public String SoDT { get; set; }

        [Display(Name = "Địa Chỉ")]
        public String DiaChi { get; set; }

        [ForeignKey("LoaiNhanVienID")]
        public virtual LoaiNhanVien LoaiNhanVien { get; set; }

        [ForeignKey("ChucVuID")]
        public virtual ChucVu ChucVu { get; set; }

        [ForeignKey("PhongID")]
        public virtual Phong Phong { get; set; }
    }
}