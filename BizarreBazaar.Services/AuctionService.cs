using BizarreBazaar.Data;
using BizarreBazaar.Models;
using BizarreBazaar.Models.Auction_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Services
{
    public class AuctionService
    {
        private readonly Guid _userID;

        public AuctionService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateAuction(AuctionCreate auction)
        {
            var entity = new Auction()
            {
                OwnerID = _userID,
                Title = auction.Title,
                ProductID = auction.ProductID,
                Created = DateTimeOffset.UtcNow
            };
            using (var ctx = new ApplicationDbContext())
            {


                ctx.Auctions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AuctionListing> GetAuctionListings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {

                    var query = ctx
                        .Auctions
                        .Select(e => new AuctionListing
                        {
                            AuctionID = e.AuctionID,
                            Title = e.Title,
                            ProductID = e.ProductID,
                            Name = e.Product.Name,
                            Description = e.Product.Description,
                            StartingBid = e.Product.StartingBid,
                            ActualAmount = e.Product.StartingBid,
                            CreatedUtc = e.Created
                        });
                    return query.ToArray();
                }
                catch
                {
                    return null;
                }
            }
        }
        public AuctionDetail GetAuctionByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {

                    var entity = ctx
                        .Auctions
                        .Single(e => e.AuctionID == id && e.OwnerID == _userID);
                    return new AuctionDetail
                    {
                        AuctionID = entity.AuctionID,
                        Title = entity.Title,
                        ProductID = entity.ProductID,
                        Name = entity.Product.Name,
                        Description = entity.Product.Description,
                        BidList = entity.Bids.Select(e => new BidListItemBid
                        {
                            BidID = e.BidID,
                            BidAmount = e.BidAmount,
                            AuctionID = e.AuctionID,
                            Created = e.Created,
                            Title = e.Auction.Title
                        }).ToList(),
                        StartingBid = entity.Product.StartingBid,
                        ActualAmount = entity.ActualAmount,
                        CreatedUtc = entity.Created,
                        EndingTime = entity.EndingTime
                    };
                }
                catch
                {
                    return null;
                }
            }
        }
        public bool UpdateAuction(AuctionEdit auction)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Auctions.Single(e => e.AuctionID == auction.AuctionID && e.OwnerID == _userID);

                entity.Title = auction.Title;
                entity.ProductID = auction.ProductID;
                entity.EndingTime = auction.EndingTime;
                entity.Modified = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() >= 1;
            }
        }
        public bool DeleteAuction(int auctionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Auctions.Single(e => e.AuctionID == auctionID && e.OwnerID == _userID);

                ctx.Auctions.Remove(entity);

                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
