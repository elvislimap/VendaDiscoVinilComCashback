using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Enums;

namespace VinylRecordSale.Infra.Data.Mappings
{
    public class ConfigCashbackMapping : IEntityTypeConfiguration<ConfigCashback>
    {
        public void Configure(EntityTypeBuilder<ConfigCashback> builder)
        {
            builder.HasKey(c => c.GenreId);
            builder.HasOne(c => c.MusicGenre).WithMany(g => g.ConfigCashbacks);

            builder.Property(c => c.GenreId).HasColumnType("int").IsRequired();
            builder.Property(c => c.PercentageSunday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageMonday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageTuesday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageWednesday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageThursday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageFriday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageSaturday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();

            builder.HasData(
                new ConfigCashback
                {
                    GenreId = (int)MusicGenreEnum.Pop,
                    PercentageSunday = 25,
                    PercentageMonday = 7,
                    PercentageTuesday = 6,
                    PercentageWednesday = 2,
                    PercentageThursday = 10,
                    PercentageFriday = 15,
                    PercentageSaturday = 20
                },
                new ConfigCashback
                {
                    GenreId = (int)MusicGenreEnum.Mpb,
                    PercentageSunday = 30,
                    PercentageMonday = 5,
                    PercentageTuesday = 10,
                    PercentageWednesday = 15,
                    PercentageThursday = 20,
                    PercentageFriday = 25,
                    PercentageSaturday = 30
                },
                new ConfigCashback
                {
                    GenreId = (int)MusicGenreEnum.Classic,
                    PercentageSunday = 35,
                    PercentageMonday = 3,
                    PercentageTuesday = 5,
                    PercentageWednesday = 8,
                    PercentageThursday = 13,
                    PercentageFriday = 18,
                    PercentageSaturday = 25
                },
                new ConfigCashback
                {
                    GenreId = (int)MusicGenreEnum.Rock,
                    PercentageSunday = 40,
                    PercentageMonday = 10,
                    PercentageTuesday = 15,
                    PercentageWednesday = 15,
                    PercentageThursday = 15,
                    PercentageFriday = 20,
                    PercentageSaturday = 40
                });
        }
    }
}