using FluentValidation;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Domain.Validations
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(c => c.FullName)
                .NotEmpty().WithMessage("FullName is required")
                .Length(2, 100).WithMessage("FullName must be between 2 and 100 characters");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required")
                .MaximumLength(100).WithMessage("Email must be at most 100 characters")
                .EmailAddress().WithMessage("Email invalid");
        }
    }
}