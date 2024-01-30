using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command.UpdateCommand;

public record UpdateConfigCommand : IRequest<ApiResponse<ConfigEntity>>
{
    public required long Id { get; set; }
    public required int ApplicationId { get; set; }
    public required int EnvType { get; set; }
    public required int ConfigType { get; set; }
    public required string Config { get; set; }
}
