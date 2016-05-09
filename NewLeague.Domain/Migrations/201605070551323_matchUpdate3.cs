namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchUpdate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.Players");
            DropForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.Players");
            DropForeignKey("dbo.Matches", "OutstandingId", "dbo.Players");
            DropIndex("dbo.Matches", new[] { "AwayGoalkeeperId" });
            DropIndex("dbo.Matches", new[] { "HomeGoalkeeperId" });
            DropIndex("dbo.Matches", new[] { "OutstandingId" });
            AlterColumn("dbo.Matches", "AwayGoalkeeperId", c => c.Int());
            AlterColumn("dbo.Matches", "HomeGoalkeeperId", c => c.Int());
            AlterColumn("dbo.Matches", "OutstandingId", c => c.Int());
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
            AlterColumn("dbo.Matches", "OutstandingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Matches", "HomeGoalkeeperId", c => c.Int(nullable: false));
            AlterColumn("dbo.Matches", "AwayGoalkeeperId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "OutstandingId");
            CreateIndex("dbo.Matches", "HomeGoalkeeperId");
            CreateIndex("dbo.Matches", "AwayGoalkeeperId");
            AddForeignKey("dbo.Matches", "OutstandingId", "dbo.Players", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.Players", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.Players", "Id", cascadeDelete: true);
        }
    }
}
