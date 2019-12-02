using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings
{
    public class ItemSaleMapping : IEntityTypeConfiguration<ItemSale>
    {
        public void Configure(EntityTypeBuilder<ItemSale> builder)
        {
            builder.HasKey(i => i.ItemSaleId);
            builder.Property(i => i.ItemSaleId).HasColumnName("int").ValueGeneratedOnAdd();

            builder.HasOne(i => i.Sale).WithMany(s => s.ItemSales);
            builder.HasOne(i => i.VinylDisc).WithMany(v => v.ItemSales);

            builder.Property(i => i.SaleId).HasColumnName("int").IsRequired();
            builder.Property(i => i.VinylDisc).HasColumnName("int").IsRequired();
            builder.Property(i => i.Quantity).HasColumnName("int").IsRequired();
            builder.Property(i => i.Value).HasColumnName("decimal(10,2)").IsRequired();
            builder.Property(i => i.Cashback).HasColumnName("decimal(10,2)").IsRequired();
        }
    }
}