namespace FacultyV3.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About_Us",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        Url_Image = c.String(nullable: false, maxLength: 300),
                        Url_Video = c.String(nullable: false, maxLength: 300),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 256),
                        FullName = c.String(nullable: false, maxLength: 200),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Detail_Menu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false),
                        Serial = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Url_Image = c.String(nullable: false, maxLength: 300),
                        Url_Video = c.String(nullable: false, maxLength: 300),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                        Category_Menu_Id = c.Guid(nullable: false),
                        Account_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category_Menu", t => t.Category_Menu_Id, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.Account_ID)
                .Index(t => t.Category_Menu_Id)
                .Index(t => t.Account_ID);
            
            CreateTable(
                "dbo.Category_Menu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Meta_Name = c.String(nullable: false, maxLength: 200),
                        Meta_Value = c.String(nullable: false, maxLength: 200),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                        Parent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category_Menu", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Detail_News",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false),
                        Serial = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Url_Image = c.String(nullable: false, maxLength: 300),
                        Url_Video = c.String(nullable: false, maxLength: 300),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                        Category_News_Id = c.Guid(nullable: false),
                        Account_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category_News", t => t.Category_News_Id, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.Account_ID)
                .Index(t => t.Category_News_Id)
                .Index(t => t.Account_ID);
            
            CreateTable(
                "dbo.Category_News",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Meta_Name = c.String(nullable: false, maxLength: 200),
                        Meta_Value = c.String(nullable: false, maxLength: 200),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                        Parent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category_News", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Banner",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 300),
                        Title_Short = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 500),
                        Url_Image = c.String(nullable: false, maxLength: 300),
                        Url_Link = c.String(nullable: false, maxLength: 300),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Meta_Name = c.String(nullable: false, maxLength: 100),
                        Meta_Value = c.String(nullable: false, maxLength: 300),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Count",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Meta_Name = c.String(nullable: false, maxLength: 100),
                        Meta_Value = c.String(nullable: false, maxLength: 300),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lecturer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Degree = c.String(nullable: false, maxLength: 100),
                        Url_Image = c.String(nullable: false, maxLength: 200),
                        Url_Facebook = c.String(nullable: false, maxLength: 200),
                        Phone = c.String(nullable: false, maxLength: 12),
                        Email = c.String(nullable: false, maxLength: 100),
                        Serial = c.Int(nullable: false),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Meta_Name = c.String(nullable: false, maxLength: 100),
                        Meta_Value = c.String(nullable: false, maxLength: 300),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stickey",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Meta_Name = c.String(nullable: false, maxLength: 100),
                        Meta_Value = c.String(nullable: false, maxLength: 300),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Url_Image = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false, maxLength: 200),
                        Serial = c.Int(nullable: false),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Video",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 200),
                        Url_Video = c.String(nullable: false, maxLength: 300),
                        Url_Image = c.String(nullable: false, maxLength: 300),
                        Serial = c.Int(nullable: false),
                        Create_At = c.DateTime(nullable: false),
                        Update_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Detail_News", "Account_ID", "dbo.Account");
            DropForeignKey("dbo.Category_News", "Parent_Id", "dbo.Category_News");
            DropForeignKey("dbo.Detail_News", "Category_News_Id", "dbo.Category_News");
            DropForeignKey("dbo.Detail_Menu", "Account_ID", "dbo.Account");
            DropForeignKey("dbo.Category_Menu", "Parent_Id", "dbo.Category_Menu");
            DropForeignKey("dbo.Detail_Menu", "Category_Menu_Id", "dbo.Category_Menu");
            DropIndex("dbo.Category_News", new[] { "Parent_Id" });
            DropIndex("dbo.Detail_News", new[] { "Account_ID" });
            DropIndex("dbo.Detail_News", new[] { "Category_News_Id" });
            DropIndex("dbo.Category_Menu", new[] { "Parent_Id" });
            DropIndex("dbo.Detail_Menu", new[] { "Account_ID" });
            DropIndex("dbo.Detail_Menu", new[] { "Category_Menu_Id" });
            DropTable("dbo.Video");
            DropTable("dbo.Student");
            DropTable("dbo.Stickey");
            DropTable("dbo.Service");
            DropTable("dbo.Lecturer");
            DropTable("dbo.Count");
            DropTable("dbo.Contact");
            DropTable("dbo.Banner");
            DropTable("dbo.Category_News");
            DropTable("dbo.Detail_News");
            DropTable("dbo.Category_Menu");
            DropTable("dbo.Detail_Menu");
            DropTable("dbo.Account");
            DropTable("dbo.About_Us");
        }
    }
}
