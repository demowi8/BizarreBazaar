using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Data
{
    public class Bid
    {
        [Key]
        public int BidID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public int AmountOfBids { get; set; }

        [Required]
        public bool WinningBid { get; set; }

        [Required]
        public decimal StartingBid { get; set; }
        public decimal BidIncrement { get; set; }

        public DateTimeOffset Created { get; set; }

    }
}
