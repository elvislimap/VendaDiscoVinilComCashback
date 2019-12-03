using Dapper.FluentMap.Dommel.Mapping;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings.Dapper
{
    public class VinylDiscMapping : DommelEntityMap<VinylDisc>
    {
        public VinylDiscMapping()
        {
            ToTable("VinylRecordSale.VinylDiscs");
            Map(c => c.VinylDiscId).IsKey().IsIdentity();
            Map(c => c.ValidationResult).Ignore();
        }
    }
}