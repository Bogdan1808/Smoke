using System.Text.Json;
using Smoke.Interfaces;
using Smoke.Models;
using StackExchange.Redis;

namespace Smoke.Data.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDatabase _database;
    public BasketRepository(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }
    public async Task<CustomerBasket> GetBasketAsync(string basketId)
    {
        var data = await _database.StringGetAsync(basketId);
        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
    }

    public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
    {
        var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
        if (!created) return null;
        return await GetBasketAsync(basket.Id);
    }

    public async Task<bool> DeleteBasketAsnc(string basketId)
    {
        return await _database.KeyDeleteAsync(basketId);
    }
}