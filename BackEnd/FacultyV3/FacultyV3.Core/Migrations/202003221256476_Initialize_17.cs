namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Account", "Role_Id", c => c.Guid());
            CreateIndex("dbo.Account", "Role_Id");
            AddForeignKey("dbo.Account", "Role_Id", "dbo.Role", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Account", "Role_Id", "dbo.Role");
            DropIndex("dbo.Account", new[] { "Role_Id" });
            DropColumn("dbo.Account", "Role_Id");
            DropTable("dbo.Role");
        }
    }
}
