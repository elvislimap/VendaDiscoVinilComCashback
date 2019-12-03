using FluentValidation;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Domain.Validations
{
    public class MusicGenreValidation : AbstractValidator<MusicGenre>
    {
        public MusicGenreValidation()
        {
            RuleFor(m => m.Description)
                .NotEmpty().WithMessage("Description is required")
                .Length(1, 50).WithMessage("Description must be between 1 and 50 characters");
        }
    }
}