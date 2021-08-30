namespace BizarreBazaar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeventhMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "BidID", "dbo.Bid");
            DropIndex("dbo.Product", new[] { "BidID" });
            DropColumn("dbo.Product", "BidID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "BidID", c => c.Int());
            CreateIndex("dbo.Product", "BidID");
            AddForeignKey("dbo.Product", "BidID", "dbo.Bid", "BidID");
        }
    }
}
