using Core.Models;
using Core.Specifications;
using Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : ProductBase
    {
        public Task< IReadOnlyList<T> > GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecification<T> spec);
        public Task<T> GetByIdWithSpecAsync(ISpecification<T> spec);

    }
}
