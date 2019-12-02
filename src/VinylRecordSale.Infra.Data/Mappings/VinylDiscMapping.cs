using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Commons;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Enums;
using VinylRecordSale.Domain.Interfaces.Integrations;

namespace VinylRecordSale.Infra.Data.Mappings
{
    public class VinylDiscMapping : IEntityTypeConfiguration<VinylDisc>
    {
        private readonly ISpotifyIntegrationService _spotifyIntegrationService;

        public VinylDiscMapping(ISpotifyIntegrationService spotifyIntegrationService)
        {
            _spotifyIntegrationService = spotifyIntegrationService;
        }


        public async void Configure(EntityTypeBuilder<VinylDisc> builder)
        {
            builder.HasKey(v => v.VinylDiscId);
            builder.Property(v => v.VinylDiscId).HasColumnName("int").ValueGeneratedOnAdd();

            builder.HasOne(v => v.MusicGenre).WithMany(g => g.VinylDiscs);

            builder.Property(v => v.GenreId).HasColumnName("int").IsRequired();
            builder.Property(v => v.Name).HasColumnName("varchar(200)").HasMaxLength(200).IsRequired();
            builder.Property(v => v.Value).HasColumnName("decimal(10,2)").IsRequired();

            builder.HasData(await GetData(MusicGenreEnum.Pop));
            builder.HasData(await GetData(MusicGenreEnum.Mpb));
            builder.HasData(await GetData(MusicGenreEnum.Classic));
            builder.HasData(await GetData(MusicGenreEnum.Rock));
        }

        private async Task<IEnumerable<VinylDisc>> GetData(MusicGenreEnum genreEnum)
        {
            var vinylDiscs = new List<VinylDisc>();
            var albums = await _spotifyIntegrationService.GetAlbumsByGenres(genreEnum, 50);

            if (albums == null)
                return vinylDiscs;

            foreach (var item in albums.tracks)
            {
                vinylDiscs.Add(
                    new VinylDisc
                    {
                        GenreId = (int)MusicGenreEnum.Pop,
                        Name = item.album.name,
                        Value = Randoms.Decimal(10.9, 99.9)
                    });
            }

            return vinylDiscs;
        }
    }
}