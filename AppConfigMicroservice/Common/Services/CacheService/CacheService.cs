using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using StackExchange.Redis;
using System.Diagnostics;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppConfigMicroservice.Common.Services.CacheService
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distrubutedCache;
        private readonly IOptionsMonitor<AppSettings> _appSettings;
        private int _cacheType;
        public CacheService(IMemoryCache memoryCache, IDistributedCache distrubutedCache, IOptionsMonitor<AppSettings> appSettings)
        {
            _memoryCache = memoryCache;
            _appSettings = appSettings;
            _distrubutedCache = distrubutedCache;
            _cacheType = _appSettings.CurrentValue.RedisSettings.CachingType;
            _appSettings.OnChange((newSettings, _) =>
            {
                _cacheType = newSettings.RedisSettings.CachingType;
            });
        }

        public async Task AddAsync<T>(string cacheKey, T data, int cachingTime = 20)
        {
            if (_cacheType is 1)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cachingTime) };
                await Task.Run(() => _memoryCache.Set(cacheKey, data, cacheEntryOptions));
            }
            else
            {
                var cacheEntryOptions = new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cachingTime) };
                await _distrubutedCache.SetStringAsync(cacheKey, JsonSerializer.Serialize(data), cacheEntryOptions);
            }
        }

        public async Task DeleteAsync(string cacheKey)
        {
            if (_cacheType is 1)
            {
                await Task.Run(() => _memoryCache.Remove(cacheKey));
            }
            else
            {
                await _distrubutedCache.RemoveAsync(cacheKey);
            }
        }

        public async Task<T> GetAsync<T>(string cacheKey)
        {
            object cachedData;
            if (_cacheType is 1)
            {
                cachedData = await Task.Run(() => _memoryCache.Get(cacheKey));
            }
            else
            {
                cachedData = await _distrubutedCache.GetStringAsync(cacheKey);
            }
            return (T)cachedData;
        }
    }
}
