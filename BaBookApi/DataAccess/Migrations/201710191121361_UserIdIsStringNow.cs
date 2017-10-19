namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdIsStringNow : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UserId", c => c.Int(nullable: false));
        }
    }
}
