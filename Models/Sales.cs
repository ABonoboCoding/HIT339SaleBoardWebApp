using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinxuanLinSaleBoardSite.Models
{
    public class Sales
    {
        [Key]
        public int SaleId { get; set; }

        public int ItemId { get; set; }

        public string Buyer { get; set; }

        public int Quantity { get; set; }
      
    }
}
