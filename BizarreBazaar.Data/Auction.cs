using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Data
{
    public class Auction
    {
        [Key]
        public int AuctionID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        public decimal ActualAmount { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        public DateTimeOffset EndingTime { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public virtual List<Bid> Bids { get; set; }

    }
}
