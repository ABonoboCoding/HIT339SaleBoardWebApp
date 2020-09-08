using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MLSaleBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MLSaleBoard.Models.Items> Items { get; set; }
        public DbSet<MLSaleBoard.Models.Sales> Sales { get; set; }

        public DbSet<MLSaleBoard.Models.CartItems> CartItems { get; set; }
    }
}

/* Commands:
            dotnet tool install --global dotnet-ef 

            dotnet ef migrations add InitialCreate   -- creates script 

             

            dotnet ef database update  -- creates db and runs the migration 

             

            dotnet ef migrations remove 

            dotnet ef database drop 
         */
