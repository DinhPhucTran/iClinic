using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("PhieuYeuCauDichVu")]
    public class PhieuYeuCauDichVu
    {
        [Key]
        public int MaPhieuYeuCauDichVu { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Thời Gian Thực Hiện")]
        public DateTime ThoiGianThucHien { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày Lập")]
        public DateTime NgayLap { get; set; }

        [Display(Name = "Đơn Giá")]
        public Double DonGia { get; set; }//add

        [Display(Name = "Chẩn Đoán")]
        public String ChanDoan { get; set; }

        [Display(Name = "Lời Dặn")]
        public String LoiDan { get; set; }

        public int BenhNhanID { get; set; }

        public int BacSiID { get; set; }

        public int DichVuID { get; set; }

        [ForeignKey("BenhNhanID")]
        public virtual BenhNhan BenhNhan { get; set; }

        [ForeignKey("BacSiID")]
        public virtual NhanVien BacSi { get; set; }

        [ForeignKey("DichVuID")]
        public virtual DichVu DichVu { get; set; }
    }
}