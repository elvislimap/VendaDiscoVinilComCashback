using FluentValidation.Results;
using System;

namespace VinylRecordSale.Domain.Entities
{
    public abstract class Entity
    {
        public ValidationResult ValidationResult { get; protected set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException("This method must be overridden");
        }
    }
}