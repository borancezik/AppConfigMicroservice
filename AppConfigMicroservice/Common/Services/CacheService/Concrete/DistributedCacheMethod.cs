using AppConfigMicroservice.Common.Services.CacheService.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace AppConfigMicroservice.Common.Services.CacheService.Concrete;

public class DistributedCacheMethod : ICacheMethod
{
    private readonly IDistributedCache _distributedCache;

    public DistributedCacheMethod(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task AddAsync<T>(string cacheKey, T data, int cachingTime = 20)
    {
        var cacheEntryOptions = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cachingTime)
        };

        await _distributedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(data), cacheEntryOptions);
    }

    public async Task DeleteAsync(string cacheKey)
    {
        await _distributedCache.RemoveAsync(cacheKey);
    }

    public async Task<T> GetAsync<T>(string cacheKey)
    {
        var cachedDataString = await _distributedCache.GetStringAsync(cacheKey);

        if (cachedDataString != null)
        {
            return JsonSerializer.Deserialize<T>(cachedDataString);
        }

        return default(T);
    }
}
