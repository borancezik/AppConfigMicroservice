using AppConfigMicroservice.Features.Config.Command;
using AppConfigMicroservice.Features.Config.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppConfigMicroservice.Features.Config
{
    public static class ConfigsController
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/configs", async ([FromBody]ConfigCommand command, ISender sender) =>
            {
                var configId = await sender.Send(command);

                return Results.Ok(configId);
            });

            app.MapGet("api/configs", async ([FromQuery]int id, ISender sender) =>
            {
                ConfigQuery query = new ConfigQuery() { Id = id };
                var response = await sender.Send(query);

                return Results.Ok(response);
            });
        }

    }
}
