using ErrorOr;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query
{
    public class ConfigQuery : IRequest<ErrorOr<ConfigQueryResponse>>
    {
        public long Id { get; set; }
    }
}
