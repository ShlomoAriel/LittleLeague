namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                        SeasonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.MatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assists", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Assists", "MatchId", "dbo.Matches");
            DropIndex("dbo.Assists", new[] { "MatchId" });
            DropIndex("dbo.Assists", new[] { "PlayerId" });
            DropTable("dbo.Assists");
        }
    }
}
