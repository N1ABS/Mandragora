namespace Mandragora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addalltables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(),
                        PlantId = c.Int(),
                        PostDate = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Plants", t => t.PlantId)
                .Index(t => t.AccountId)
                .Index(t => t.PlantId);
            
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(),
                        AccountId = c.Int(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(),
                        AccountId = c.Int(),
                        ReactionType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reactions", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Reactions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.PostComments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.PostComments", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Posts", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.Posts", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Reactions", new[] { "AccountId" });
            DropIndex("dbo.Reactions", new[] { "PostId" });
            DropIndex("dbo.PostComments", new[] { "AccountId" });
            DropIndex("dbo.PostComments", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "PlantId" });
            DropIndex("dbo.Posts", new[] { "AccountId" });
            DropIndex("dbo.Accounts", new[] { "ApplicationUserId" });
            DropTable("dbo.Reactions");
            DropTable("dbo.PostComments");
            DropTable("dbo.Posts");
            DropTable("dbo.Accounts");
        }
    }
}
