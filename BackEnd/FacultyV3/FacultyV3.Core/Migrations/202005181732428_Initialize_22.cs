namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conference",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 300),
                        Url_Image = c.String(nullable: false, maxLength: 300),
                        Url_Link = c.String(maxLength: 300),
                        Serial = c.Int(nullable: false),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Conference");
        }
    }
}
