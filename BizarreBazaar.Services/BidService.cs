using BizarreBazaar.Data;
using BizarreBazaar.Models;
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
        public bool CreateBid(BidCreateBid model)
        {
            var entity = new Bid()
            {
                OwnerID = _userID,
                WinningBid = model.WinningBid
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bids.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


    }
}
