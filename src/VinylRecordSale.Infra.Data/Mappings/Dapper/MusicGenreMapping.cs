using Dapper.FluentMap.Dommel.Mapping;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings.Dapper
{
    public class MusicGenreMapping : DommelEntityMap<MusicGenre>
    {
        public MusicGenreMapping()
        {
            ToTable("VinylRecordSale.MusicGenres");
            Map(m => m.MusicGenreId).IsKey();
        }
    }
}