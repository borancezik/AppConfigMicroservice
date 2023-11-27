using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using AppConfigMicroservice.Features.Config.Services;
using FluentValidation;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query
{
    internal sealed class ConfigQueryHandler : IRequestHandler<ConfigQuery, ApiResponse<ConfigEntity>>
    {
        private readonly IConfigService _configService;
        private readonly IValidator<ConfigQuery> _validator;
        public ConfigQueryHandler(IConfigService configService, IValidator<ConfigQuery> validator)
        {
            _configService = configService;
            _validator = validator;
        }

        public async Task<ApiResponse<ConfigEntity>> Handle(ConfigQuery request, CancellationToken cancellationToken)
        {
            return await _configService.GetByIdAsync(request.Id);
        }
    }
}
