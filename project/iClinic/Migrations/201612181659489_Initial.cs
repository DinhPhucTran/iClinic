namespace iClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonViTinh", "TenDonViTinh", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonViTinh", "TenDonViTinh", c => c.String());
        }
    }
}
