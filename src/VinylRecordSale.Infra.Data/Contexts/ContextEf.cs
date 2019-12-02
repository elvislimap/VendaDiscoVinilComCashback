using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Commons;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Enums;
using VinylRecordSale.Domain.Interfaces.Integrations;
using VinylRecordSale.Infra.Data.Mappings;

namespace VinylRecordSale.Infra.Data.Contexts
{
    public class ContextEf : DbContext
    {
        private readonly ISpotifyIntegrationService _spotifyIntegrationService;

        public ContextEf(DbContextOptions options, ISpotifyIntegrationService spotifyIntegrationService)
            : base(options)
        {
            _spotifyIntegrationService = spotifyIntegrationService;
        }


        public DbSet<MusicGenre> MusicGenres { get; set; }
        public DbSet<ConfigCashback> ConfigCashbacks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<VinylDisc> VinylDiscs { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ItemSale> ItemSales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("VinylRecordSale");

            var pop = Task.Run(() =>
                _spotifyIntegrationService.GetAlbumsByGenres(MusicGenreEnum.Pop, 50)).Result();

            var mpb = Task.Run(() =>
                _spotifyIntegrationService.GetAlbumsByGenres(MusicGenreEnum.Mpb, 50)).Result();

            var classic = Task.Run(() =>
                _spotifyIntegrationService.GetAlbumsByGenres(MusicGenreEnum.Classic, 50)).Result();

            var rock = Task.Run(() =>
                _spotifyIntegrationService.GetAlbumsByGenres(MusicGenreEnum.Rock, 50)).Result();

            var vinylDiscs = new List<VinylDisc>();

            vinylDiscs.AddRange(GetVinylDiscs(pop, MusicGenreEnum.Pop));
            vinylDiscs.AddRange(GetVinylDiscs(mpb, MusicGenreEnum.Mpb));
            vinylDiscs.AddRange(GetVinylDiscs(classic, MusicGenreEnum.Classic));
            vinylDiscs.AddRange(GetVinylDiscs(rock, MusicGenreEnum.Rock));

            modelBuilder.ApplyConfiguration(new MusicGenreMapping());
            modelBuilder.ApplyConfiguration(new ConfigCashbackMapping());
            modelBuilder.ApplyConfiguration(new ClientMapping());
            modelBuilder.ApplyConfiguration(new VinylDiscMapping(vinylDiscs));
            modelBuilder.ApplyConfiguration(new SaleMapping());
            modelBuilder.ApplyConfiguration(new ItemSaleMapping());
        }


        private IEnumerable<VinylDisc> GetVinylDiscs(dynamic albums, MusicGenreEnum genreEnum)
        {
            var vinylDiscs = new List<VinylDisc>();

            if (albums == null)
                return vinylDiscs;

            foreach (var item in albums.tracks)
            {
                vinylDiscs.Add(
                    new VinylDisc
                    {
                        GenreId = (int)genreEnum,
                        Name = item.album.name,
                        Value = Randoms.Decimal(10.9, 99.9)
                    });
            }

            return vinylDiscs;
        }
    }
}