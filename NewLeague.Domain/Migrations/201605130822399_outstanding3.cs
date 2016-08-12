namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class outstanding3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Outstandings", "TeamId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Outstandings", "TeamId");
        }
    }
}
