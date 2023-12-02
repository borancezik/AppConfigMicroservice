using AppConfigMicroservice.Common.Repository;
using AppConfigMicroservice.Features.Application.Domain;

namespace AppConfigMicroservice.Features.Application.Data
{
    public interface IApplicationRepository : IRepositoryBase<ApplicationEntity>
    {
    }
}
