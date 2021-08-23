namespace BizarreBazaar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bid",
                c => new
                    {
                        BidID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        AmountOfBids = c.Int(nullable: false),
                        WinningBid = c.Boolean(nullable: false),
                        StartingBid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BidIncrement = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.BidID);
            
            AddColumn("dbo.Product", "StartingBid", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "StartingBid");
            DropTable("dbo.Bid");
        }
    }
}
