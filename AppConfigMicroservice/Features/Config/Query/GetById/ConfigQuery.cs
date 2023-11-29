using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using ErrorOr;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query.GetById
{
    public record ConfigQuery : IRequest<ApiResponse<ConfigEntity>>
    {
        public long Id { get; set; }
    }
}
