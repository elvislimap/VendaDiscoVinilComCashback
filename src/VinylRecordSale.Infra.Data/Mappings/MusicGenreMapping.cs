using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings
{
    public class MusicGenreMapping : IEntityTypeConfiguration<MusicGenre>
    {
        public void Configure(EntityTypeBuilder<MusicGenre> builder)
        {
            builder.HasKey(m => m.MusicGenreId);

            builder.Property(m => m.MusicGenreId).HasColumnType("int");
            builder.Property(m => m.Description).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.HasData(
                new MusicGenre { MusicGenreId = 1, Description = "Pop" },
                new MusicGenre { MusicGenreId = 2, Description = "Mpb" },
                new MusicGenre { MusicGenreId = 3, Description = "Classic" },
                new MusicGenre { MusicGenreId = 4, Description = "Rock" });
        }
    }
}