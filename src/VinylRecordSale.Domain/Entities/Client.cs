using System.Collections.Generic;

namespace VinylRecordSale.Domain.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public IEnumerable<Sale> Sales { get; set; }
    }
}