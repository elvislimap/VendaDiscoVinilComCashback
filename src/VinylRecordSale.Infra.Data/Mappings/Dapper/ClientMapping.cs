using Dapper.FluentMap.Dommel.Mapping;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings.Dapper
{
    public class ClientMapping : DommelEntityMap<Client>
    {
        public ClientMapping()
        {
            ToTable("VinylRecordSale.Clients");
            Map(c => c.ClientId).IsKey().IsIdentity();
        }
    }
}