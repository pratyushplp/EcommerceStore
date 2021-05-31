using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Wrappers;

namespace Core.Interfaces
{
    public interface IProductRepositoryAsync
    {
        public Task<ServiceResponse<List<Product>>> GetAllProducts();
        public Task<ServiceResponse<Product>> GetProductById(int id);
        public Task<ServiceResponse<List<ProductBrand>>> GetAllProductBrands();
        public Task<ServiceResponse<ProductBrand>> GetProductBrandById(int id);
        public Task<ServiceResponse<List<ProductType>>> GetAllProductTypes();
        public Task<ServiceResponse<ProductType>> GetProductTypeById(int id);

    }
}
