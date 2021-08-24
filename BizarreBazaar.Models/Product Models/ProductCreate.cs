using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Models
{
    public class ProductCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InventoryCount { get; set; }
        public decimal StartingBid { get; set; }

    }
}
