namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Training_Process", "LecturerID", "dbo.Lecturer");
            AddForeignKey("dbo.Training_Process", "LecturerID", "dbo.Lecturer", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Training_Process", "LecturerID", "dbo.Lecturer");
            AddForeignKey("dbo.Training_Process", "LecturerID", "dbo.Lecturer", "Id");
        }
    }
}
