namespace BizarreBazaar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "BidID", c => c.Int());
            CreateIndex("dbo.Product", "BidID");
            AddForeignKey("dbo.Product", "BidID", "dbo.Bid", "BidID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "BidID", "dbo.Bid");
            DropIndex("dbo.Product", new[] { "BidID" });
            DropColumn("dbo.Product", "BidID");
        }
    }
}
