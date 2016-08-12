namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchplayerids3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "AwayGoalkeeperId", c => c.Int());
            AddColumn("dbo.Matches", "HomeGoalkeeperId", c => c.Int());
            AddColumn("dbo.Matches", "OutstandingId", c => c.Int());
            CreateIndex("dbo.Matches", "AwayGoalkeeperId");
            CreateIndex("dbo.Matches", "HomeGoalkeeperId");
            CreateIndex("dbo.Matches", "OutstandingId");
            AddForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.Players", "Id");
            AddForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.Players", "Id");
            AddForeignKey("dbo.Matches", "OutstandingId", "dbo.Players", "Id");
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
