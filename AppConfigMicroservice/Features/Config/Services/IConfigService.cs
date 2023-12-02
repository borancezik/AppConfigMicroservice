using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Common.Models.Entities;
using AppConfigMicroservice.Common.Specifications;
using AppConfigMicroservice.Features.Config.Models;

namespace AppConfigMicroservice.Features.Config.Services
{
    public interface IConfigService
    {
        Task<ApiResponse<ConfigEntity>> GetByIdAsync(long id);
        Task<ApiResponse<ConfigEntity>> AddAsync(ConfigEntity entity);
        Task<ApiResponse<ConfigEntity>> UpdateAsync(ConfigEntity entity);
        Task<List<ConfigEntity>> GetAll(int pageNumber, int pageSize);
        Task<ApiResponse<ConfigEntity>> GetByFilter(Specification<ConfigEntity> specification);
    }
}
