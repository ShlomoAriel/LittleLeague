namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchUpdat2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Outstandings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        SeasonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: false)
                .Index(t => t.PlayerId);
            
            AddColumn("dbo.Matches", "AwayGoalkeeperId", c => c.Int());
            AddColumn("dbo.Matches", "HomeGoalkeeperId", c => c.Int());
            AddColumn("dbo.Matches", "OutstandingId", c => c.Int(nullable: true));
            CreateIndex("dbo.Matches", "AwayGoalkeeperId");
            CreateIndex("dbo.Matches", "HomeGoalkeeperId");
            CreateIndex("dbo.Matches", "OutstandingId");
            AddForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.Players", "Id");
            AddForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.Players", "Id");
            AddForeignKey("dbo.Matches", "OutstandingId", "dbo.Outstandings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "OutstandingId", "dbo.Outstandings");
            DropForeignKey("dbo.Outstandings", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.Players");
            DropForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.Players");
            DropIndex("dbo.Outstandings", new[] { "PlayerId" });
            DropIndex("dbo.Matches", new[] { "OutstandingId" });
            DropIndex("dbo.Matches", new[] { "HomeGoalkeeperId" });
            DropIndex("dbo.Matches", new[] { "AwayGoalkeeperId" });
            DropColumn("dbo.Matches", "OutstandingId");
            DropColumn("dbo.Matches", "HomeGoalkeeperId");
            DropColumn("dbo.Matches", "AwayGoalkeeperId");
            DropTable("dbo.Outstandings");
        }
    }
}
