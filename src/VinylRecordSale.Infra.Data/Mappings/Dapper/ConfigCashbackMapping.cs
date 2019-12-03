using Dapper.FluentMap.Dommel.Mapping;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings.Dapper
{
    public class ConfigCashbackMapping : DommelEntityMap<ConfigCashback>
    {
        public ConfigCashbackMapping()
        {
            ToTable("VinylRecordSale.ConfigCashbacks");
            Map(c => c.MusicGenreId).IsKey();
            Map(c => c.ValidationResult).Ignore();
        }
    }
}