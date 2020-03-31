namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_19 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Banner", "Title_Short");
            DropColumn("dbo.Banner", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banner", "Description", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Banner", "Title_Short", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
