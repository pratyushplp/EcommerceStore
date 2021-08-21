using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBasketRepositoryAsync
    {
        public Task<Basket> GetBasketAsync(string basketId);
        public Task<Basket> UpdateBasketAsync(Basket basket);
        public Task<bool> DeleteBasketAsync(string basketId);
    }
}
