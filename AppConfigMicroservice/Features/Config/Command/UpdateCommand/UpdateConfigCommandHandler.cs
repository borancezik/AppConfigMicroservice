using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using AppConfigMicroservice.Features.Config.Services;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command.UpdateCommand;

public class UpdateConfigCommandHandler : IRequestHandler<UpdateConfigCommand, ApiResponse<ConfigEntity>>
{
    private readonly IConfigService _configService;


    public UpdateConfigCommandHandler(IConfigService configService)
    {
        _configService = configService;
    }

    public async Task<ApiResponse<ConfigEntity>> Handle(UpdateConfigCommand request, CancellationToken cancellationToken)
    {
        var config = new ConfigEntity {Id = request.Id, ApplicationId = request.ApplicationId, EnvType = request.EnvType, Config = request.Config, ConfigType = request.ConfigType };

        return await _configService.UpdateAsync(config);
    }
}
