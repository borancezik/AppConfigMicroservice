using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using AppConfigMicroservice.Features.Config.Services;
using AppConfigMicroservice.Features.Config.Specifications;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query.GetPreProductionType;

public class GetPreProductionTypeHandler : IRequestHandler<GetPreProductionTypeQuery, ApiResponse<ConfigEntity>>
{
    private readonly IConfigService _configService;
    public GetPreProductionTypeHandler(IConfigService configService)
    {
        _configService = configService;
    }
    public Task<ApiResponse<ConfigEntity>> Handle(GetPreProductionTypeQuery request, CancellationToken cancellationToken)
    {
        var specification = new GetProductionTypeSpecification(request.ApplicationId);
        return _configService.GetByFilter(specification);
    }
}
