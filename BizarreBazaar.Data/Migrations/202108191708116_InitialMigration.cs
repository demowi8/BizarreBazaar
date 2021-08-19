namespace BizarreBazaar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "InventoryCount", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "AmountOf");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "AmountOf", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "InventoryCount");
        }
    }
}
