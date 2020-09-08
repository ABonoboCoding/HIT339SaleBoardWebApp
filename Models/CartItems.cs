using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MLSaleBoard.Models
{
    public class CartItems
    {
        [Key]
        public int Id { get; set; }

        public int CartId { get; set; }

        public int Item { get; set; }

        public int ItemQuantity { get; set; }

        public string Buyer { get; set; }
        
    }
}
