using FluentValidation.Results;
using System.Collections.Generic;
using VinylRecordSale.Domain.Validations;

namespace VinylRecordSale.Domain.Entities
{
    public class Client : Entity
    {
        public Client() { }

        public Client(int clientId, string fullName, string email)
        {
            ClientId = clientId;
            FullName = fullName;
            Email = email;
        }

        public int ClientId { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public virtual IEnumerable<Sale> Sales { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new ClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}