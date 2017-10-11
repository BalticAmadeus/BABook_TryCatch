namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDKWHATITIS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        CommentTime = c.DateTime(nullable: false),
                        OwnerUser_UserId = c.Int(),
                        OfEvent_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.User", t => t.OwnerUser_UserId)
                .ForeignKey("dbo.Event", t => t.OfEvent_EventId)
                .Index(t => t.OwnerUser_UserId)
                .Index(t => t.OfEvent_EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "OfEvent_EventId", "dbo.Event");
            DropForeignKey("dbo.Comments", "OwnerUser_UserId", "dbo.User");
            DropIndex("dbo.Comments", new[] { "OfEvent_EventId" });
            DropIndex("dbo.Comments", new[] { "OwnerUser_UserId" });
            DropTable("dbo.Comments");
        }
    }
}
