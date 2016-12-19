namespace iClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phong", "DichVuID", c => c.Int(nullable: false));
            AddForeignKey("dbo.Phong", "DichVuID", "dbo.DichVu", "MaDichVu", cascadeDelete: true);
            CreateIndex("dbo.Phong", "DichVuID");
            DropColumn("dbo.DichVu", "PhongID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DichVu", "PhongID", c => c.Int(nullable: false));
            DropIndex("dbo.Phong", new[] { "DichVuID" });
            DropForeignKey("dbo.Phong", "DichVuID", "dbo.DichVu");
            DropColumn("dbo.Phong", "DichVuID");
        }
    }
}
