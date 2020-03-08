namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category_Menu", "Serial", c => c.Int(nullable: false));
            AddColumn("dbo.Category_News", "Serial", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category_News", "Serial");
            DropColumn("dbo.Category_Menu", "Serial");
        }
    }
}
