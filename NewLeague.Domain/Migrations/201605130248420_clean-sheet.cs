namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleansheet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CleanSheets", "MatchId", "dbo.Matches");
            DropPrimaryKey("dbo.CleanSheets");
            AlterColumn("dbo.CleanSheets", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CleanSheets", "Id");
            AddForeignKey("dbo.CleanSheets", "MatchId", "dbo.Matches", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CleanSheets", "MatchId", "dbo.Matches");
            DropPrimaryKey("dbo.CleanSheets");
            AlterColumn("dbo.CleanSheets", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CleanSheets", "MatchId");
            AddForeignKey("dbo.CleanSheets", "MatchId", "dbo.Matches", "Id");
        }
    }
}
