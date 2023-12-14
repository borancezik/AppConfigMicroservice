using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Data;
using AppConfigMicroservice.Features.Config.Models;
using AppConfigMicroservice.Features.Config.Query;
using AppConfigMicroservice.Features.Config.Services;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command.AddCommand;

internal sealed class ConfigCommandHandler : IRequestHandler<ConfigCommand, ApiResponse<ConfigEntity>>
{
    private readonly IConfigService _configService;
    private readonly IValidator<ConfigCommand> _validator;
    public ConfigCommandHandler(IConfigService configService, IValidator<ConfigCommand> validator)
    {
        _configService = configService;
        _validator = validator;
    }
    public async Task<ApiResponse<ConfigEntity>> Handle(ConfigCommand request, CancellationToken cancellationToken)
    {
        var config = new ConfigEntity { ApplicationId = request.ApplicationId, EnvType = request.EnvType, Config = request.Config, ConfigType = request.ConfigType };

        var result = await _configService.AddAsync(config);

        return result;
    }
}
