using AppConfigMicroservice.Features.Config.Command.AddCommand;
using AppConfigMicroservice.Features.Config.Query.GetAll;
using AppConfigMicroservice.Features.Config.Query.GetById;
using AppConfigMicroservice.Features.Config.Query.GetPreProductionType;
using AppConfigMicroservice.Features.Config.Query.GetProductionType;
using Azure;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppConfigMicroservice.Features.Config;

public static class ConfigsController
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/configs", async ([FromBody] ConfigCommand command, ISender sender) =>
        {
            return  await sender.Send(command);
        });

        app.MapGet("api/configs/{id}", async ([FromQuery] int id, ISender sender) =>
        {
            ConfigQuery query = new ConfigQuery() { Id = id };
            return await sender.Send(query);
        });

        app.MapGet("api/configs", async ([FromQuery] int pageNumber, [FromQuery] int pageSize, ISender sender) =>
        {
            ConfigGetAllQuery query = new ConfigGetAllQuery() { Page = pageNumber,Size = pageSize };
            return await sender.Send(query);
        });

        app.MapGet("api/configs/production/{id}", async ([FromQuery] int applicationId, ISender sender) =>
        {
            GetProductionTypeQuery query = new GetProductionTypeQuery() { ApplicationId = applicationId };
            return await sender.Send(query);
        });

        app.MapGet("api/configs/preproduction/{id}", async ([FromQuery] int applicationId, ISender sender) =>
        {
            GetPreProductionTypeQuery query = new GetPreProductionTypeQuery() { ApplicationId = applicationId };
            return await sender.Send(query);
        });
    }

}
