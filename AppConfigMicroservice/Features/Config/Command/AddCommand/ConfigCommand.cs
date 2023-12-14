using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using ErrorOr;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command.AddCommand;

public record ConfigCommand : IRequest<ApiResponse<ConfigEntity>>
{
    public required int ApplicationId { get; set; }
    public required int EnvType { get; set; }
    public required int ConfigType { get; set; }
    public required string Config { get; set; }
}
