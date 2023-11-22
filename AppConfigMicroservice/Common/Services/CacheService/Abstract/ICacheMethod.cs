namespace AppConfigMicroservice.Common.Services.CacheService.Abstract
{
    public interface ICacheMethod
    {
        Task AddAsync<T>(string cacheKey, T data, int cachingTime = 20);
        Task DeleteAsync(string cacheKey);
        Task<T> GetAsync<T>(string cacheKey);
    }
}
