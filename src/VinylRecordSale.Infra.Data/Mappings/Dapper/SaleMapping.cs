using Dapper.FluentMap.Dommel.Mapping;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings.Dapper
{
    public class SaleMapping : DommelEntityMap<Sale>
    {
        public SaleMapping()
        {
            ToTable("VinylRecordSale.Sales");
            Map(s => s.SaleId).IsKey().IsIdentity();
            Map(s => s.ValidationResult).Ignore();
        }
    }
}