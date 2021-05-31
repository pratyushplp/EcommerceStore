using Core.Interfaces;
using Core.Models;
using Core.Wrappers;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepositoryAsync : IProductRepositoryAsync
    {
        private readonly StoreContext _storeContext;

        public ProductRepositoryAsync(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

       

        public async Task<ServiceResponse<List<Product>>> GetAllProducts()
        {
            ServiceResponse<List<Product>> response = new ServiceResponse<List<Product>>();
            try
            {
                response.Data = await _storeContext.Products.Include(x=>x.ProductBrand)
                                                            .Include(x=>x.ProductType).ToListAsync();


            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            ServiceResponse<Product> response = new ServiceResponse<Product>();
            try
            {
                response.Data = await _storeContext.Products.Include(x => x.ProductBrand)
                                                            .Include(x => x.ProductType).FirstAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<ProductBrand>>> GetAllProductBrands()
        {
            ServiceResponse<List<ProductBrand>> response = new ServiceResponse<List<ProductBrand>>();
            try
            {
                response.Data = await _storeContext.ProductBrands.ToListAsync();


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ServiceResponse<List<ProductType>>> GetAllProductTypes()
        {
            ServiceResponse<List<ProductType>> response = new ServiceResponse<List<ProductType>>();
            try
            {
                response.Data = await _storeContext.ProductTypes.ToListAsync();


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<ProductBrand>> GetProductBrandById(int id)
        {
            ServiceResponse<ProductBrand> response = new ServiceResponse<ProductBrand>();
            try
            {
                response.Data = await _storeContext.ProductBrands.FirstAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public async Task<ServiceResponse<ProductType>> GetProductTypeById(int id)
        {
            ServiceResponse<ProductType> response = new ServiceResponse<ProductType>();
            try
            {
                response.Data = await _storeContext.ProductTypes.FirstAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
