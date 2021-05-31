using Core.Interfaces;
using Core.Models;
using Core.Specifications;
using Core.Wrappers;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : ProductBase
    {
        private readonly StoreContext _storeContext;

        public GenericRepositoryAsync(StoreContext storeContext )
        {
            _storeContext = storeContext;
        }
        public async Task<ServiceResponse<IReadOnlyList<T>>> GetAllAsync()
        {
            ServiceResponse<IReadOnlyList<T>> response = new ServiceResponse<IReadOnlyList<T>>();
            try
            {
                response.Data = await _storeContext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public async Task<ServiceResponse<T>> GetByIdAsync(int id)
        {
            ServiceResponse<T> response = new ServiceResponse<T>();
            try
            {
                response.Data = await _storeContext.Set<T>().FirstAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ServiceResponse<IReadOnlyList<T>>> GetAllWithSpecsAsync(ISpecification<T> spec)
        {
            
            ServiceResponse<IReadOnlyList<T>> response = new ServiceResponse<IReadOnlyList<T>>();
            try
            {
                response.Data = await ApplySpecification(spec).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            } 
            return response;
        }
        public async Task<ServiceResponse<T>> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            ServiceResponse<T> response = new ServiceResponse<T>();
            try
            {
                response.Data = await ApplySpecification(spec).FirstAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_storeContext.Set<T>().AsQueryable(), spec);
        }

        
    }
}
