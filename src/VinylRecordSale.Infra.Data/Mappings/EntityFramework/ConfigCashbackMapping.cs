using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Enums;

namespace VinylRecordSale.Infra.Data.Mappings.EntityFramework
{
    public class ConfigCashbackMapping : IEntityTypeConfiguration<ConfigCashback>
    {
        public void Configure(EntityTypeBuilder<ConfigCashback> builder)
        {
            builder.HasKey(c => c.MusicGenreId);

            builder.Property(c => c.MusicGenreId).HasColumnType("int").IsRequired();
            builder.Property(c => c.PercentageSunday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageMonday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageTuesday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageWednesday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageThursday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageFriday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();
            builder.Property(c => c.PercentageSaturday).HasColumnType("decimal(10,2)").HasDefaultValue(0M).IsRequired();

            builder.HasData(
                new ConfigCashback((int)MusicGenreEnum.Pop, 25, 7, 6, 2, 10, 15, 20),
                new ConfigCashback((int)MusicGenreEnum.Mpb, 30, 5, 10, 15, 20, 25, 30),
                new ConfigCashback((int)MusicGenreEnum.Classic, 35, 3, 5, 8, 13, 18, 25),
                new ConfigCashback((int)MusicGenreEnum.Rock, 40, 10, 15, 15, 15, 20, 40));
        }
    }
}