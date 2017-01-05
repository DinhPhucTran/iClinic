namespace iClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BoPhan", "NhanVienID", "dbo.NhanVien");
            DropIndex("dbo.BoPhan", new[] { "NhanVienID" });
            AddColumn("dbo.BoPhan", "GhiChu", c => c.String());
            AlterColumn("dbo.BoPhan", "NhanVienID", c => c.Int());
            AlterColumn("dbo.NhanVien", "GioiTinh", c => c.String());
            AddForeignKey("dbo.BoPhan", "NhanVienID", "dbo.NhanVien", "MaNhanVien");
            CreateIndex("dbo.BoPhan", "NhanVienID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BoPhan", new[] { "NhanVienID" });
            DropForeignKey("dbo.BoPhan", "NhanVienID", "dbo.NhanVien");
            AlterColumn("dbo.NhanVien", "GioiTinh", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BoPhan", "NhanVienID", c => c.Int(nullable: false));
            DropColumn("dbo.BoPhan", "GhiChu");
            CreateIndex("dbo.BoPhan", "NhanVienID");
            AddForeignKey("dbo.BoPhan", "NhanVienID", "dbo.NhanVien", "MaNhanVien", cascadeDelete: true);
        }
    }
}
