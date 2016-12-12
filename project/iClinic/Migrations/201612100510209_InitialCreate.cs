namespace iClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BenhNhans",
                c => new
                    {
                        MaBenhNhan = c.Int(nullable: false, identity: true),
                        TenBenhNhan = c.String(),
                        GioiTinh = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        NgheNghiep = c.String(),
                        DiaChi = c.String(),
                        SoDT = c.String(),
                        TienSuBenh = c.String(),
                        NgayTiepNhan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaBenhNhan);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BenhNhans");
        }
    }
}
