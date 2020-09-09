using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLSaleBoard.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }

        public int Item { get; set; }

        public string Buyer { get; set; }

        public string Seller { get; set; }

        public int ItemQuantity { get; set; }

        public decimal Total { get; set; }
    }
}
