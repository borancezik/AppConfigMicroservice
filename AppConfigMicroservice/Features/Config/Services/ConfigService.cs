using AppConfigMicroservice.Common.Services.CacheService;
using AppConfigMicroservice.Features.Config.Data;
using AppConfigMicroservice.Features.Config.Models;

namespace AppConfigMicroservice.Features.Config.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _configRepository;
        private readonly ICacheService _cacheService;
        public ConfigService(IConfigRepository configRepository, ICacheService cacheService)
        {
            _configRepository = configRepository;
            _cacheService = cacheService;
        }

        public Task<ConfigEntity> AddAsync(ConfigEntity config)
        {
            return _configRepository.AddAsync(config);  
        }

        public async Task<ConfigEntity> GetByIdAsync(long id)
        {
            string cacheKey = $"{typeof(ConfigEntity).Name}-{id}";
            var config = await _cacheService.GetAsync<ConfigEntity>(cacheKey);

            if (config is null)
            {
                config = await _configRepository.GetByIdAsync(id);

                if (config is not null)
                {
                    await _cacheService.AddAsync(cacheKey, config);
                }
            }
            return config;
        }
    }
}
