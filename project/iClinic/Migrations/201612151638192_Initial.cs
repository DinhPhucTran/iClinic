namespace iClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanVien", "GioiTinh", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanVien", "GioiTinh", c => c.Boolean(nullable: false));
        }
    }
}
