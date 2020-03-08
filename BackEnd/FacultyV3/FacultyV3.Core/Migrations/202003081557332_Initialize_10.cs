namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Detail_Menu", "Url_LinkGoogle", c => c.String());
            AddColumn("dbo.Detail_News", "Url_LinkGoogle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Detail_News", "Url_LinkGoogle");
            DropColumn("dbo.Detail_Menu", "Url_LinkGoogle");
        }
    }
}
