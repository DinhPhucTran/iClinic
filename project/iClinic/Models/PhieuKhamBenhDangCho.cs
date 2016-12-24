﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("PhieuKhamBenhDangCho")]
    public class PhieuKhamBenhDangCho
    {
        [Key]
        public int MaPhieuKhamBenhDangCho { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Ngày Khám")]
        public DateTime NgayKham { get; set; }

        [Display(Name = "Tiền Sử Bệnh")]
        public String TienSuBenh { get; set; }

        [Display(Name = "Chẩn Đoán")]
        public String ChanDoan { get; set; }

        [Display(Name = "Lời Dặn")]
        public String LoiDan { get; set; }

        [Display(Name = "Mã Bệnh Nhân")]
        public int BenhNhanID { get; set; }

        public int BacSiID { get; set; }

        public int PhieuKhamBenhID { get; set; }

        [ForeignKey("BenhNhanID")]
        public virtual BenhNhan BenhNhan { get; set; }

        [ForeignKey("BacSiID")]
        public virtual NhanVien BacSi { get; set; }

        [ForeignKey("PhieuKhamBenhID")]
        public virtual PhieuKhamBenh PhieuKhamBenh { get; set; }
        //public virtual ICollection<PhieuYeuCauDichVu> PhieuYeuCauDichVus { get; set; }
    }
}