using FluentValidation;

namespace AppConfigMicroservice.Features.Config.Command
{
    public class ConfigCommandValidator : AbstractValidator<ConfigCommand>
    {
        public ConfigCommandValidator()
        {
            RuleFor(x => x.ConfigType)
            .LessThanOrEqualTo(4)
            .WithMessage("ConfigType alanı 4 değerinden büyük olamaz.");
        }
    }
}
