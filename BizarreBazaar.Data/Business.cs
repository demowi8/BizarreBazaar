using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizarreBazaar.Data
{
    public class Business
    {
        [Key]
        public int BusinessID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

    }
}
