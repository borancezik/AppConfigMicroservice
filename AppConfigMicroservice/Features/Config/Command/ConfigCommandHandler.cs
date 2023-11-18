using AppConfigMicroservice.Features.Config.Data;
using AppConfigMicroservice.Features.Config.Models;
using AppConfigMicroservice.Features.Config.Query;
using AppConfigMicroservice.Features.Config.Services;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command
{
    internal sealed class ConfigCommandHandler : IRequestHandler<ConfigCommand, ErrorOr<int>>
    {
        private readonly IConfigService _configService;
        private readonly IValidator<ConfigCommand> _validator;
        public ConfigCommandHandler(IConfigService configService, IValidator<ConfigCommand> validator)
        {
            _configService = configService;
            _validator = validator;
        }
        public async Task<ErrorOr<int>> Handle(ConfigCommand request, CancellationToken cancellationToken)
        {
            var config = new ConfigEntity { ApplicationId = request.ApplicationId, EnvType = request.EnvType, Config = request.Config, ConfigType = request.ConfigType };

            var result = _configService.AddAsync(config);

            return result.Id;
        }
    }
}
