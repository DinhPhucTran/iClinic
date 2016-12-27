using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("PhieuKhamBenh")]
    public class PhieuKhamBenh
    {
        [Key]
        public int MaPhieuKhamBenh { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name="Ngày Khám")]
        public DateTime NgayKham { get; set;}

        [Display(Name="Lý Do Khám")]
        public String LyDoKham { get; set; }

        [Display(Name="Chẩn Đoán")]
        public String ChanDoan { get; set; }
        
        [Display(Name="Lời Dặn")]
        public String LoiDan { get; set; }
        
        [Display(Name="Mã Bệnh Nhân")]
        public int BenhNhanID { get; set; }
        
        public Nullable<int> BacSiID { get; set; }

        public int TinhTrangThanhToan { get; set; }

        [ForeignKey("BenhNhanID")]
        public virtual BenhNhan BenhNhan { get; set; }
        
        [ForeignKey("BacSiID")]
        public virtual NhanVien BacSi { get; set; }
        
        public virtual ICollection<PhieuYeuCauDichVu> PhieuYeuCauDichVus { get; set; }

        [NotMapped]
        public bool TinhTrangTT {
            get {
                return TinhTrangThanhToan == 1 ? true : false;
            }
        }
    }
}