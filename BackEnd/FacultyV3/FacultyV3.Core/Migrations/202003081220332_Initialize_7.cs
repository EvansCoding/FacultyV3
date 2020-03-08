namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "Content", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
