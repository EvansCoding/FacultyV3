namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "Create_At", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ads", "Update_At", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ads", "Update_At");
            DropColumn("dbo.Ads", "Create_At");
        }
    }
}
