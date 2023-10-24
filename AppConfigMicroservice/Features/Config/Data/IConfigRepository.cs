using AppConfigMicroservice.Common;
using AppConfigMicroservice.Features.Config.Models;

namespace AppConfigMicroservice.Features.Config.Data
{
    public interface IConfigRepository : IRepositoryBase<ConfigEntity>
    {
    }
}
