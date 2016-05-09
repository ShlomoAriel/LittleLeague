namespace NewLeague.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchUpdate6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "Goals");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Goals", c => c.Int(nullable: false));
        }
    }
}
