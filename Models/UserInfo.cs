using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MinxuanLinSaleBoardSite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }
    }
}
