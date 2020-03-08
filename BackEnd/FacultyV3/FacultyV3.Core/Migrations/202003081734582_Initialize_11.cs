namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "Meta_Value", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "Meta_Value", c => c.String(nullable: false, maxLength: 300));
        }
    }
}
