using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query.GetPreProductionType;

public record GetPreProductionTypeQuery : IRequest<ApiResponse<ConfigEntity>>
{
    public int ApplicationId { get; set; }
}
