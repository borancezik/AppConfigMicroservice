using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;

namespace AppConfigMicroservice.Features.Config.Services
{
    public interface IConfigService
    {
        Task<ApiResponse<ConfigEntity>> GetByIdAsync(long id);
        Task<ApiResponse<ConfigEntity>> AddAsync(ConfigEntity entity);
    }
}
