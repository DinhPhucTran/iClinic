namespace iClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BenhNhan", "TenBenhNhan", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BenhNhan", "TenBenhNhan", c => c.String());
        }
    }
}
