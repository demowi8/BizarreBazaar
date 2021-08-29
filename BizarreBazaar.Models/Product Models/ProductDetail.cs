using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Models
{
    public class ProductDetail
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "# in Stock")]
        public int InventoryCount { get; set; }
        public decimal Price { get; set; }
        public decimal StartingBid { get; set; }
        public decimal? BidIncrement { get; set; }


        public virtual BidCreateBid Bid { get; set; }
    }
}
