namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Detail_Menu", "Block", c => c.Boolean(nullable: false));
            AddColumn("dbo.Category_Menu", "Block", c => c.Boolean(nullable: false));
            AddColumn("dbo.Detail_News", "Block", c => c.Boolean(nullable: false));
            AddColumn("dbo.Category_News", "Block", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category_News", "Block");
            DropColumn("dbo.Detail_News", "Block");
            DropColumn("dbo.Category_Menu", "Block");
            DropColumn("dbo.Detail_Menu", "Block");
        }
    }
}
