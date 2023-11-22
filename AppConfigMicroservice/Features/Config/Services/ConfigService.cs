using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Common.Services.CacheService.Abstract;
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

        public Task<ApiResponse<ConfigEntity>> AddAsync(ConfigEntity config)
        {
            return _configRepository.AddAsync(config);  
        }

        public async Task<ApiResponse<ConfigEntity>> GetByIdAsync(long id)
        {
            string cacheKey = $"{typeof(ConfigEntity).Name}-{id}";
            var configCache = await _cacheService.GetAsync<ConfigEntity>(cacheKey);

            if (configCache is null)
            {
                var configEntity = await _configRepository.GetByIdAsync(id);

                if (configEntity is not null)
                {
                    await _cacheService.AddAsync(cacheKey, configEntity);
                }

                return configEntity;
            }
            else
            {
                return ApiResponse<ConfigEntity>.SuccessResult(configCache);
            }
        }
    }
}
