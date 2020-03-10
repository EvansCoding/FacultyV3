namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Detail_Menu", "Title", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("dbo.Detail_Menu", "Description", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("dbo.Detail_News", "Title", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("dbo.Detail_News", "Description", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("dbo.Detail_News", "Url_Image", c => c.String(maxLength: 300));
            AlterColumn("dbo.Detail_News", "Url_Video", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Detail_News", "Url_Video", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Detail_News", "Url_Image", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Detail_News", "Description", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Detail_News", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Detail_Menu", "Description", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Detail_Menu", "Title", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
