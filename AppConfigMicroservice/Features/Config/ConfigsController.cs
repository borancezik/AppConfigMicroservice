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
                var configId = await sender.Send(command);

                if (configId.IsError)
                {
                    return Results.BadRequest(configId.Errors);
                }
                else
                {
                    return Results.Ok(configId.Value);
                }
            });

            app.MapGet("api/configs", async ([FromQuery] int id, ISender sender) =>
            {
                ConfigQuery query = new ConfigQuery() { Id = id };
                ErrorOr<ConfigQueryResponse> response = await sender.Send(query);

                if (response.IsError)
                {
                    return Results.BadRequest(response.Errors);
                }
                else
                { 
                    return Results.Ok(response.Value);
                }
            });
        }

    }
}
