namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Confirguration",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Meta_Name = c.String(nullable: false),
                        Meta_Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Confirguration");
        }
    }
}
