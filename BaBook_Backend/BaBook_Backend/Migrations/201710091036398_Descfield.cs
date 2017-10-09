namespace BaBook_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Descfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "Description");
        }
    }
}
