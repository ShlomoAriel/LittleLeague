namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class outstanding2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Outstandings", "MatchId", "dbo.Matches");
            DropIndex("dbo.Outstandings", new[] { "MatchId" });
            DropPrimaryKey("dbo.Outstandings");
            AlterColumn("dbo.Outstandings", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Outstandings", "Id");
            CreateIndex("dbo.Outstandings", "MatchId", unique: true);
            AddForeignKey("dbo.Outstandings", "MatchId", "dbo.Matches", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outstandings", "MatchId", "dbo.Matches");
            DropIndex("dbo.Outstandings", new[] { "MatchId" });
            DropPrimaryKey("dbo.Outstandings");
            AlterColumn("dbo.Outstandings", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Outstandings", "MatchId");
            CreateIndex("dbo.Outstandings", "MatchId");
            AddForeignKey("dbo.Outstandings", "MatchId", "dbo.Matches", "Id");
        }
    }
}
