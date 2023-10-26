using MediatR;

namespace AppConfigMicroservice.Features.Config.Command
{
    public class ConfigCommand : IRequest<int>
    {
        public int? ApplicationId { get; set; }
        public int? EnvType { get; set; }
        public int? ConfigType { get; set; }
        public string? Config { get; set; }
    }
}
