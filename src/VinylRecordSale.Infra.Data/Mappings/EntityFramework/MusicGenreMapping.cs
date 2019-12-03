using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings.EntityFramework
{
    public class MusicGenreMapping : IEntityTypeConfiguration<MusicGenre>
    {
        public void Configure(EntityTypeBuilder<MusicGenre> builder)
        {
            builder.HasKey(m => m.MusicGenreId);

            builder.Property(m => m.MusicGenreId).HasColumnType("int");
            builder.Property(m => m.Description).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.Ignore(m => m.ValidationResult);

            builder.HasData(
                new MusicGenre(1, "Pop"),
                new MusicGenre(2, "Mpb"),
                new MusicGenre(3, "Classic"),
                new MusicGenre(4, "Rock"));
        }
    }
}