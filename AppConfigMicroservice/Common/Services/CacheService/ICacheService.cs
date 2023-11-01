namespace AppConfigMicroservice.Common.Services.CacheService
{
    public interface ICacheService
    {
        void RemoveCachedData(string cacheKey);
        void CheckAndAddToCache<T>(string cacheKey, T data);
        T CheckCachedData<T>(string cacheKey);
    }
}
