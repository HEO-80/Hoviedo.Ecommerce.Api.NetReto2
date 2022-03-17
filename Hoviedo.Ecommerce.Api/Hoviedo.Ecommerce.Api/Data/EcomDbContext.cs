using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hoviedo.Ecommerce.Api.Models;

namespace Hoviedo.Ecommerce.Api.Data
{
    public class EcomDbContext : DbContext
    {
       
        public EcomDbContext(DbContextOptions<EcomDbContext> options) 
            : base(options) 
        {


        }
       
        public DbSet<Hoviedo.Ecommerce.Api.Models.Cart> Cart { get; set; }
       
        public DbSet<Hoviedo.Ecommerce.Api.Models.Category> Category { get; set; }
       
        public DbSet<Hoviedo.Ecommerce.Api.Models.Product> Product { get; set; }

    }
}