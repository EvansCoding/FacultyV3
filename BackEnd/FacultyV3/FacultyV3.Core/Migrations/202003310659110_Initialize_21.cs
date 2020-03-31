namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lecturer", "Code", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lecturer", "Code");
        }
    }
}
