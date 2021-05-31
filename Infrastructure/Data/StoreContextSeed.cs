using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {



        public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory)
        {
            storeContext.Database.OpenConnection();
            try
            {

                if (!storeContext.ProductTypes.Any())
                {
                    string seedJsonData = File.ReadAllText("../Infrastructure/Data/SeedData/Type.json");
                    List<ProductType> finalData = JsonSerializer.Deserialize<List<ProductType>>(seedJsonData);

                    foreach (var productType in finalData)
                    {
                        storeContext.ProductTypes.Add(productType);
                    }
                    // only one table can have identity insert ON at one database session
                    storeContext.Database.ExecuteSqlRaw("SET Identity_insert dbo.productTypes ON");
                    await storeContext.SaveChangesAsync();
                    storeContext.Database.ExecuteSqlRaw("SET Identity_insert dbo.productTypes OFF");

                    //await storeContext.Database.ExecuteSqlRawAsync("SET Identity_insert dbo.productTypes OFF");


                }


                if (!storeContext.ProductBrands.Any())
                {
                    string seedJsonData = File.ReadAllText("../Infrastructure/Data/SeedData/Brand.json");
                    List<ProductBrand> finalData = JsonSerializer.Deserialize<List<ProductBrand>>(seedJsonData);

                    foreach (var productBrand in finalData)
                    {

                        storeContext.ProductBrands.Add(productBrand);
                    }
                    //TODO: Create a function which allows only MSSQL database to set identity insert on
                    // insert the used database name in appconfig
                    // only one table can have identity insert on at one database session
                    storeContext.Database.ExecuteSqlRaw("SET Identity_insert dbo.productBrands ON");
                    await storeContext.SaveChangesAsync();
                    storeContext.Database.ExecuteSqlRaw("SET Identity_insert dbo.productBrands OFF");
                }

                if (!storeContext.Products.Any())
                {
                    string seedJsonData = File.ReadAllText("../Infrastructure/Data/SeedData/Product.json");
                    List<Product> finalData = JsonSerializer.Deserialize<List<Product>>(seedJsonData);

                    foreach (var product in finalData)
                    {
                        storeContext.Products.Add(product);
                    }
                    storeContext.Database.ExecuteSqlRaw("SET Identity_insert dbo.products ON");
                    await storeContext.SaveChangesAsync();
                    storeContext.Database.ExecuteSqlRaw("SET Identity_insert dbo.products OFF");

                }



            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }

            finally
            {
                storeContext.Database.CloseConnection();

            }
        }

    }
}
