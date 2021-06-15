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
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _storeContext.Set<T>().ToListAsync(); 
        }



        public async Task<T> GetByIdAsync(int id)
        {
            return await _storeContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecification<T> spec)
        {          
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_storeContext.Set<T>().AsQueryable(), spec);
        }

        
    }
}
