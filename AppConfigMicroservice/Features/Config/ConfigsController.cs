using AppConfigMicroservice.Features.Config.Command.AddCommand;
using AppConfigMicroservice.Features.Config.Query.GetAll;
using AppConfigMicroservice.Features.Config.Query.GetById;
using AppConfigMicroservice.Features.Config.Query.GetProductionType;
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

            app.MapGet("api/configs/getall", async ([FromQuery] int pageNumber, [FromQuery] int pageSize, ISender sender) =>
            {
                ConfigGetAllQuery query = new ConfigGetAllQuery() { Page = pageNumber,Size = pageSize };
                return await sender.Send(query);
            });

            app.MapGet("api/configs/getbyfilter", async ([FromQuery] int applicationId, ISender sender) =>
            {
                GetProductionTypeQuery query = new GetProductionTypeQuery() { ApplicationId = applicationId };
                return await sender.Send(query);
            });
        }

    }
}
