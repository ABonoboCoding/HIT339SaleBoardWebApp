using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinxuanLinSaleBoardSite.Models;

namespace MinxuanLinSaleBoardSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MinxuanLinSaleBoardSite.Models.Items> Items { get; set; }
        public DbSet<MinxuanLinSaleBoardSite.Models.Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

/* Commands:
            dotnet tool install --global dotnet-ef 

            dotnet ef migrations add InitialCreate   -- creates script 

             

            dotnet ef database update  -- creates db and runs the migration 

             

            dotnet ef migrations remove 

            dotnet ef database drop 
         */
