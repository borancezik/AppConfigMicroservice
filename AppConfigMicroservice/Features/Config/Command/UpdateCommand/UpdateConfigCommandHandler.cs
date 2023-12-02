using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Command.UpdateCommand
{
    public class UpdateConfigCommandHandler : IRequestHandler<UpdateConfigCommand, ApiResponse<ConfigEntity>>
    {
        public Task<ApiResponse<ConfigEntity>> Handle(UpdateConfigCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
