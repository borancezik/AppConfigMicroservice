﻿using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Features.Config.Models;
using MediatR;

namespace AppConfigMicroservice.Features.Config.Query.GetProductionType
{
    public class GetProductionTypeQuery : IRequest<ApiResponse<ConfigEntity>>
    {
        public int ApplicationId { get; set; }
    }
}
