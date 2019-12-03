using FluentValidation;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Domain.Validations
{
    public class VinylDiscValidation : AbstractValidator<VinylDisc>
    {
        public VinylDiscValidation()
        {
            RuleFor(v => v.MusicGenreId)
                .GreaterThan(0).WithMessage("MusicGenreId must be greater than 0");

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(1, 200).WithMessage("Name must be between 1 and 100 characters");

            RuleFor(v => v.Value)
                .GreaterThanOrEqualTo(0).WithMessage("Value cannot be negative");
        }
    }
}