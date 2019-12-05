using Dapper.FluentMap.Dommel.Mapping;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings.Dapper
{
    public class ItemSaleMapping : DommelEntityMap<ItemSale>
    {
        public ItemSaleMapping()
        {
            ToTable("VinylRecordSale.ItemSales");
            Map(i => i.ItemSaleId).IsKey().IsIdentity();
        }
    }
}