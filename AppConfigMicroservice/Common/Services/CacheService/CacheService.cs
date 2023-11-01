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

        public void CheckAndAddToCache<T>(string cacheKey, T data)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions();
            _cache.Set(cacheKey, data, cacheEntryOptions);
        }

        public void RemoveCachedData(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        public T CheckCachedData<T>(string cacheKey)
        {
            var cachedData = _cache.Get(cacheKey);
            return (T)cachedData;
        }
    }
}
