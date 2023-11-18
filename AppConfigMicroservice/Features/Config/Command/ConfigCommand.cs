using ErrorOr;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command
{
    public record ConfigCommand : IRequest<ErrorOr<int>>
    {
        public required int ApplicationId { get; set; }
        public int? EnvType { get; set; }
        public int? ConfigType { get; set; }
        public string? Config { get; set; }
    }
}
