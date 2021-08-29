using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Models.Auction_Models
{
    public class AuctionCreate
    {
        public string Title { get; set; }


        public DateTimeOffset CreatedUtc  { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
