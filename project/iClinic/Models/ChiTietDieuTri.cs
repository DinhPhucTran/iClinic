using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class ChiTietDieuTri
    {
        [Key]
        public int MaCTDT { get; set; }

        public int HoSoDieuTriNoiTruID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày Điều Trị")]
        public DateTime NgayDieuTri { get; set; }

        [Display(Name="Tình Trạng")]
        public String TinhTrang { get; set; }

        [Display(Name="Ghi Chú")]
        public String GhiChu { get; set; }
        
        [ForeignKey("HoSoDieuTriNoiTruID")]
        public virtual HoSoDieuTriNoiTru HoSoDieuTriNoiTru { get; set; }
    }
}