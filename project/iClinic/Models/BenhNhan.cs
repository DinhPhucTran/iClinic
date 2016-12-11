using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("BenhNhan")]
    public class BenhNhan
    {
        [Key]
        public int MaBenhNhan { get; set; }

        [Display(Name = "Tên bệnh nhân")]
        public String TenBenhNhan { get; set; }

        [Display(Name = "Giới tính")]
        public String GioiTinh { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Nghề nghiệp")]
        public String NgheNghiep { get; set; }

        [Display(Name = "Địa chỉ")]
        public String DiaChi { get; set; }

        [Display(Name = "Số điện thoại")]
        public String SoDT { get; set; }

        [Display(Name = "Tiền sử bệnh")]
        public String TienSuBenh { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày tiếp nhận")]
        public DateTime NgayTiepNhan { get; set; }
    }
}