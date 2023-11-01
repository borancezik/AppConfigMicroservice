using AppConfigMicroservice.Common.Services.CacheService;
using AppConfigMicroservice.Features.Config.Data;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query
{
    internal sealed class ConfigQueryHandler : IRequestHandler<ConfigQuery, ConfigQueryResponse>
    {
        private readonly IConfigRepository _configRepository;
        public ConfigQueryHandler(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public async Task<ConfigQueryResponse> Handle(ConfigQuery request, CancellationToken cancellationToken)
        {
            var response = await _configRepository.GetByIdAsync(request.Id);

            return new ConfigQueryResponse() 
            { 
                ApplicationId = response.ApplicationId, 
                Config = response.Config, 
                ConfigType = response.ConfigType, 
                EnvType = response.EnvType, 
                Id = response.Id 
            };
        }
    }
}
