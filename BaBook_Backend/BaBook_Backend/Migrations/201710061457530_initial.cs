namespace BaBook_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateOfOccurance = c.DateTime(nullable: false),
                        Location = c.String(),
                        OwnerUser_UserId = c.Int(),
                        OfGroup_GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.User", t => t.OwnerUser_UserId)
                .ForeignKey("dbo.Group", t => t.OfGroup_GroupId)
                .Index(t => t.OwnerUser_UserId)
                .Index(t => t.OfGroup_GroupId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.EventUsers",
                c => new
                    {
                        Event_EventId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_EventId, t.User_UserId })
                .ForeignKey("dbo.Event", t => t.Event_EventId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Event_EventId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "OfGroup_GroupId", "dbo.Group");
            DropForeignKey("dbo.EventUsers", "User_UserId", "dbo.User");
            DropForeignKey("dbo.EventUsers", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.Event", "OwnerUser_UserId", "dbo.User");
            DropIndex("dbo.EventUsers", new[] { "User_UserId" });
            DropIndex("dbo.EventUsers", new[] { "Event_EventId" });
            DropIndex("dbo.Event", new[] { "OfGroup_GroupId" });
            DropIndex("dbo.Event", new[] { "OwnerUser_UserId" });
            DropTable("dbo.EventUsers");
            DropTable("dbo.Group");
            DropTable("dbo.User");
            DropTable("dbo.Event");
        }
    }
}
