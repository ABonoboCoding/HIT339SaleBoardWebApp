﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinxuanLinSaleBoardSite.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }

        public string ItemName { get; set; }

        public string ItemImg { get; set; }

        public string ItemDesc { get; set; }

        public int ItemPrice { get; set; }

        public string ItemCategory { get; set; }

        public int ItemQuantity { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Posted { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }

        public string Seller { get; set; }
    }
}
