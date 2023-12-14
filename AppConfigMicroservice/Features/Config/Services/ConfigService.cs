using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Common.Models.Utils;
using AppConfigMicroservice.Common.Services.CacheService.Abstract;
using AppConfigMicroservice.Common.Services.CacheService.Concrete;
using AppConfigMicroservice.Common.Specifications;
using AppConfigMicroservice.Features.Application.Data;
using AppConfigMicroservice.Features.Config.Data;
using AppConfigMicroservice.Features.Config.Models;

namespace AppConfigMicroservice.Features.Config.Services;

public class ConfigService : IConfigService
{
    private readonly IConfigRepository _configRepository;
    private readonly CacheService _cacheService;
    public ConfigService(IConfigRepository configRepository, CacheService cacheService)
    {
        _configRepository = configRepository;
        _cacheService = cacheService;
    }

    public async Task<ApiResponse<ConfigEntity>> AddAsync(ConfigEntity config)
    {
        var entity = await _configRepository.AddAsync(config);
        if (entity is not null)
        {
            return ApiResponse<ConfigEntity>.SuccessResult(entity);
        }
        else
        {
            return ApiResponse<ConfigEntity>.FailureResult(Constants.NotUpdated);
        }

    }

    public async Task<List<ConfigEntity>> GetAll(int pageNumber, int pageSize)
    {
        return await _configRepository.GetAll(pageNumber, pageSize);
    }

    public async Task<ApiResponse<ConfigEntity>> GetByFilter(Specification<ConfigEntity> specification)
    {
        var result = await _configRepository.GetByFilter(specification);
        if (result is not null)
        {
            return ApiResponse<ConfigEntity>.SuccessResult(result);
        }
        else
        {
            return ApiResponse<ConfigEntity>.FailureResult(Constants.NotFound);
        }
    }

    public async Task<ApiResponse<ConfigEntity>> GetByIdAsync(long id)
    {
        string cacheKey = $"{nameof(ConfigEntity)}-{id}";
        var configCache = await _cacheService.GetAsync<ConfigEntity>(cacheKey);

        if (configCache is not null)
            return ApiResponse<ConfigEntity>.SuccessResult(configCache);

        var configEntity = await _configRepository.GetByIdAsync(id);
        if (configEntity is not null)
        {
            await _cacheService.AddAsync(cacheKey, configEntity);
            return ApiResponse<ConfigEntity>.SuccessResult(configEntity);
        }

        return ApiResponse<ConfigEntity>.FailureResult(Constants.NotFound);
    }

    public async Task<ApiResponse<ConfigEntity>> UpdateAsync(ConfigEntity entity)
    {
        var result = await _configRepository.Update(entity);
        if (result is not null)
        {
            return ApiResponse<ConfigEntity>.SuccessResult(entity);
        }
        else
        {
            return ApiResponse<ConfigEntity>.FailureResult(Constants.NotUpdated);
        }
    }
}
