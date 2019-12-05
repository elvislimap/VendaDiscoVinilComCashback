using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings.EntityFramework
{
    public class SaleMapping : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.SaleId);
            builder.Property(s => s.SaleId).HasColumnType("int").ValueGeneratedOnAdd();

            builder.HasOne(s => s.Client).WithMany(c => c.Sales);

            builder.Property(s => s.ClientId).HasColumnType("int").IsRequired();
            builder.Property(s => s.TotalValue).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(s => s.CashbackTotal).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(s => s.Date).HasColumnType("datetime").IsRequired();
        }
    }
}