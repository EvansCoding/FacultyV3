namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Detail_Menu", "Url_Image", c => c.String(maxLength: 300));
            AlterColumn("dbo.Detail_Menu", "Url_Video", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Detail_Menu", "Url_Video", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Detail_Menu", "Url_Image", c => c.String(nullable: false, maxLength: 300));
        }
    }
}
