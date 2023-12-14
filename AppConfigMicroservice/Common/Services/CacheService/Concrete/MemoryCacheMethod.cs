using AppConfigMicroservice.Common.Services.CacheService.Abstract;
using Microsoft.Extensions.Caching.Memory;

namespace AppConfigMicroservice.Common.Services.CacheService.Concrete;

public class MemoryCacheMethod : ICacheMethod
{
    private readonly IMemoryCache _memoryCache;
    public MemoryCacheMethod(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public async Task AddAsync<T>(string cacheKey, T data, int cachingTime = 20)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cachingTime)
        };

        await Task.Run(() => _memoryCache.Set(cacheKey, data, cacheEntryOptions));
    }

    public async Task DeleteAsync(string cacheKey)
    {
        await Task.Run(() => _memoryCache.Remove(cacheKey));
    }

    public async Task<T> GetAsync<T>(string cacheKey)
    {
        return await Task.Run(() => (T)_memoryCache.Get(cacheKey));
    }
}
