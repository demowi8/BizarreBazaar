using BizarreBazaar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public decimal BiddingAmount { get; set; }

        public DateTimeOffset Created { get; set; }


    }
}
