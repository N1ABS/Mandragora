namespace Mandragora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        PlantId = c.Int(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Plants", t => t.PlantId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.PlantId);
            
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        ReactionType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reactions", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Reactions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.PostComments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.Posts", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.PostComments", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Reactions", new[] { "AccountId" });
            DropIndex("dbo.Reactions", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "PlantId" });
            DropIndex("dbo.Posts", new[] { "AccountId" });
            DropIndex("dbo.PostComments", new[] { "AccountId" });
            DropIndex("dbo.PostComments", new[] { "PostId" });
            DropTable("dbo.Reactions");
            DropTable("dbo.Posts");
            DropTable("dbo.PostComments");
        }
    }
}
