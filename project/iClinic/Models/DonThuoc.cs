using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class DonThuoc
    {
        [Key]
        public int MaDonThuoc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name="Ngày Kê Đơn")]
        public DateTime NgayKeDon { get; set; }

        [Display(Name="Tổng Tiền")]
        public Double TongTien { get; set; }

        public int PhieuKhamBenhID { get; set; }

        public int BacSiID { get; set; }

        [ForeignKey("BacSiID")]
        public virtual NhanVien BacSiKeDon { get; set; }

        [ForeignKey("PhieuKhamBenhID")]
        public virtual PhieuKhamBenh PhieuKhamBenh { get; set; }
        
        public virtual ICollection<ChiTietDonThuoc> ChiTietDonThuocs { get; set; }
    }
}