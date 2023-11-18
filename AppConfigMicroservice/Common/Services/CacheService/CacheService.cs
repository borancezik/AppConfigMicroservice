using Microsoft.Extensions.Caching.Memory;

namespace AppConfigMicroservice.Common.Services.CacheService
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task AddAsync<T>(string cacheKey, T data, int cachingTime = 20)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cachingTime) };
            await Task.Run(() => _cache.Set(cacheKey, data, cacheEntryOptions));
        }

        public async Task DeleteAsync(string cacheKey)
        {
            await Task.Run(() => _cache.Remove(cacheKey));
        }

        public async Task<T> GetAsync<T>(string cacheKey)
        {
            var cachedData = await Task.Run(() => _cache.Get(cacheKey));
            return (T)cachedData;
        }
    }
}
