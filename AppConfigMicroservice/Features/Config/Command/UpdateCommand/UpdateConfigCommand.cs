using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command.UpdateCommand
{
    public class UpdateConfigCommand : IRequest<ApiResponse<ConfigEntity>>
    {
        public required int ApplicationId { get; set; }
        public required int EnvType { get; set; }
        public required int ConfigType { get; set; }
        public required string Config { get; set; }
    }
}
