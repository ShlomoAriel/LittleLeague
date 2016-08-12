namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "AwayGoalkeeperId", c => c.Int(nullable: true));
            AddColumn("dbo.Matches", "HomeGoalkeeperId", c => c.Int(nullable: true));
            AddColumn("dbo.Matches", "OutstandingId", c => c.Int(nullable: true));
            CreateIndex("dbo.Matches", "AwayGoalkeeperId");
            CreateIndex("dbo.Matches", "HomeGoalkeeperId");
            CreateIndex("dbo.Matches", "OutstandingId");
            AddForeignKey("dbo.Matches", "AwayGoalkeeperId", "dbo.Players", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Matches", "HomeGoalkeeperId", "dbo.Players", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Matches", "OutstandingId", "dbo.Players", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
        }
    }
}
