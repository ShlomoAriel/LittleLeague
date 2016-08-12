namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.Players");
            DropForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.Players");
            DropForeignKey("dbo.Matches", "OutstandingId", "dbo.Players");
            DropIndex("dbo.Matches", new[] { "AwayGoalkeeperId" });
            DropIndex("dbo.Matches", new[] { "HomeGoalkeeperId" });
            DropIndex("dbo.Matches", new[] { "OutstandingId" });
            DropColumn("dbo.Matches", "AwayGoalkeeperId");
            DropColumn("dbo.Matches", "HomeGoalkeeperId");
            DropColumn("dbo.Matches", "OutstandingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "OutstandingId", c => c.Int());
            AddColumn("dbo.Matches", "HomeGoalkeeperId", c => c.Int());
            AddColumn("dbo.Matches", "AwayGoalkeeperId", c => c.Int());
            CreateIndex("dbo.Matches", "OutstandingId");
            CreateIndex("dbo.Matches", "HomeGoalkeeperId");
            CreateIndex("dbo.Matches", "AwayGoalkeeperId");
            AddForeignKey("dbo.Matches", "OutstandingId", "dbo.Players", "Id");
            AddForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.Players", "Id");
            AddForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.Players", "Id");
        }
    }
}
