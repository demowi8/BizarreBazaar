namespace BizarreBazaar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bid", "StartingBid");
            DropColumn("dbo.Bid", "BidIncrement");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bid", "BidIncrement", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Bid", "StartingBid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
