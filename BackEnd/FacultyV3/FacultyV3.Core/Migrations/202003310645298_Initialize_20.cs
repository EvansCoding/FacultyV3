namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_20 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Video", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Video", "Description", c => c.String(maxLength: 200));
        }
    }
}
