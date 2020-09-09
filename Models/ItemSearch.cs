using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLSaleBoard.Models
{
    public class ItemSearch
    {
        public List<Items> Items { get; set; }
        public SelectList ItemCategory { get; set; }
        public string Category { get; set; }
        public string SearchString { get; set; }
    }
}
