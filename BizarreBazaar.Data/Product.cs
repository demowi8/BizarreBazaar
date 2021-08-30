using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Data
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 2000, ErrorMessage = "Have at least 1 and no more than 2000.")]
        [Display(Name = "# in Stock")]
        public int InventoryCount { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Too many words")]
        public string Description { get; set; }

        public decimal StartingBid { get; set; }
        public decimal? BidIncrement
        {
            get
            {
                if (Price >= 1)
                {
                    decimal bidIncrement = Price * 0.10m;
                    return bidIncrement;
                }
                return null;
            }
        }

        //[ForeignKey("Bid")]
        //public int? BidID { get; set; }
        //public virtual Bid Bid { get; set; }

    }
}
