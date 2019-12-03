using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Commons;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Enums;
using VinylRecordSale.Domain.IntegrationValues;
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


        public void Configure(EntityTypeBuilder<VinylDisc> builder)
        {
            builder.HasKey(v => v.VinylDiscId);
            builder.Property(v => v.VinylDiscId).HasColumnType("int").ValueGeneratedOnAdd();

            builder.HasOne(v => v.MusicGenre).WithMany(g => g.VinylDiscs);

            builder.Property(v => v.MusicGenreId).HasColumnType("int").IsRequired();
            builder.Property(v => v.Name).HasColumnType("varchar(200)").HasMaxLength(200).IsRequired();
            builder.Property(v => v.Value).HasColumnType("decimal(10,2)").IsRequired();

            builder.Ignore(v => v.ValidationResult);

            builder.HasData(GetVinylDiscs());
        }


        private IEnumerable<VinylDisc> GetVinylDiscs()
        {
            var albums = GetResponseAlbum(50);
            var discs = new List<VinylDisc>();

            if (albums == null || !albums.Any())
                return discs;

            var i = 1;

            discs.AddRange(from album in albums
                           from track in album.tracks
                           select new VinylDisc
                           (i++, (int)album.music_genre, track.album.name, Randoms.Decimal(10.9, 99.9)));

            return discs;
        }

        private List<ResponseGetAlbumSpotify> GetResponseAlbum(int maxByGenre)
        {
            return new List<ResponseGetAlbumSpotify>
            {
                Task.Run(() =>
                        _spotifyIntegrationService.GetAlbumsByGenres(MusicGenreEnum.Pop, maxByGenre))
                    .Result,
                Task.Run(() =>
                        _spotifyIntegrationService.GetAlbumsByGenres(MusicGenreEnum.Mpb, maxByGenre))
                    .Result,
                Task.Run(() =>
                        _spotifyIntegrationService.GetAlbumsByGenres(MusicGenreEnum.Classic, maxByGenre))
                    .Result,
                Task.Run(() =>
                        _spotifyIntegrationService.GetAlbumsByGenres(MusicGenreEnum.Rock, maxByGenre))
                    .Result
            };
        }
    }
}