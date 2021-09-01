using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Models.Bid_Models
{
    public class BidCreate
    {
        public decimal BidAmount { get; set; }
        public int AuctionID { get; set; }

    }
}
