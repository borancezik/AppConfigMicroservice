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
    }
}
