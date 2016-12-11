using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name="Ngày Thanh Toán")]
        public DateTime NgayThanhToan { get; set; }
        
        [Display(Name="Tổng Tiền")]
        public Double TongTien { get; set; }
        
        public int PhieuKhamBenhID { get; set; }
        
        [ForeignKey("PhieuKhamBenhID")]
        public virtual PhieuKhamBenh PhieuKhamBenh { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}