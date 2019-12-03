using FluentValidation;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Domain.Validations
{
    public class ItemSaleValidation : AbstractValidator<ItemSale>
    {
        public ItemSaleValidation()
        {
            RuleFor(i => i.SaleId)
                .GreaterThan(0).WithMessage("SaleId must be greater than 0");

            RuleFor(i => i.VinylDiscId)
                .GreaterThan(0).WithMessage("VinylDiscId must be greater than 0");

            RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(i => i.Value)
                .GreaterThanOrEqualTo(0).WithMessage("Value cannot be negative");

            RuleFor(i => i.Cashback)
                .GreaterThanOrEqualTo(0).WithMessage("Cashback cannot be negative");
        }
    }
}