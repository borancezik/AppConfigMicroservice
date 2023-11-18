using AppConfigMicroservice.Domain;
using AppConfigMicroservice.Features.Config.Models;
using ErrorOr;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command
{
    public record ConfigCommand : IRequest<ApiResponse<ConfigEntity>>
    {
        public required int ApplicationId { get; set; }
        public int? EnvType { get; set; }
        public int? ConfigType { get; set; }
        public string? Config { get; set; }
    }
}
