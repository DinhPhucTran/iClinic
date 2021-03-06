﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("GiayNhapVien")]
    public class GiayNhapVien
    {
        [Key]
        public int MaGiayNhapVien { get; set; }
        
        [Display(Name = "Mã Bệnh Nhân")]
        public int BenhNhanID { get; set; }

        [Display(Name = "Mã Bác Sĩ")]
        public int BacSiDieuTriID { get; set; }
        
        public int? NhanVienTiepNhanID { get; set; }

        [Display(Name = "Chẩn Đoán")]
        public String ChanDoan { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày Nhập Viện")]
        public DateTime NgayNhapVien { get; set; }

        [Display(Name = "Ghi Chú")]
        public String GhiChu { get; set; }

        [ForeignKey("BenhNhanID")]
        public virtual BenhNhan BenhNhan { get; set; }

        [ForeignKey("BacSiDieuTriID")]
        public virtual NhanVien BacSiDieuTri { get; set; } 

        [ForeignKey("NhanVienTiepNhanID")]
        public virtual NhanVien NhanVienTiepNhan { get; set; }
    }
}