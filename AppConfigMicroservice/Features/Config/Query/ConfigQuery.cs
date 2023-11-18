using AppConfigMicroservice.Domain;
using AppConfigMicroservice.Features.Config.Models;
using ErrorOr;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query
{
    public record ConfigQuery : IRequest<ApiResponse<ConfigEntity>>
    {
        public long Id { get; set; }
    }
}
