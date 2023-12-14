﻿using FluentValidation;

namespace AppConfigMicroservice.Features.Config.Query.GetById;

public class ConfigQueryValidator : AbstractValidator<ConfigQuery>
{
    public ConfigQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
