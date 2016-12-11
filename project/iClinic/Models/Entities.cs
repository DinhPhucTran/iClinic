using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iClinic.Models
{
    public class Entities : DbContext
    {
        public Entities() { }

        public DbSet<BenhNhan> DbSetBenhNhan { get; set; }
        public DbSet<LoaiNhanVien> DbSetLoaiNhanVien { get; set; }
        public DbSet<Phong> DbSetPhong { get; set; }
        public DbSet<BoPhan> DbSetBoPhan { get; set; }
    }
}