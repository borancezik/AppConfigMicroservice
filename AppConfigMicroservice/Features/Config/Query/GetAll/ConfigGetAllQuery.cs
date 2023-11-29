using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query.GetAll
{
    public class ConfigGetAllQuery : IRequest<List<ConfigEntity>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public long Id { get; set; }
    }
}
