using AppConfigMicroservice.Common;
using AppConfigMicroservice.DataAccess;
using AppConfigMicroservice.Features.Config.Models;

namespace AppConfigMicroservice.Features.Config.Data
{
    public class ConfigRepository : RepositoryBase<ConfigEntity,ApplicationContext>, IConfigRepository
    {
        private readonly ApplicationContext _context;

        public ConfigRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
