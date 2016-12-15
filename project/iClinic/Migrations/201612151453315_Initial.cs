namespace iClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BoPhan", "GhiChu", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BoPhan", "GhiChu");
        }
    }
}
