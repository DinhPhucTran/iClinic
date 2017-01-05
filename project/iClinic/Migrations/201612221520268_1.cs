namespace iClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            
            
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PhieuKhamBenhDangCho", new[] { "PhieuKhamBenhID" });
            DropIndex("dbo.PhieuKhamBenhDangCho", new[] { "BacSiID" });
            DropIndex("dbo.PhieuKhamBenhDangCho", new[] { "BenhNhanID" });
            DropIndex("dbo.GiayRaVien", new[] { "GiayNhapVienID" });
            DropIndex("dbo.GiayRaVien", new[] { "BacSiDieuTriID" });
            DropIndex("dbo.GiayRaVien", new[] { "BenhNhanID" });
            DropIndex("dbo.GiayPhauThuat", new[] { "DichVuID" });
            DropIndex("dbo.GiayPhauThuat", new[] { "BenhNhanID" });
            DropIndex("dbo.GiayPhauThuat", new[] { "BacSiChiDinhID" });
            DropIndex("dbo.GiayNhapVien", new[] { "NhanVienTiepNhanID" });
            DropIndex("dbo.GiayNhapVien", new[] { "BacSiDieuTriID" });
            DropIndex("dbo.GiayNhapVien", new[] { "BenhNhanID" });
            DropIndex("dbo.GiayChuyenVien", new[] { "GiayNhapVienID" });
            DropIndex("dbo.GiayChuyenVien", new[] { "BacSiID" });
            DropIndex("dbo.GiayChuyenVien", new[] { "BenhNhanID" });
            DropIndex("dbo.HoaDon", new[] { "PhieuKhamBenhID" });
            DropIndex("dbo.ChiTietHoaDon", new[] { "PhieuYeuCauDichVuID" });
            DropIndex("dbo.ChiTietHoaDon", new[] { "HoaDonID" });
            DropIndex("dbo.Thuoc", new[] { "DonViTinhID" });
            DropIndex("dbo.PhieuYeuCauDichVu", new[] { "PhieuKhamBenhID" });
            DropIndex("dbo.PhieuYeuCauDichVu", new[] { "DichVuID" });
            DropIndex("dbo.PhieuYeuCauDichVu", new[] { "BacSiID" });
            DropIndex("dbo.PhieuYeuCauDichVu", new[] { "PhongID" });
            DropIndex("dbo.PhieuKhamBenh", new[] { "BacSiID" });
            DropIndex("dbo.PhieuKhamBenh", new[] { "BenhNhanID" });
            DropIndex("dbo.DonThuoc", new[] { "BacSiID" });
            DropIndex("dbo.DonThuoc", new[] { "PhieuKhamBenhID" });
            DropIndex("dbo.ChiTietDonThuoc", new[] { "ThuocID" });
            DropIndex("dbo.ChiTietDonThuoc", new[] { "DonThuocID" });
            DropIndex("dbo.Phong", new[] { "DichVuID" });
            DropIndex("dbo.NhanVien", new[] { "ChucVuID" });
            DropIndex("dbo.NhanVien", new[] { "BoPhanID" });
            DropIndex("dbo.NhanVien", new[] { "LoaiNhanVienID" });
            DropIndex("dbo.HoSoDieuTriNoiTru", new[] { "PhongID" });
            DropIndex("dbo.HoSoDieuTriNoiTru", new[] { "YTaDieuTriID" });
            DropIndex("dbo.HoSoDieuTriNoiTru", new[] { "BacSiDieuTriID" });
            DropIndex("dbo.HoSoDieuTriNoiTru", new[] { "BenhNhanID" });
            DropIndex("dbo.ChiTietDieuTri", new[] { "HoSoDieuTriNoiTruID" });
            DropIndex("dbo.BenhNhanChoKhams", new[] { "BenhNhanID" });
        }
    }
}
