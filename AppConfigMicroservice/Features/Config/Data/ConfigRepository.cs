using AppConfigMicroservice.Common.Repository;
using AppConfigMicroservice.Common.Services.CacheService;
using AppConfigMicroservice.DataAccess;
using AppConfigMicroservice.Domain;
using AppConfigMicroservice.Features.Config.Models;

namespace AppConfigMicroservice.Features.Config.Data
{
    public class ConfigRepository : RepositoryBase<ConfigEntity,ApplicationContext>, IConfigRepository
    {
        private readonly ApplicationContext _context;
        private readonly ICacheService _cacheService;

        public ConfigRepository(ApplicationContext context, ICacheService cacheService) : base(context)
        {
            _context = context;
            _cacheService = cacheService;
        }
        
        public override async Task<ConfigEntity> GetByIdAsync(long id)
        {
            string cacheKey = $"{typeof(ConfigEntity).Name}-{id}";
            var entity = _cacheService.CheckCachedData<ConfigEntity>(cacheKey);

            if (entity is null)
            {
                entity = await base.GetByIdAsync(id);

                if (entity is not null)
                {
                    _cacheService.CheckAndAddToCache(cacheKey, entity);
                }
            }
            return entity;
        }

    }
}
