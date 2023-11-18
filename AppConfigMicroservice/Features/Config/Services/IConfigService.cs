using AppConfigMicroservice.Features.Config.Models;

namespace AppConfigMicroservice.Features.Config.Services
{
    public interface IConfigService
    {
        Task<ConfigEntity> GetByIdAsync(long id);
        Task<ConfigEntity> AddAsync(ConfigEntity entity);
    }
}
