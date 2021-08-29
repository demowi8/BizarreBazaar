using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Models.Auction_Models
{
    public class AuctionEdit
    {
        public int AuctionID { get; set; }

        public string Title { get; set; }
        public DateTimeOffset Modified { get; set; }
        public DateTimeOffset EndingTime { get; set; }
        public int ProductID { get; set; }
    }
}
