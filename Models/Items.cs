using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLSaleBoard.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; }

        public string ItemImg { get; set; }

        [Required]
        public string ItemDesc { get; set; }

        [Required]
        public int ItemPrice { get; set; }

        [Required]
        public string ItemCategory { get; set; }

        [Required]
        public int ItemQuantity { get; set; }

        public string Seller { get; set; }
    }
}
