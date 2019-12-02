using Bogus;
using Bogus.DataSets;
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
            builder.HasKey(m => m.ClientId);
            builder.Property(m => m.ClientId).HasColumnType("int").ValueGeneratedOnAdd();

            builder.Property(m => m.FullName).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();

            builder.HasData(GetData());
        }

        private IEnumerable<Client> GetData()
        {
            var i = 1;
            var client = new Faker<Client>("pt_BR")
            .CustomInstantiator(f => new Client
            {
                FullName = f.Name.FullName(new Faker().PickRandom<Name.Gender>())
            })
            .RuleFor(c => c.ClientId, f => i++)
            .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FullName.ToLower()));

            return client.Generate(10);
        }
    }
}