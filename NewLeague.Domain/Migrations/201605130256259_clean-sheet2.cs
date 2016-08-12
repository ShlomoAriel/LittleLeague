namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleansheet2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CleanSheets", "TeamId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CleanSheets", "TeamId");
        }
    }
}
