namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_18 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Account", new[] { "Role_Id" });
            CreateIndex("dbo.Account", "Role_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Account", new[] { "Role_ID" });
            CreateIndex("dbo.Account", "Role_Id");
        }
    }
}
