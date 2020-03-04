namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Banner", "Url_Link", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Banner", "Url_Link", c => c.String(nullable: false, maxLength: 300));
        }
    }
}
