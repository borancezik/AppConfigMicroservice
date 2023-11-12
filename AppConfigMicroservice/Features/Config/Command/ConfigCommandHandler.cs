using AppConfigMicroservice.Features.Config.Data;
using AppConfigMicroservice.Features.Config.Models;
using AppConfigMicroservice.Features.Config.Query;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command
{
    internal sealed class ConfigCommandHandler : IRequestHandler<ConfigCommand, ErrorOr<int>>
    {
        private readonly IConfigRepository _configRepository;
        private readonly IValidator<ConfigCommand> _validator;
        public ConfigCommandHandler(IConfigRepository configRepository, IValidator<ConfigCommand> validator)
        {
            _configRepository = configRepository;
            _validator = validator;
        }
        public async Task<ErrorOr<int>> Handle(ConfigCommand request, CancellationToken cancellationToken)
        {
            var config = new ConfigEntity { ApplicationId = request.ApplicationId, EnvType = request.EnvType, Config = request.Config, ConfigType = request.ConfigType };

            var result = _configRepository.AddAsync(config);

            return result.Id;
        }
    }
}
