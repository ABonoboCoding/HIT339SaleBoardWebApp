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
        public int Id { get; set; }

        public int Item { get; set; }

        public string Buyer { get; set; }

        public int Quantity { get; set; }
      
    }
}
