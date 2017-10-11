namespace DataAccess.Migrations
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
                        Description = c.String(),
                        OwnerUser_UserId = c.Int(),
                        OfGroup_GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.User", t => t.OwnerUser_UserId)
                .ForeignKey("dbo.Group", t => t.OfGroup_GroupId)
                .Index(t => t.OwnerUser_UserId)
                .Index(t => t.OfGroup_GroupId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "OfGroup_GroupId", "dbo.Group");
            DropForeignKey("dbo.UserEventAttendance", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.Event", "OwnerUser_UserId", "dbo.User");
            DropForeignKey("dbo.UserEventAttendance", "User_UserId", "dbo.User");
            DropIndex("dbo.UserEventAttendance", new[] { "Event_EventId" });
            DropIndex("dbo.UserEventAttendance", new[] { "User_UserId" });
            DropIndex("dbo.Event", new[] { "OfGroup_GroupId" });
            DropIndex("dbo.Event", new[] { "OwnerUser_UserId" });
            DropTable("dbo.Group");
            DropTable("dbo.User");
            DropTable("dbo.UserEventAttendance");
            DropTable("dbo.Event");
        }
    }
}
