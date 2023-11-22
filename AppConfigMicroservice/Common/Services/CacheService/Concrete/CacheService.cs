using AppConfigMicroservice.Common.Models.Utils;
using AppConfigMicroservice.Common.Services.CacheService.Abstract;
using Microsoft.Extensions.Options;

namespace AppConfigMicroservice.Common.Services.CacheService.Concrete
{
    public class CacheService : ICacheService
    {
        private readonly IOptionsMonitor<AppSettings> _appSettings;
        private ICacheMethod _cache;
        public CacheService(MemoryCacheMethod memoryCache, DistributedCacheMethod distrubutedCache, IOptionsMonitor<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            _cache = _appSettings.CurrentValue.RedisSettings.EnableInMemoryCache ? memoryCache : distrubutedCache;
            _appSettings.OnChange((newSettings, _) =>
            {
                _cache = newSettings.RedisSettings.EnableInMemoryCache ? memoryCache : distrubutedCache;
            });
        }

        public async Task AddAsync<T>(string cacheKey, T data, int cachingTime = 20)
        {
            await _cache.AddAsync(cacheKey, data, cachingTime);
        }

        public async Task DeleteAsync(string cacheKey)
        {
            await _cache.DeleteAsync(cacheKey);
        }

        public async Task<T> GetAsync<T>(string cacheKey)
        {
            var result = await _cache.GetAsync<T>(cacheKey);
            return result;
        }
    }
    //public class CacheService : ICacheService
    //{
    //    private readonly IMemoryCache _memoryCache;
    //    private readonly IDistributedCache _distrubutedCache;
    //    private readonly IOptionsMonitor<AppSettings> _appSettings;
    //    private int _cacheType;
    //    public CacheService(IMemoryCache memoryCache, IDistributedCache distrubutedCache, IOptionsMonitor<AppSettings> appSettings)
    //    {
    //        _memoryCache = memoryCache;
    //        _appSettings = appSettings;
    //        _distrubutedCache = distrubutedCache;
    //        _cacheType = _appSettings.CurrentValue.RedisSettings.CachingType;
    //        _appSettings.OnChange((newSettings, _) =>
    //        {
    //            _cacheType = newSettings.RedisSettings.CachingType;
    //        });
    //    }

    //    public async Task AddAsync<T>(string cacheKey, T data, int cachingTime = 20)
    //    {
    //        if (_cacheType is 1)
    //        {
    //            var cacheEntryOptions = new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cachingTime) };
    //            await Task.Run(() => _memoryCache.Set(cacheKey, data, cacheEntryOptions));
    //        }
    //        else
    //        {
    //            var cacheEntryOptions = new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cachingTime) };
    //            await _distrubutedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(data), cacheEntryOptions);
    //        }
    //    }

    //    public async Task DeleteAsync(string cacheKey)
    //    {
    //        if (_cacheType is 1)
    //        {
    //            await Task.Run(() => _memoryCache.Remove(cacheKey));
    //        }
    //        else
    //        {
    //            await _distrubutedCache.RemoveAsync(cacheKey);
    //        }
    //    }

    //    public async Task<T> GetAsync<T>(string cacheKey)
    //    {
    //        object cachedData;
    //        if (_cacheType is 1)
    //        {
    //            cachedData = await Task.Run(() => _memoryCache.Get(cacheKey));
    //        }
    //        else
    //        {
    //            cachedData = await _distrubutedCache.GetStringAsync(cacheKey);
    //        }
    //        return (T)cachedData;
    //    }
    //}
}
