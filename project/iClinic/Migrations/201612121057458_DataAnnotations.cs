namespace iClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BenhNhans", newName: "BenhNhan");
            CreateTable(
                "dbo.BoPhan",
                c => new
                    {
                        MaBoPhan = c.Int(nullable: false, identity: true),
                        TenBoPhan = c.String(),
                        NhanVienID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaBoPhan)
                .ForeignKey("dbo.NhanVien", t => t.NhanVienID, cascadeDelete: true)
                .Index(t => t.NhanVienID);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNhanVien = c.Int(nullable: false, identity: true),
                        LoaiNhanVienID = c.Int(nullable: false),
                        ChucVuID = c.Int(nullable: false),
                        PhongID = c.Int(nullable: false),
                        TenNhanVien = c.String(),
                        GioiTinh = c.Boolean(nullable: false),
                        NgaySinh = c.DateTime(nullable: false),
                        SoDT = c.String(),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaNhanVien)
                .ForeignKey("dbo.LoaiNhanVien", t => t.LoaiNhanVienID, cascadeDelete: true)
                .ForeignKey("dbo.ChucVu", t => t.ChucVuID, cascadeDelete: true)
                .ForeignKey("dbo.Phong", t => t.PhongID, cascadeDelete: true)
                .Index(t => t.LoaiNhanVienID)
                .Index(t => t.ChucVuID)
                .Index(t => t.PhongID);
            
            CreateTable(
                "dbo.LoaiNhanVien",
                c => new
                    {
                        MaLoaiNhanVien = c.Int(nullable: false, identity: true),
                        TenLoaiNhanVien = c.String(),
                    })
                .PrimaryKey(t => t.MaLoaiNhanVien);
            
            CreateTable(
                "dbo.ChucVu",
                c => new
                    {
                        MaChucVu = c.Int(nullable: false, identity: true),
                        TenChucVu = c.String(),
                    })
                .PrimaryKey(t => t.MaChucVu);
            
            CreateTable(
                "dbo.Phong",
                c => new
                    {
                        MaPhong = c.Int(nullable: false, identity: true),
                        TenPhong = c.String(),
                        BoPhanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhong)
                .ForeignKey("dbo.BoPhan", t => t.BoPhanID)
                .Index(t => t.BoPhanID);
            
            CreateTable(
                "dbo.ChiTietDieuTri",
                c => new
                    {
                        MaCTDT = c.Int(nullable: false, identity: true),
                        HoSoDieuTriNoiTruID = c.Int(nullable: false),
                        NgayDieuTri = c.DateTime(nullable: false),
                        TinhTrang = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaCTDT)
                .ForeignKey("dbo.HoSoDieuTriNoiTru", t => t.HoSoDieuTriNoiTruID, cascadeDelete: true)
                .Index(t => t.HoSoDieuTriNoiTruID);
            
            CreateTable(
                "dbo.HoSoDieuTriNoiTru",
                c => new
                    {
                        MaHoSo = c.Int(nullable: false, identity: true),
                        BenhNhanID = c.Int(nullable: false),
                        BacSiDieuTriID = c.Int(nullable: false),
                        YTaDieuTriID = c.Int(nullable: false),
                        PhongID = c.Int(nullable: false),
                        NgayBatDauDieuTri = c.DateTime(nullable: false),
                        NgayKetThucDieuTri = c.DateTime(nullable: false),
                        ChanDoan = c.String(),
                    })
                .PrimaryKey(t => t.MaHoSo)
                .ForeignKey("dbo.BenhNhan", t => t.BenhNhanID, cascadeDelete: true)
                .ForeignKey("dbo.NhanVien", t => t.BacSiDieuTriID)
                .ForeignKey("dbo.NhanVien", t => t.YTaDieuTriID)
                .ForeignKey("dbo.Phong", t => t.PhongID, cascadeDelete: true)
                .Index(t => t.BenhNhanID)
                .Index(t => t.BacSiDieuTriID)
                .Index(t => t.YTaDieuTriID)
                .Index(t => t.PhongID);
            
            CreateTable(
                "dbo.ChiTietDonThuoc",
                c => new
                    {
                        MaCTDT = c.Int(nullable: false, identity: true),
                        DonThuocID = c.Int(nullable: false),
                        ThuocID = c.Int(nullable: false),
                        DonGia = c.Double(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        NgayDung = c.Int(nullable: false),
                        Sang = c.Int(nullable: false),
                        Trua = c.Int(nullable: false),
                        Chieu = c.Int(nullable: false),
                        Toi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaCTDT)
                .ForeignKey("dbo.DonThuoc", t => t.DonThuocID, cascadeDelete: true)
                .ForeignKey("dbo.Thuoc", t => t.ThuocID, cascadeDelete: true)
                .Index(t => t.DonThuocID)
                .Index(t => t.ThuocID);
            
            CreateTable(
                "dbo.DonThuoc",
                c => new
                    {
                        MaDonThuoc = c.Int(nullable: false, identity: true),
                        NgayKeDon = c.DateTime(nullable: false),
                        TongTien = c.Double(nullable: false),
                        PhieuKhamBenhID = c.Int(nullable: false),
                        BacSiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaDonThuoc)
                .ForeignKey("dbo.NhanVien", t => t.BacSiID, cascadeDelete: true)
                .ForeignKey("dbo.PhieuKhamBenh", t => t.PhieuKhamBenhID)
                .Index(t => t.BacSiID)
                .Index(t => t.PhieuKhamBenhID);
            
            CreateTable(
                "dbo.PhieuKhamBenh",
                c => new
                    {
                        MaPhieuKhamBenh = c.Int(nullable: false, identity: true),
                        NgayKham = c.DateTime(nullable: false),
                        ChanDoan = c.String(),
                        LoiDan = c.String(),
                        BenhNhanID = c.Int(nullable: false),
                        BacSiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhieuKhamBenh)
                .ForeignKey("dbo.BenhNhan", t => t.BenhNhanID, cascadeDelete: true)
                .ForeignKey("dbo.NhanVien", t => t.BacSiID, cascadeDelete: true)
                .Index(t => t.BenhNhanID)
                .Index(t => t.BacSiID);
            
            CreateTable(
                "dbo.ChiTietPhieuKhamBenh",
                c => new
                    {
                        MaCTPK = c.Int(nullable: false, identity: true),
                        PhieuKhamBenhID = c.Int(nullable: false),
                        PhieuYeuCauDichVuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaCTPK)
                .ForeignKey("dbo.PhieuKhamBenh", t => t.PhieuKhamBenhID, cascadeDelete: true)
                .ForeignKey("dbo.PhieuYeuCauDichVu", t => t.PhieuYeuCauDichVuID)
                .Index(t => t.PhieuKhamBenhID)
                .Index(t => t.PhieuYeuCauDichVuID);
            
            CreateTable(
                "dbo.PhieuYeuCauDichVu",
                c => new
                    {
                        MaPhieuYeuCauDichVu = c.Int(nullable: false, identity: true),
                        ThoiGianThucHien = c.DateTime(nullable: false),
                        NgayLap = c.DateTime(nullable: false),
                        DonGia = c.Double(nullable: false),
                        ChanDoan = c.String(),
                        LoiDan = c.String(),
                        BenhNhanID = c.Int(nullable: false),
                        BacSiID = c.Int(nullable: false),
                        DichVuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhieuYeuCauDichVu)
                .ForeignKey("dbo.BenhNhan", t => t.BenhNhanID)
                .ForeignKey("dbo.NhanVien", t => t.BacSiID)
                .ForeignKey("dbo.DichVu", t => t.DichVuID)
                .Index(t => t.BenhNhanID)
                .Index(t => t.BacSiID)
                .Index(t => t.DichVuID);
            
            CreateTable(
                "dbo.DichVu",
                c => new
                    {
                        MaDichVu = c.Int(nullable: false, identity: true),
                        TenDichVu = c.String(),
                        DonGia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaDichVu);
            
            CreateTable(
                "dbo.Thuoc",
                c => new
                    {
                        MaThuoc = c.Int(nullable: false, identity: true),
                        TenThuoc = c.String(),
                        DonGia = c.Double(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonViTinhID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaThuoc)
                .ForeignKey("dbo.DonViTinh", t => t.DonViTinhID)
                .Index(t => t.DonViTinhID);
            
            CreateTable(
                "dbo.DonViTinh",
                c => new
                    {
                        MaDonViTinh = c.Int(nullable: false, identity: true),
                        TenDonViTinh = c.String(),
                    })
                .PrimaryKey(t => t.MaDonViTinh);
            
            CreateTable(
                "dbo.ChiTietHoaDon",
                c => new
                    {
                        MaCTHD = c.Int(nullable: false, identity: true),
                        HoaDonID = c.Int(nullable: false),
                        PhieuYeuCauDichVuID = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaCTHD)
                .ForeignKey("dbo.HoaDon", t => t.HoaDonID, cascadeDelete: true)
                .ForeignKey("dbo.PhieuYeuCauDichVu", t => t.PhieuYeuCauDichVuID)
                .Index(t => t.HoaDonID)
                .Index(t => t.PhieuYeuCauDichVuID);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        NgayThanhToan = c.DateTime(nullable: false),
                        TongTien = c.Double(nullable: false),
                        PhieuKhamBenhID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.PhieuKhamBenh", t => t.PhieuKhamBenhID)
                .Index(t => t.PhieuKhamBenhID);
            
            CreateTable(
                "dbo.GiayChuyenVien",
                c => new
                    {
                        MaGiayChuyenVien = c.Int(nullable: false, identity: true),
                        BenhNhanID = c.Int(nullable: false),
                        BacSiID = c.Int(nullable: false),
                        GiayNhapVienID = c.Int(nullable: false),
                        NgayChuyenVien = c.DateTime(nullable: false),
                        ChanDoan = c.String(),
                        TinhTrangLucChuyenVien = c.String(),
                        LyDoChuyenVien = c.String(),
                        PhuongTienChuyenVien = c.String(),
                        TenNguoiDuaDi = c.String(),
                        TenBVChuyenDen = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaGiayChuyenVien)
                .ForeignKey("dbo.GiayNhapVien", t => t.GiayNhapVienID, cascadeDelete: true)
                .ForeignKey("dbo.BenhNhan", t => t.BenhNhanID, cascadeDelete: true)
                .ForeignKey("dbo.NhanVien", t => t.BacSiID, cascadeDelete: true)
                .Index(t => t.GiayNhapVienID)
                .Index(t => t.BenhNhanID)
                .Index(t => t.BacSiID);
            
            CreateTable(
                "dbo.GiayNhapVien",
                c => new
                    {
                        MaGiayNhapVien = c.Int(nullable: false, identity: true),
                        BenhNhanID = c.Int(nullable: false),
                        BacSiDieuTriID = c.Int(nullable: false),
                        NhanVienTiepNhanID = c.Int(nullable: false),
                        ChanDoan = c.String(),
                        NgayNhapVien = c.DateTime(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaGiayNhapVien)
                .ForeignKey("dbo.BenhNhan", t => t.BenhNhanID)
                .ForeignKey("dbo.NhanVien", t => t.BacSiDieuTriID)
                .ForeignKey("dbo.NhanVien", t => t.NhanVienTiepNhanID)
                .Index(t => t.BenhNhanID)
                .Index(t => t.BacSiDieuTriID)
                .Index(t => t.NhanVienTiepNhanID);
            
            CreateTable(
                "dbo.GiayPhauThuat",
                c => new
                    {
                        MaGiayPhauThuat = c.Int(nullable: false, identity: true),
                        BacSiChiDinhID = c.Int(nullable: false),
                        BenhNhanID = c.Int(nullable: false),
                        DichVuID = c.Int(nullable: false),
                        ThoigianThucHien = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaGiayPhauThuat)
                .ForeignKey("dbo.NhanVien", t => t.BacSiChiDinhID, cascadeDelete: true)
                .ForeignKey("dbo.BenhNhan", t => t.BenhNhanID, cascadeDelete: true)
                .ForeignKey("dbo.DichVu", t => t.DichVuID, cascadeDelete: true)
                .Index(t => t.BacSiChiDinhID)
                .Index(t => t.BenhNhanID)
                .Index(t => t.DichVuID);
            
            CreateTable(
                "dbo.GiayRaVien",
                c => new
                    {
                        MaGiayRaVien = c.Int(nullable: false, identity: true),
                        BenhNhanID = c.Int(nullable: false),
                        BacSiDieuTriID = c.Int(nullable: false),
                        GiayNhapVienID = c.Int(nullable: false),
                        NgayRaVien = c.DateTime(nullable: false),
                        ChanDoan = c.String(),
                        LoiDan = c.String(),
                    })
                .PrimaryKey(t => t.MaGiayRaVien)
                .ForeignKey("dbo.BenhNhan", t => t.BenhNhanID, cascadeDelete: true)
                .ForeignKey("dbo.NhanVien", t => t.BacSiDieuTriID, cascadeDelete: true)
                .ForeignKey("dbo.GiayNhapVien", t => t.GiayNhapVienID, cascadeDelete: true)
                .Index(t => t.BenhNhanID)
                .Index(t => t.BacSiDieuTriID)
                .Index(t => t.GiayNhapVienID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.GiayRaVien", new[] { "GiayNhapVienID" });
            DropIndex("dbo.GiayRaVien", new[] { "BacSiDieuTriID" });
            DropIndex("dbo.GiayRaVien", new[] { "BenhNhanID" });
            DropIndex("dbo.GiayPhauThuat", new[] { "DichVuID" });
            DropIndex("dbo.GiayPhauThuat", new[] { "BenhNhanID" });
            DropIndex("dbo.GiayPhauThuat", new[] { "BacSiChiDinhID" });
            DropIndex("dbo.GiayNhapVien", new[] { "NhanVienTiepNhanID" });
            DropIndex("dbo.GiayNhapVien", new[] { "BacSiDieuTriID" });
            DropIndex("dbo.GiayNhapVien", new[] { "BenhNhanID" });
            DropIndex("dbo.GiayChuyenVien", new[] { "BacSiID" });
            DropIndex("dbo.GiayChuyenVien", new[] { "BenhNhanID" });
            DropIndex("dbo.GiayChuyenVien", new[] { "GiayNhapVienID" });
            DropIndex("dbo.HoaDon", new[] { "PhieuKhamBenhID" });
            DropIndex("dbo.ChiTietHoaDon", new[] { "PhieuYeuCauDichVuID" });
            DropIndex("dbo.ChiTietHoaDon", new[] { "HoaDonID" });
            DropIndex("dbo.Thuoc", new[] { "DonViTinhID" });
            DropIndex("dbo.PhieuYeuCauDichVu", new[] { "DichVuID" });
            DropIndex("dbo.PhieuYeuCauDichVu", new[] { "BacSiID" });
            DropIndex("dbo.PhieuYeuCauDichVu", new[] { "BenhNhanID" });
            DropIndex("dbo.ChiTietPhieuKhamBenh", new[] { "PhieuYeuCauDichVuID" });
            DropIndex("dbo.ChiTietPhieuKhamBenh", new[] { "PhieuKhamBenhID" });
            DropIndex("dbo.PhieuKhamBenh", new[] { "BacSiID" });
            DropIndex("dbo.PhieuKhamBenh", new[] { "BenhNhanID" });
            DropIndex("dbo.DonThuoc", new[] { "PhieuKhamBenhID" });
            DropIndex("dbo.DonThuoc", new[] { "BacSiID" });
            DropIndex("dbo.ChiTietDonThuoc", new[] { "ThuocID" });
            DropIndex("dbo.ChiTietDonThuoc", new[] { "DonThuocID" });
            DropIndex("dbo.HoSoDieuTriNoiTru", new[] { "PhongID" });
            DropIndex("dbo.HoSoDieuTriNoiTru", new[] { "YTaDieuTriID" });
            DropIndex("dbo.HoSoDieuTriNoiTru", new[] { "BacSiDieuTriID" });
            DropIndex("dbo.HoSoDieuTriNoiTru", new[] { "BenhNhanID" });
            DropIndex("dbo.ChiTietDieuTri", new[] { "HoSoDieuTriNoiTruID" });
            DropIndex("dbo.Phong", new[] { "BoPhanID" });
            DropIndex("dbo.NhanVien", new[] { "PhongID" });
            DropIndex("dbo.NhanVien", new[] { "ChucVuID" });
            DropIndex("dbo.NhanVien", new[] { "LoaiNhanVienID" });
            DropIndex("dbo.BoPhan", new[] { "NhanVienID" });
            DropForeignKey("dbo.GiayRaVien", "GiayNhapVienID", "dbo.GiayNhapVien");
            DropForeignKey("dbo.GiayRaVien", "BacSiDieuTriID", "dbo.NhanVien");
            DropForeignKey("dbo.GiayRaVien", "BenhNhanID", "dbo.BenhNhan");
            DropForeignKey("dbo.GiayPhauThuat", "DichVuID", "dbo.DichVu");
            DropForeignKey("dbo.GiayPhauThuat", "BenhNhanID", "dbo.BenhNhan");
            DropForeignKey("dbo.GiayPhauThuat", "BacSiChiDinhID", "dbo.NhanVien");
            DropForeignKey("dbo.GiayNhapVien", "NhanVienTiepNhanID", "dbo.NhanVien");
            DropForeignKey("dbo.GiayNhapVien", "BacSiDieuTriID", "dbo.NhanVien");
            DropForeignKey("dbo.GiayNhapVien", "BenhNhanID", "dbo.BenhNhan");
            DropForeignKey("dbo.GiayChuyenVien", "BacSiID", "dbo.NhanVien");
            DropForeignKey("dbo.GiayChuyenVien", "BenhNhanID", "dbo.BenhNhan");
            DropForeignKey("dbo.GiayChuyenVien", "GiayNhapVienID", "dbo.GiayNhapVien");
            DropForeignKey("dbo.HoaDon", "PhieuKhamBenhID", "dbo.PhieuKhamBenh");
            DropForeignKey("dbo.ChiTietHoaDon", "PhieuYeuCauDichVuID", "dbo.PhieuYeuCauDichVu");
            DropForeignKey("dbo.ChiTietHoaDon", "HoaDonID", "dbo.HoaDon");
            DropForeignKey("dbo.Thuoc", "DonViTinhID", "dbo.DonViTinh");
            DropForeignKey("dbo.PhieuYeuCauDichVu", "DichVuID", "dbo.DichVu");
            DropForeignKey("dbo.PhieuYeuCauDichVu", "BacSiID", "dbo.NhanVien");
            DropForeignKey("dbo.PhieuYeuCauDichVu", "BenhNhanID", "dbo.BenhNhan");
            DropForeignKey("dbo.ChiTietPhieuKhamBenh", "PhieuYeuCauDichVuID", "dbo.PhieuYeuCauDichVu");
            DropForeignKey("dbo.ChiTietPhieuKhamBenh", "PhieuKhamBenhID", "dbo.PhieuKhamBenh");
            DropForeignKey("dbo.PhieuKhamBenh", "BacSiID", "dbo.NhanVien");
            DropForeignKey("dbo.PhieuKhamBenh", "BenhNhanID", "dbo.BenhNhan");
            DropForeignKey("dbo.DonThuoc", "PhieuKhamBenhID", "dbo.PhieuKhamBenh");
            DropForeignKey("dbo.DonThuoc", "BacSiID", "dbo.NhanVien");
            DropForeignKey("dbo.ChiTietDonThuoc", "ThuocID", "dbo.Thuoc");
            DropForeignKey("dbo.ChiTietDonThuoc", "DonThuocID", "dbo.DonThuoc");
            DropForeignKey("dbo.HoSoDieuTriNoiTru", "PhongID", "dbo.Phong");
            DropForeignKey("dbo.HoSoDieuTriNoiTru", "YTaDieuTriID", "dbo.NhanVien");
            DropForeignKey("dbo.HoSoDieuTriNoiTru", "BacSiDieuTriID", "dbo.NhanVien");
            DropForeignKey("dbo.HoSoDieuTriNoiTru", "BenhNhanID", "dbo.BenhNhan");
            DropForeignKey("dbo.ChiTietDieuTri", "HoSoDieuTriNoiTruID", "dbo.HoSoDieuTriNoiTru");
            DropForeignKey("dbo.Phong", "BoPhanID", "dbo.BoPhan");
            DropForeignKey("dbo.NhanVien", "PhongID", "dbo.Phong");
            DropForeignKey("dbo.NhanVien", "ChucVuID", "dbo.ChucVu");
            DropForeignKey("dbo.NhanVien", "LoaiNhanVienID", "dbo.LoaiNhanVien");
            DropForeignKey("dbo.BoPhan", "NhanVienID", "dbo.NhanVien");
            DropTable("dbo.GiayRaVien");
            DropTable("dbo.GiayPhauThuat");
            DropTable("dbo.GiayNhapVien");
            DropTable("dbo.GiayChuyenVien");
            DropTable("dbo.HoaDon");
            DropTable("dbo.ChiTietHoaDon");
            DropTable("dbo.DonViTinh");
            DropTable("dbo.Thuoc");
            DropTable("dbo.DichVu");
            DropTable("dbo.PhieuYeuCauDichVu");
            DropTable("dbo.ChiTietPhieuKhamBenh");
            DropTable("dbo.PhieuKhamBenh");
            DropTable("dbo.DonThuoc");
            DropTable("dbo.ChiTietDonThuoc");
            DropTable("dbo.HoSoDieuTriNoiTru");
            DropTable("dbo.ChiTietDieuTri");
            DropTable("dbo.Phong");
            DropTable("dbo.ChucVu");
            DropTable("dbo.LoaiNhanVien");
            DropTable("dbo.NhanVien");
            DropTable("dbo.BoPhan");
            RenameTable(name: "dbo.BenhNhan", newName: "BenhNhans");
        }
    }
}
