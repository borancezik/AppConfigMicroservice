using AppConfigMicroservice.Features.Config.Data;
using AppConfigMicroservice.Features.Config.Models;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command
{
    internal sealed class ConfigCommandHandler : IRequestHandler<ConfigCommand, int>
    {
        private readonly IConfigRepository _configRepository;
        public ConfigCommandHandler(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }
        public async Task<int> Handle(ConfigCommand request, CancellationToken cancellationToken)
        {
            var config = new ConfigEntity { ApplicationId = request.ApplicationId, EnvType = request.EnvType, Config = request.Config, ConfigType = request.ConfigType };

            var result = _configRepository.AddAsync(config);

            return result.Id;
        }
    }
}
