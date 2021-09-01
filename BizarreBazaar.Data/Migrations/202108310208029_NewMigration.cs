namespace BizarreBazaar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bid", "BidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Bid", "AuctionID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bid", "AuctionID");
            AddForeignKey("dbo.Bid", "AuctionID", "dbo.Auction", "AuctionID", cascadeDelete: true);
            DropColumn("dbo.Bid", "BiddingAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bid", "BiddingAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Bid", "AuctionID", "dbo.Auction");
            DropIndex("dbo.Bid", new[] { "AuctionID" });
            DropColumn("dbo.Bid", "AuctionID");
            DropColumn("dbo.Bid", "BidAmount");
        }
    }
}
