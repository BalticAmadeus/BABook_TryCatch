namespace DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentText = c.String(maxLength: 255),
                        CommentTime = c.DateTime(nullable: false),
                        OwnerUser_Id = c.String(maxLength: 128),
                        OfEvent_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerUser_Id)
                .ForeignKey("dbo.Event", t => t.OfEvent_EventId)
                .Index(t => t.OwnerUser_Id)
                .Index(t => t.OfEvent_EventId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateOfOccurance = c.DateTime(nullable: false),
                        Location = c.String(),
                        Description = c.String(),
                        OwnerUser_Id = c.String(maxLength: 128),
                        OfGroup_GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerUser_Id)
                .ForeignKey("dbo.Group", t => t.OfGroup_GroupId)
                .Index(t => t.OwnerUser_Id)
                .Index(t => t.OfGroup_GroupId);
            
            CreateTable(
                "dbo.UserEventAttendance",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        Response = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Event", t => t.Event_EventId)
                .Index(t => t.User_Id)
                .Index(t => t.Event_EventId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DisplayName = c.String(nullable: false, maxLength: 50,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DisplayName",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: DisplayName, IsUnique: True }")
                                },
                            }),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Event", "OfGroup_GroupId", "dbo.Group");
            DropForeignKey("dbo.Comment", "OfEvent_EventId", "dbo.Event");
            DropForeignKey("dbo.UserEventAttendance", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Event", "OwnerUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comment", "OwnerUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEventAttendance", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserEventAttendance", new[] { "Event_EventId" });
            DropIndex("dbo.UserEventAttendance", new[] { "User_Id" });
            DropIndex("dbo.Event", new[] { "OfGroup_GroupId" });
            DropIndex("dbo.Event", new[] { "OwnerUser_Id" });
            DropIndex("dbo.Comment", new[] { "OfEvent_EventId" });
            DropIndex("dbo.Comment", new[] { "OwnerUser_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Group");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "DisplayName",
                        new Dictionary<string, object>
                        {
                            { "DisplayName", "IndexAnnotation: { Name: DisplayName, IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.UserEventAttendance");
            DropTable("dbo.Event");
            DropTable("dbo.Comment");
        }
    }
}
