using AppConfigMicroservice.Common.Services.CacheService;
using AppConfigMicroservice.Features.Config.Data;
using AppConfigMicroservice.Features.Config.Services;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query
{
    internal sealed class ConfigQueryHandler : IRequestHandler<ConfigQuery, ErrorOr<ConfigQueryResponse>>
    {
        private readonly IConfigService _configService;
        private readonly IValidator<ConfigQuery> _validator;
        public ConfigQueryHandler(IConfigService configService, IValidator<ConfigQuery> validator)
        {
            _configService = configService;
            _validator = validator;
        }

        public async Task<ErrorOr<ConfigQueryResponse>> Handle(ConfigQuery request, CancellationToken cancellationToken)
        {
            var config = await _configService.GetByIdAsync(request.Id);

            if (config is null || config.Id < 1)
            {
                return Error.NotFound("400","İlgili kayıt bulunamadı");
            }

            return new ConfigQueryResponse() 
            { 
                ApplicationId = config.ApplicationId, 
                Config = config.Config, 
                ConfigType = config.ConfigType, 
                EnvType = config.EnvType, 
                Id = config.Id 
            };
        }
    }
}
