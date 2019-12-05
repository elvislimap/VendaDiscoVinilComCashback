using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using VinylRecordSale.Domain.Commons;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Infra.Data.Mappings.EntityFramework
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.ClientId);
            builder.Property(c => c.ClientId).HasColumnType("int").ValueGeneratedOnAdd();

            builder.Property(c => c.FullName).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();

            builder.HasData(GetData());
        }

        private static IEnumerable<Client> GetData()
        {
            var clients = new List<Client>();

            for (var i = 1; i <= 10; i++)
            {
                var client = new Faker<Client>(Constants.LanguageBogus)
                    .CustomInstantiator(f => new Client(0, f.Name.FullName(), null))
                    .Generate();

                clients.Add(new Faker<Client>(Constants.LanguageBogus)
                    .CustomInstantiator(f =>
                        new Client(i, client.FullName, f.Internet.Email(client.FullName.ToLower())))
                    .Generate());
            }

            return clients;
        }
    }
}