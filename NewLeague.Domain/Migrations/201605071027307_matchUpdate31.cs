namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchUpdate31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CleanSheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        SeasonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CleanSheets", "PlayerId", "dbo.Players");
            DropIndex("dbo.CleanSheets", new[] { "PlayerId" });
            DropTable("dbo.CleanSheets");
        }
    }
}
