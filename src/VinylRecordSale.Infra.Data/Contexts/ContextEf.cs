using Microsoft.EntityFrameworkCore;
using VinylRecordSale.Domain.Entities;
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

            modelBuilder.ApplyConfiguration(new MusicGenreMapping());
            modelBuilder.ApplyConfiguration(new ConfigCashbackMapping());
            modelBuilder.ApplyConfiguration(new ClientMapping());
            modelBuilder.ApplyConfiguration(new VinylDiscMapping(_spotifyIntegrationService));
            modelBuilder.ApplyConfiguration(new SaleMapping());
            modelBuilder.ApplyConfiguration(new ItemSaleMapping());
        }
    }
}