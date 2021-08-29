namespace BizarreBazaar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixthMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auction",
                c => new
                    {
                        AuctionID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        ActualAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(nullable: false, precision: 7),
                        EndingTime = c.DateTimeOffset(nullable: false, precision: 7),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuctionID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            AddColumn("dbo.Bid", "BiddingAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Bid", "AmountOfBids");
            DropColumn("dbo.Bid", "WinningBid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bid", "WinningBid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bid", "AmountOfBids", c => c.Int(nullable: false));
            DropForeignKey("dbo.Auction", "ProductID", "dbo.Product");
            DropIndex("dbo.Auction", new[] { "ProductID" });
            DropColumn("dbo.Bid", "BiddingAmount");
            DropTable("dbo.Auction");
        }
    }
}
