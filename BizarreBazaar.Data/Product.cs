using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Data
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(1,2000, ErrorMessage ="Choose Wisely")]
        [Display(Name="Stock")]
        public int AmountOf { get; set; }
        
        [Required]
        [MaxLength(150, ErrorMessage ="Too many words")]
        public string Description { get; set; }
    }
}
