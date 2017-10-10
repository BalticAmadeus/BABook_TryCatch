namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInvitations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        InvitationId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvitationId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invitations", "EventId", "dbo.Event");
            DropForeignKey("dbo.Invitations", "UserId", "dbo.User");
            DropIndex("dbo.Invitations", new[] { "UserId" });
            DropIndex("dbo.Invitations", new[] { "EventId" });
            DropTable("dbo.Invitations");
        }
    }
}
