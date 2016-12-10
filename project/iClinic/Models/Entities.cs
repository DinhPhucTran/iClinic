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
    }
}