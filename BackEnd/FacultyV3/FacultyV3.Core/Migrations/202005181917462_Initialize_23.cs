namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Course", c => c.String());
            AddColumn("dbo.Student", "Major", c => c.String());
            AddColumn("dbo.Student", "Graduation_Year", c => c.String());
            AddColumn("dbo.Student", "Current_Job", c => c.String());
            AddColumn("dbo.Student", "Work_Place", c => c.String());
            AlterColumn("dbo.Student", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "Content", c => c.String(nullable: false));
            DropColumn("dbo.Student", "Work_Place");
            DropColumn("dbo.Student", "Current_Job");
            DropColumn("dbo.Student", "Graduation_Year");
            DropColumn("dbo.Student", "Major");
            DropColumn("dbo.Student", "Course");
        }
    }
}
