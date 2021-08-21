using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using StackExchange.Redis;

namespace Infrastructure.Repositories
{
    public class BasketRepositoryAsync : IBasketRepositoryAsync
    {
        private IDatabase _database;
        public BasketRepositoryAsync(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<Basket> GetBasketAsync(string basketId)
        {
            var value = await _database.StringGetAsync(basketId);

            return value.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(value);
        }

        public async Task<Basket> UpdateBasketAsync(Basket basket)
        {
            bool isUpdated = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(14));
            if (!isUpdated) return null;
            return await GetBasketAsync(basket.Id);
        }
    }
}
