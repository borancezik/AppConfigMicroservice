using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Application.Data;
using AppConfigMicroservice.Features.Config.Models;
using AppConfigMicroservice.Features.Config.Services;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command.UpdateCommand
{
    public class UpdateConfigCommandHandler : IRequestHandler<UpdateConfigCommand, ApiResponse<ConfigEntity>>
    {
        private readonly IConfigService _configService;
        private readonly IApplicationRepository _applicationRepository;

        public UpdateConfigCommandHandler(IConfigService configService, IApplicationRepository applicationRepository)
        {
            _configService = configService;
            _applicationRepository = applicationRepository;
        }

        public async Task<ApiResponse<ConfigEntity>> Handle(UpdateConfigCommand request, CancellationToken cancellationToken)
        {
            var config = new ConfigEntity { ApplicationId = request.ApplicationId, EnvType = request.EnvType, Config = request.Config, ConfigType = request.ConfigType };

            var result = await _configService.UpdateAsync(config);

            if (result.IsSuccess)
            {
                var applicationInfo = _applicationRepository.GetByIdAsync(config.ApplicationId);
                if(applicationInfo is not null)
                {
                    // webhook
                }
            }

            return result;
        }
    }
}
