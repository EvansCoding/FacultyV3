namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Training_Process",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Degree = c.String(),
                        Graduation_Year = c.String(),
                        Graduation_School = c.String(),
                        Graduation_Specialized = c.String(),
                        LecturerID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lecturer", t => t.LecturerID)
                .Index(t => t.LecturerID);
            
            AddColumn("dbo.Lecturer", "Position", c => c.String());
            AddColumn("dbo.Lecturer", "Academic_Rank", c => c.String());
            AddColumn("dbo.Lecturer", "Specialized", c => c.String());
            AddColumn("dbo.Lecturer", "Title", c => c.String());
            AddColumn("dbo.Lecturer", "Native_Land", c => c.String());
            AddColumn("dbo.Lecturer", "Url_Scientific_Works", c => c.String());
            AddColumn("dbo.Lecturer", "Specialized_Research", c => c.String());
            AddColumn("dbo.Lecturer", "Teaching", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Training_Process", "LecturerID", "dbo.Lecturer");
            DropIndex("dbo.Training_Process", new[] { "LecturerID" });
            DropColumn("dbo.Lecturer", "Teaching");
            DropColumn("dbo.Lecturer", "Specialized_Research");
            DropColumn("dbo.Lecturer", "Url_Scientific_Works");
            DropColumn("dbo.Lecturer", "Native_Land");
            DropColumn("dbo.Lecturer", "Title");
            DropColumn("dbo.Lecturer", "Specialized");
            DropColumn("dbo.Lecturer", "Academic_Rank");
            DropColumn("dbo.Lecturer", "Position");
            DropTable("dbo.Training_Process");
        }
    }
}
