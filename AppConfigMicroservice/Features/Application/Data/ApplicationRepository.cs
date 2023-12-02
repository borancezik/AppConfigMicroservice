using AppConfigMicroservice.Common.Repository;
using AppConfigMicroservice.DataAccess;
using AppConfigMicroservice.Features.Application.Domain;

namespace AppConfigMicroservice.Features.Application.Data
{
    public class ApplicationRepository : RepositoryBase<ApplicationEntity, ApplicationContext>, IApplicationRepository
    {
        public ApplicationRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
