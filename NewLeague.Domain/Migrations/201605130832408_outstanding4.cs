namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class outstanding4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Outstandings", new[] { "MatchId" });
            CreateIndex("dbo.Outstandings", "MatchId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Outstandings", new[] { "MatchId" });
            CreateIndex("dbo.Outstandings", "MatchId", unique: true);
        }
    }
}
