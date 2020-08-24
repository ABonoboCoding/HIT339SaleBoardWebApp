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

        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Full address")]
        public string Address { get; set; }
    }
}
