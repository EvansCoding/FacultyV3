namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_211 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.About_Us", "Url_Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.About_Us", "Url_Image", c => c.String(nullable: false, maxLength: 300));
        }
    }
}
