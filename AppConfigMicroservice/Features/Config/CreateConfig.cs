using AppConfigMicroservice.Features.Config.Data;
using AppConfigMicroservice.Features.Config.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.CompilerServices;

namespace AppConfigMicroservice.Features.Config
{
    public static class CreateConfig
    {
        public class Command : IRequest<int>
        {
            public int? ApplicationId { get; set; }
            public int? EnvType { get; set; }
            public int? ConfigType { get; set; }
            public string? Config { get; set; } = string.Empty;
        }

        internal sealed class Handler : IRequestHandler<Command, int>
        {
            private readonly IConfigRepository _configRepository;
            public Handler(IConfigRepository configRepository)
            {
                _configRepository = configRepository;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var config = new ConfigEntity { ApplicationId = request.ApplicationId, EnvType = request.EnvType, Config = request.Config, ConfigType = request.ConfigType };

                var result = _configRepository.Add(config);

                return result.Id;
            }
        }
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/articles", async (CreateConfig.Command command, ISender sender) =>
            {
                var configId = await sender.Send(command);

                return Results.Ok(configId);
            });
        }
    }
}
