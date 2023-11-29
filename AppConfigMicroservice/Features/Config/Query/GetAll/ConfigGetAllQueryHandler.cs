using AppConfigMicroservice.Features.Config.Models;
using AppConfigMicroservice.Features.Config.Services;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query.GetAll
{
    public class ConfigGetAllQueryHandler : IRequestHandler<ConfigGetAllQuery, List<ConfigEntity>>
    {
        private readonly IConfigService _configService;
        public ConfigGetAllQueryHandler(IConfigService configService)
        {
            _configService = configService;
        }

        public async Task<List<ConfigEntity>> Handle(ConfigGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _configService.GetAll(request.Page,request.Size);
        }
    }
}
