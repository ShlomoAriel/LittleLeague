namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchplayerids : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "OutstandingId", "dbo.Players");
            DropForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.Players");
            DropForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.Players");
            DropIndex("dbo.Matches", new[] { "OutstandingId" });
            DropIndex("dbo.Matches", new[] { "HomeGoalkeeperId" });
            DropIndex("dbo.Matches", new[] { "AwayGoalkeeperId" });
            DropColumn("dbo.Matches", "OutstandingId");
            DropColumn("dbo.Matches", "HomeGoalkeeperId");
            DropColumn("dbo.Matches", "AwayGoalkeeperId");
        }
    }
}
