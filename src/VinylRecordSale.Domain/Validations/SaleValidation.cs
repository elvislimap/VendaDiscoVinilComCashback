using FluentValidation;
using System;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Domain.Validations
{
    public class SaleValidation : AbstractValidator<Sale>
    {
        public SaleValidation()
        {
            RuleFor(s => s.ClientId)
                .GreaterThan(0).WithMessage("ClientId must be greater than 0");

            RuleFor(s => s.TotalValue)
                .GreaterThanOrEqualTo(0).WithMessage("TotalValue cannot be negative");

            RuleFor(s => s.CashbackTotal)
                .GreaterThanOrEqualTo(0).WithMessage("CashbackTotal cannot be negative");

            RuleFor(s => s.Date)
                .NotEqual(DateTime.MinValue).WithMessage("Date invalid")
                .NotEqual(DateTime.MaxValue).WithMessage("Date invalid");
        }
    }
}