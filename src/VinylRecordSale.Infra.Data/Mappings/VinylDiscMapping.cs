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
        private readonly IEnumerable<VinylDisc> _vinylDiscs;

        public VinylDiscMapping(IEnumerable<VinylDisc> vinylDiscs)
        {
            _vinylDiscs = vinylDiscs;
        }


        public void Configure(EntityTypeBuilder<VinylDisc> builder)
        {
            builder.HasKey(v => v.VinylDiscId);
            builder.Property(v => v.VinylDiscId).HasColumnType("int").ValueGeneratedOnAdd();

            builder.HasOne(v => v.MusicGenre).WithMany(g => g.VinylDiscs);

            builder.Property(v => v.GenreId).HasColumnType("int").IsRequired();
            builder.Property(v => v.Name).HasColumnType("varchar(200)").HasMaxLength(200).IsRequired();
            builder.Property(v => v.Value).HasColumnType("decimal(10,2)").IsRequired();

            builder.HasData(_vinylDiscs);
        }

        
    }
}