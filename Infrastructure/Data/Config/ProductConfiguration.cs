using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    //Create a configuration class to Configure Database through entity framework
    //Note : we could have configured the database directly in the storeContext class but this approach makes the code cleaner
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.PictureUrl).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Price).HasPrecision(18,2);

            //We can define relationships here , but the below relationship is already created by entity framework
            //builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrand);

        }

    }
}
