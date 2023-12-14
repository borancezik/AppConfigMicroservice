using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using AppConfigMicroservice.Features.Config.Query.GetById;
using AppConfigMicroservice.Features.Config.Services;
using AppConfigMicroservice.Features.Config.Specifications;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query.GetProductionType;

public class GetProductionTypeHandler : IRequestHandler<GetProductionTypeQuery, ApiResponse<ConfigEntity>>
{
    private readonly IConfigService _configService;
    public GetProductionTypeHandler(IConfigService configService)
    {
        _configService = configService;
    }

    public Task<ApiResponse<ConfigEntity>> Handle(GetProductionTypeQuery request, CancellationToken cancellationToken)
    {
        var specification = new GetProductionTypeSpecification(request.ApplicationId);
        return _configService.GetByFilter(specification);
    }
}
