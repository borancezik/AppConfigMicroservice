using AppConfigMicroservice.Features.Config.Command;
using MediatR;

namespace AppConfigMicroservice.Features.Config
{
    public static class ConfigsController
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/articles", async (ConfigCommand command, ISender sender) =>
            {
                var configId = await sender.Send(command);

                return Results.Ok(configId);
            });
        }
    }
}
