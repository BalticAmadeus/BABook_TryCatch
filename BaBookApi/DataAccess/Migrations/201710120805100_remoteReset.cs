namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remoteReset : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invitation", "User_UserId", "dbo.User");
            DropForeignKey("dbo.EventUsers", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.EventUsers", "User_UserId", "dbo.User");
            DropForeignKey("dbo.Invitation", "Event_EventId", "dbo.Event");
            DropIndex("dbo.Invitation", new[] { "User_UserId" });
            DropIndex("dbo.Invitation", new[] { "Event_EventId" });
            DropIndex("dbo.EventUsers", new[] { "Event_EventId" });
            DropIndex("dbo.EventUsers", new[] { "User_UserId" });
            CreateTable(
                "dbo.UserEventAttendance",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        Response = c.Int(nullable: false),
                        User_UserId = c.Int(),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .ForeignKey("dbo.Event", t => t.Event_EventId)
                .Index(t => t.User_UserId)
                .Index(t => t.Event_EventId);
            
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
            
            DropTable("dbo.Invitation");
            DropTable("dbo.EventUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventUsers",
                c => new
                    {
                        Event_EventId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_EventId, t.User_UserId });
            
            CreateTable(
                "dbo.Invitation",
                c => new
                    {
                        InvitationId = c.Int(nullable: false, identity: true),
                        EventResponse = c.Int(nullable: false),
                        User_UserId = c.Int(),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.InvitationId);
            
            DropForeignKey("dbo.Comments", "OfEvent_EventId", "dbo.Event");
            DropForeignKey("dbo.UserEventAttendance", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.Comments", "OwnerUser_UserId", "dbo.User");
            DropForeignKey("dbo.UserEventAttendance", "User_UserId", "dbo.User");
            DropIndex("dbo.Comments", new[] { "OfEvent_EventId" });
            DropIndex("dbo.Comments", new[] { "OwnerUser_UserId" });
            DropIndex("dbo.UserEventAttendance", new[] { "Event_EventId" });
            DropIndex("dbo.UserEventAttendance", new[] { "User_UserId" });
            DropTable("dbo.Comments");
            DropTable("dbo.UserEventAttendance");
            CreateIndex("dbo.EventUsers", "User_UserId");
            CreateIndex("dbo.EventUsers", "Event_EventId");
            CreateIndex("dbo.Invitation", "Event_EventId");
            CreateIndex("dbo.Invitation", "User_UserId");
            AddForeignKey("dbo.Invitation", "Event_EventId", "dbo.Event", "EventId");
            AddForeignKey("dbo.EventUsers", "User_UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.EventUsers", "Event_EventId", "dbo.Event", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.Invitation", "User_UserId", "dbo.User", "UserId");
        }
    }
}
