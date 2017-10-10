namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invitationcfg : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Invitations", newName: "Invitation");
            DropPrimaryKey("dbo.Invitation");
            AddColumn("dbo.Invitation", "EventResponse", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Invitation", new[] { "EventId", "UserId" });
            DropColumn("dbo.Invitation", "InvitationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invitation", "InvitationId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Invitation");
            DropColumn("dbo.Invitation", "EventResponse");
            AddPrimaryKey("dbo.Invitation", "InvitationId");
            RenameTable(name: "dbo.Invitation", newName: "Invitations");
        }
    }
}
