namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleanshhet3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.CleanSheets");
            DropForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.CleanSheets");
            DropForeignKey("dbo.Matches", "OutstandingId", "dbo.Outstandings");
            DropPrimaryKey("dbo.CleanSheets");
            DropPrimaryKey("dbo.Outstandings");
            AddColumn("dbo.CleanSheets", "MatchId", c => c.Int(nullable: false));
            AddColumn("dbo.Outstandings", "MatchId", c => c.Int(nullable: false));
            AlterColumn("dbo.CleanSheets", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Outstandings", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CleanSheets", "MatchId");
            AddPrimaryKey("dbo.Outstandings", "MatchId");
            CreateIndex("dbo.CleanSheets", "MatchId");
            CreateIndex("dbo.Outstandings", "MatchId");
            AddForeignKey("dbo.CleanSheets", "MatchId", "dbo.Matches", "Id");
            AddForeignKey("dbo.Outstandings", "MatchId", "dbo.Matches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outstandings", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.CleanSheets", "MatchId", "dbo.Matches");
            DropIndex("dbo.Outstandings", new[] { "MatchId" });
            DropIndex("dbo.CleanSheets", new[] { "MatchId" });
            DropPrimaryKey("dbo.Outstandings");
            DropPrimaryKey("dbo.CleanSheets");
            AlterColumn("dbo.Outstandings", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CleanSheets", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Outstandings", "MatchId");
            DropColumn("dbo.CleanSheets", "MatchId");
            AddPrimaryKey("dbo.Outstandings", "Id");
            AddPrimaryKey("dbo.CleanSheets", "Id");
            AddForeignKey("dbo.Matches", "OutstandingId", "dbo.Outstandings", "Id");
            AddForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.CleanSheets", "Id");
            AddForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.CleanSheets", "Id");
        }
    }
}
