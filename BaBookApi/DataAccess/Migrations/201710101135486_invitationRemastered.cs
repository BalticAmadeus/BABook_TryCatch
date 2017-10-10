namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invitationRemastered : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invitation", "EventId", "dbo.Event");
            DropForeignKey("dbo.Invitation", "UserId", "dbo.User");
            DropIndex("dbo.Invitation", new[] { "EventId" });
            DropIndex("dbo.Invitation", new[] { "UserId" });
            RenameColumn(table: "dbo.Invitation", name: "EventId", newName: "Event_EventId");
            RenameColumn(table: "dbo.Invitation", name: "UserId", newName: "User_UserId");
            DropPrimaryKey("dbo.Invitation");
            AddColumn("dbo.Invitation", "InvitationId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Invitation", "Event_EventId", c => c.Int());
            AlterColumn("dbo.Invitation", "User_UserId", c => c.Int());
            AddPrimaryKey("dbo.Invitation", "InvitationId");
            CreateIndex("dbo.Invitation", "User_UserId");
            CreateIndex("dbo.Invitation", "Event_EventId");
            AddForeignKey("dbo.Invitation", "Event_EventId", "dbo.Event", "EventId");
            AddForeignKey("dbo.Invitation", "User_UserId", "dbo.User", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invitation", "User_UserId", "dbo.User");
            DropForeignKey("dbo.Invitation", "Event_EventId", "dbo.Event");
            DropIndex("dbo.Invitation", new[] { "Event_EventId" });
            DropIndex("dbo.Invitation", new[] { "User_UserId" });
            DropPrimaryKey("dbo.Invitation");
            AlterColumn("dbo.Invitation", "User_UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Invitation", "Event_EventId", c => c.Int(nullable: false));
            DropColumn("dbo.Invitation", "InvitationId");
            AddPrimaryKey("dbo.Invitation", new[] { "EventId", "UserId" });
            RenameColumn(table: "dbo.Invitation", name: "User_UserId", newName: "UserId");
            RenameColumn(table: "dbo.Invitation", name: "Event_EventId", newName: "EventId");
            CreateIndex("dbo.Invitation", "UserId");
            CreateIndex("dbo.Invitation", "EventId");
            AddForeignKey("dbo.Invitation", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Invitation", "EventId", "dbo.Event", "EventId", cascadeDelete: true);
        }
    }
}
