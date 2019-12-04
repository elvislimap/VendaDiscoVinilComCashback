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

        public int ClientId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public virtual IList<Sale> Sales { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}