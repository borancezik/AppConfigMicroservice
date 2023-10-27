using MediatR;

namespace AppConfigMicroservice.Features.Config.Query
{
    public class ConfigQuery : IRequest<ConfigQueryResponse>
    {
        public int Id { get; set; }
    }
}
