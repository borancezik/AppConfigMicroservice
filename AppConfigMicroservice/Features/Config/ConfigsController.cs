using AppConfigMicroservice.Features.Config.Command;
using AppConfigMicroservice.Features.Config.Query;
using Azure;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppConfigMicroservice.Features.Config
{
    public static class ConfigsController
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/configs", async ([FromBody] ConfigCommand command, ISender sender) =>
            {
                return  await sender.Send(command);
            });

            app.MapGet("api/configs", async ([FromQuery] int id, ISender sender) =>
            {
                ConfigQuery query = new ConfigQuery() { Id = id };
                return await sender.Send(query);
            });
        }

    }
}
