using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Data
{
    public class Bid
    {
        public int BidID { get; set; }
        public Guid OwnerID { get; set; }
        public int AmountOfBids { get; set; }
        public bool WinningBid { get; set; }
        public decimal StartingBid { get; set; }
        public decimal BidIncrement { get; set; }

    }
}
