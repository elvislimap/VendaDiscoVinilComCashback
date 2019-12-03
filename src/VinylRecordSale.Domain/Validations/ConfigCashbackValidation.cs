using FluentValidation;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Domain.Validations
{
    public class ConfigCashbackValidation : AbstractValidator<ConfigCashback>
    {
        public ConfigCashbackValidation()
        {
            const string message = "Percent cannot be negative";

            RuleFor(c => c.PercentageSunday)
                .GreaterThanOrEqualTo(0).WithMessage(message);

            RuleFor(c => c.PercentageMonday)
                .GreaterThanOrEqualTo(0).WithMessage(message);

            RuleFor(c => c.PercentageTuesday)
                .GreaterThanOrEqualTo(0).WithMessage(message);

            RuleFor(c => c.PercentageWednesday)
                .GreaterThanOrEqualTo(0).WithMessage(message);

            RuleFor(c => c.PercentageThursday)
                .GreaterThanOrEqualTo(0).WithMessage(message);

            RuleFor(c => c.PercentageFriday)
                .GreaterThanOrEqualTo(0).WithMessage(message);

            RuleFor(c => c.PercentageSaturday)
                .GreaterThanOrEqualTo(0).WithMessage(message);
        }
    }
}