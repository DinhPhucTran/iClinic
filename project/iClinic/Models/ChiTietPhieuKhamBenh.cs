using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    [Table("ChiTietPhieuKhamBenh")]
    public class ChiTietPhieuKhamBenh
    {
        [Key]
        public int MaCTPK { get; set; }

        public int PhieuKhamBenhID { get; set; }

        public int PhieuYeuCauDichVuID { get; set; }

        [ForeignKey("PhieuKhamBenhID")]
        public virtual PhieuKhamBenh PhieuKhamBenh { get; set; }
        
        [ForeignKey("PhieuYeuCauDichVuID")]
        public virtual PhieuYeuCauDichVu PhieuYeuCauDichVu { get; set; }
    }
}