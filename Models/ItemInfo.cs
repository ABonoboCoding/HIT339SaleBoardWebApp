using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinxuanLinSaleBoardSite.Models
{
    public class ItemInfo
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemImg { get; set; }

        public string ItemDesc { get; set; }

        public string ItemCategory { get; set; }

        public int ItemQuantity { get; set; }

        public string UserEmail { get; set; }
    }
}
