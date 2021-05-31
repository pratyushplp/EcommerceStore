using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Data.Config;
using System.Reflection;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {           
            base.OnModelCreating(builder);

            //Applies configuration from all Microsoft.EntityFrameworkCore.IEntityTypeConfiguration (those present in config folder)
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
