﻿using System;
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

        public Nullable<int> BoPhanID { get; set; }

        public Nullable<int> ChucVuID { get; set; }
        //public int PhongID { get; set; }

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
        [Display(Name = "Loại Nhân Viên")]
        public virtual LoaiNhanVien LoaiNhanVien { get; set; }

        [ForeignKey("BoPhanID")]
        [Display(Name = "Bộ Phận")]
        //[NotMapped]
        public virtual BoPhan BoPhan { get; set; }

        [ForeignKey("ChucVuID")]
        [Display(Name = "Chức Vụ")]
        public virtual ChucVu ChucVu { get; set; }

        //[ForeignKey("PhongID")]
        //public virtual Phong Phong { get; set; }
    }
}