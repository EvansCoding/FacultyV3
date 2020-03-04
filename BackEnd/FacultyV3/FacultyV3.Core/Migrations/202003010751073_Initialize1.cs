namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banner", "Serial", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banner", "Serial");
        }
    }
}
