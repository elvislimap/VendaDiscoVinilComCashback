using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings.EntityFramework
{
    public class ItemSaleMapping : IEntityTypeConfiguration<ItemSale>
    {
        public void Configure(EntityTypeBuilder<ItemSale> builder)
        {
            builder.HasKey(i => i.ItemSaleId);
            builder.Property(i => i.ItemSaleId).HasColumnType("int").ValueGeneratedOnAdd();

            builder.HasOne(i => i.Sale).WithMany(s => s.ItemSales);
            builder.HasOne(i => i.VinylDisc).WithMany(v => v.ItemSales);

            builder.Property(i => i.SaleId).HasColumnType("int").IsRequired();
            builder.Property(i => i.VinylDiscId).HasColumnType("int").IsRequired();
            builder.Property(i => i.Quantity).HasColumnType("int").IsRequired();
            builder.Property(i => i.Value).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(i => i.Cashback).HasColumnType("decimal(10,2)").IsRequired();

            builder.Ignore(i => i.ValidationResult);
        }
    }
}