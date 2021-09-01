using BizarreBazaar.Data;
using BizarreBazaar.Models;
using BizarreBazaar.Models.Bid_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Services
{
    public class BidService
    {
        private readonly Guid _userID;

        public BidService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateBid(BidCreate bid)
        {
            var entity = new Bid()
            {
                OwnerID = _userID,
                BidAmount = bid.BidAmount,
                AuctionID = bid.AuctionID,
                Created = DateTimeOffset.UtcNow


            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bids.Add(entity);
                return ctx.SaveChanges() >= 0;
            }
        }
        public decimal BidIncrement(decimal newBid)
        {
            if (newBid <= 1)
            {
                decimal bidIncrement = newBid + 10m;
                return bidIncrement;
            }
            return 1;
        }
        public decimal FindHighestBid(int auctionID)
        {
            var service = new AuctionService(_userID);
            var findingAuction = service.GetAuctionByID(auctionID);
            var bidList = findingAuction.BidList;

            var winningBid = bidList.LastOrDefault();


            return winningBid.BidAmount;
        }

    }
}
