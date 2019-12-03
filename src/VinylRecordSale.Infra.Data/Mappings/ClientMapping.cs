using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.ClientId);
            builder.Property(c => c.ClientId).HasColumnType("int").ValueGeneratedOnAdd();

            builder.Property(c => c.FullName).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();

            builder.Ignore(c => c.ValidationResult);

            builder.HasData(GetData());
        }

        private IEnumerable<Client> GetData()
        {
            var i = 1;
            var client = new Faker<Client>("pt_BR")
            .CustomInstantiator(f => new Client())
            .RuleFor(c => c.ClientId, f => i++)
            .RuleFor(c => c.FullName, (f, c) => f.Name.FullName())
            .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FullName.ToLower()));

            return client.Generate(10);
        }
    }
}