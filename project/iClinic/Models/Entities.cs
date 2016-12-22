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
        public DbSet<BenhNhanChoKham> DbSetBenhNhanChoKham { get; set; }
        public DbSet<BoPhan> DbSetBoPhan { get; set; }
        public DbSet<ChiTietDieuTri> DbSetChiTietDieuTri { get; set; }
        public DbSet<ChiTietDonThuoc> DbSetChiTietDonThuoc { get; set; }
        public DbSet<ChiTietHoaDon> DbSetChiTietHoaDon { get; set; }
        public DbSet<ChucVu> DbSetChucVu { get; set; }
        public DbSet<DichVu> DbSetDichVu { get; set; }
        public DbSet<DonThuoc> DbSetDonThuoc { get; set; }
        public DbSet<DonViTinh> DbSetDonViTinh { get; set; }
        public DbSet<GiayChuyenVien> DbSetGiayChuyenVien { get; set; }
        public DbSet<GiayNhapVien> DbSetGiayNhapVien { get; set; }
        public DbSet<GiayPhauThuat> DbSetGiayPhauThuat { get; set; }
        public DbSet<GiayRaVien> DbSetGiayRaVien { get; set; }
        public DbSet<HoaDon> DbSetHoaDon { get; set; }
        public DbSet<HoSoDieuTriNoiTru> DbSetHoSoDieuTriNoiTru { get; set; }
        public DbSet<LoaiNhanVien> DbSetLoaiNhanVien { get; set; }
        public DbSet<NhanVien> DbSetNhanVien { get; set; }
        public DbSet<PhieuKhamBenh> DbSetPhieuKhamBenh { get; set; }
        public DbSet<PhieuKhamBenhDangCho> DbSetPhieuKhamBenhDangCho { get; set; }
        public DbSet<PhieuYeuCauDichVu> DbSetPhieuYeuCauDichVu { get; set; }
        public DbSet<Phong> DbSetPhong { get; set; }
        public DbSet<Thuoc> DbSetThuoc { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BoPhan>()
            //    .HasOptional<NhanVien>(u => u.NhanVien)
            //    .WithOptionalPrincipal();

            //modelBuilder.Entity<NhanVien>()
            //    .HasOptional<BoPhan>(u => u.BoPhan)
            //    .WithOptionalPrincipal();

            modelBuilder.Entity<GiayNhapVien>()
                .HasRequired(a => a.BacSiDieuTri)
                .WithMany()
                .HasForeignKey(u => u.BacSiDieuTriID).WillCascadeOnDelete(false);

            modelBuilder.Entity<GiayNhapVien>()
                .HasRequired(a => a.BenhNhan)
                .WithMany()
                .HasForeignKey(u => u.BenhNhanID).WillCascadeOnDelete(false);

            modelBuilder.Entity<GiayNhapVien>()
                .HasRequired(a => a.NhanVienTiepNhan)
                .WithMany()
                .HasForeignKey(u => u.NhanVienTiepNhanID).WillCascadeOnDelete(false);

            modelBuilder.Entity<HoSoDieuTriNoiTru>()
                .HasRequired(a => a.BacSiDieuTri)
                .WithMany()
                .HasForeignKey(u => u.BacSiDieuTriID).WillCascadeOnDelete(false);

            modelBuilder.Entity<HoSoDieuTriNoiTru>()
                .HasRequired(a => a.YTaDieuTri)
                .WithMany()
                .HasForeignKey(u => u.YTaDieuTriID).WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasRequired(a => a.PhieuKhamBenh)
                .WithMany()
                .HasForeignKey(u => u.PhieuKhamBenhID).WillCascadeOnDelete(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasRequired(a => a.PhieuYeuCauDichVu)
                .WithMany()
                .HasForeignKey(u => u.PhieuYeuCauDichVuID).WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuYeuCauDichVu>()
                .HasOptional<NhanVien>(u => u.BacSi).WithMany().Map(m => m.MapKey("BacSiID"));

            modelBuilder.Entity<BenhNhanChoKham>()
                .HasRequired(a => a.BenhNhan)
                .WithMany()
                .HasForeignKey(u => u.BenhNhanID).WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuKhamBenhDangCho>()
                .HasRequired(a => a.PhieuKhamBenh)
                .WithMany()
                .HasForeignKey(u => u.PhieuKhamBenhID).WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuYeuCauDichVu>()
                .HasRequired(a => a.PhongKham)
                .WithMany()
                .HasForeignKey(u => u.PhongID).WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuYeuCauDichVu>()
                .HasRequired(a => a.DichVu)
                .WithMany()
                .HasForeignKey(u => u.DichVuID).WillCascadeOnDelete(false);

            modelBuilder.Entity<Thuoc>()
                .HasRequired(a => a.DonViTinh)
                .WithMany()
                .HasForeignKey(u => u.DonViTinhID).WillCascadeOnDelete(false);


            modelBuilder.Entity<DonThuoc>()
                .HasRequired(a => a.PhieuKhamBenh)
                .WithMany()
                .HasForeignKey(u => u.PhieuKhamBenhID).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}