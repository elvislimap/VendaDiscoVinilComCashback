using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings
{
    public class SaleMapping : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.SaleId);
            builder.Property(s => s.SaleId).HasColumnName("int").ValueGeneratedOnAdd();

            builder.HasOne(s => s.Client).WithMany(c => c.Sales);

            builder.Property(s => s.ClientId).HasColumnName("int").IsRequired();
            builder.Property(s => s.TotalValue).HasColumnName("decimal(10,2)").IsRequired();
            builder.Property(s => s.CashbackTotal).HasColumnName("decimal(10,2)").IsRequired();
            builder.Property(s => s.Date).HasColumnName("datetime").IsRequired();
        }
    }
}