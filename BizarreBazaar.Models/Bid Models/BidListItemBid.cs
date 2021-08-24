using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Models
{
    public class BidListItemBid
    {
        public int BidID { get; set; }
        public int AmountOfBids { get; set; }
        public DateTimeOffset Created { get; set; }
        public bool WinningBid { get; set; }
    }
}
