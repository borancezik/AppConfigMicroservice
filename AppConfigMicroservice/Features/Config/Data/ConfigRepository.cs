﻿using AppConfigMicroservice.Common.Repository;
using AppConfigMicroservice.Common.Services.CacheService;
using AppConfigMicroservice.DataAccess;
using AppConfigMicroservice.Features.Config.Models;

namespace AppConfigMicroservice.Features.Config.Data
{
    public class ConfigRepository : RepositoryBase<ConfigEntity,ApplicationContext>, IConfigRepository
    {
        private readonly ApplicationContext _context;

        public ConfigRepository(ApplicationContext context, ICacheService cacheService) : base(context, cacheService)
        {
            _context = context;
        }
    }
}
