namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attend : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "MatchId", "dbo.Matches");
            DropIndex("dbo.Attendances", new[] { "MatchId" });
            AddColumn("dbo.Attendances", "WeekId", c => c.Int(nullable: false));
            CreateIndex("dbo.Attendances", "WeekId");
            AddForeignKey("dbo.Attendances", "WeekId", "dbo.Weeks", "Id", cascadeDelete: true);
            DropColumn("dbo.Attendances", "MatchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "MatchId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Attendances", "WeekId", "dbo.Weeks");
            DropIndex("dbo.Attendances", new[] { "WeekId" });
            DropColumn("dbo.Attendances", "WeekId");
            CreateIndex("dbo.Attendances", "MatchId");
            AddForeignKey("dbo.Attendances", "MatchId", "dbo.Matches", "Id", cascadeDelete: true);
        }
    }
}
