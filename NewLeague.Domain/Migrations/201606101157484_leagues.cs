namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leagues : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.Players");
            DropForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.Players");
            DropForeignKey("dbo.Matches", "OutstandingId", "dbo.Players");
            DropForeignKey("dbo.Attendances", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.Attendances", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.CleanSheets", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.CleanSheets", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Outstandings", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.Outstandings", "PlayerId", "dbo.Players");
            DropIndex("dbo.Matches", new[] { "AwayGoalkeeperId" });
            DropIndex("dbo.Matches", new[] { "HomeGoalkeeperId" });
            DropIndex("dbo.Matches", new[] { "OutstandingId" });
            DropIndex("dbo.Attendances", new[] { "PlayerId" });
            DropIndex("dbo.Attendances", new[] { "MatchId" });
            DropIndex("dbo.CleanSheets", new[] { "PlayerId" });
            DropIndex("dbo.CleanSheets", new[] { "MatchId" });
            DropIndex("dbo.Outstandings", new[] { "PlayerId" });
            DropIndex("dbo.Outstandings", new[] { "MatchId" });
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Seasons", "League_Id", c => c.Int());
            AddColumn("dbo.Players", "Goals", c => c.Int(nullable: false));
            CreateIndex("dbo.Seasons", "League_Id");
            AddForeignKey("dbo.Seasons", "League_Id", "dbo.Leagues", "Id");
            DropColumn("dbo.Matches", "AwayGoalkeeperId");
            DropColumn("dbo.Matches", "HomeGoalkeeperId");
            DropColumn("dbo.Matches", "OutstandingId");
            DropTable("dbo.Attendances");
            DropTable("dbo.CleanSheets");
            DropTable("dbo.Outstandings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Outstandings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        SeasonId = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CleanSheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        SeasonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                        SeasonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Matches", "OutstandingId", c => c.Int());
            AddColumn("dbo.Matches", "HomeGoalkeeperId", c => c.Int());
            AddColumn("dbo.Matches", "AwayGoalkeeperId", c => c.Int());
            DropForeignKey("dbo.Seasons", "League_Id", "dbo.Leagues");
            DropIndex("dbo.Seasons", new[] { "League_Id" });
            DropColumn("dbo.Players", "Goals");
            DropColumn("dbo.Seasons", "League_Id");
            DropTable("dbo.Leagues");
            CreateIndex("dbo.Outstandings", "MatchId");
            CreateIndex("dbo.Outstandings", "PlayerId");
            CreateIndex("dbo.CleanSheets", "MatchId");
            CreateIndex("dbo.CleanSheets", "PlayerId");
            CreateIndex("dbo.Attendances", "MatchId");
            CreateIndex("dbo.Attendances", "PlayerId");
            CreateIndex("dbo.Matches", "OutstandingId");
            CreateIndex("dbo.Matches", "HomeGoalkeeperId");
            CreateIndex("dbo.Matches", "AwayGoalkeeperId");
            AddForeignKey("dbo.Outstandings", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Outstandings", "MatchId", "dbo.Matches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CleanSheets", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CleanSheets", "MatchId", "dbo.Matches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Attendances", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Attendances", "MatchId", "dbo.Matches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matches", "OutstandingId", "dbo.Players", "Id");
            AddForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.Players", "Id");
            AddForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.Players", "Id");
        }
    }
}
