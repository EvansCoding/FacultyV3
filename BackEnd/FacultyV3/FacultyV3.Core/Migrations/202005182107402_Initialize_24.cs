namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Block", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "Block");
        }
    }
}
