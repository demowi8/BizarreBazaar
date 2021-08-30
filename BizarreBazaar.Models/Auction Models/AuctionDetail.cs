using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Models.Auction_Models
{
    public class AuctionDetail
    {
        public int AuctionID { get; set; }
        public string Title { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset EndingTime { get; set; }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StartingBid { get; set; }
    }
}
