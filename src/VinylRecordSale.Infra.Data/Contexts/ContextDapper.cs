using System.Data;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using VinylRecordSale.Domain.Interfaces.Contexts;
using VinylRecordSale.Infra.Data.Mappings.Dapper;

namespace VinylRecordSale.Infra.Data.Contexts
{
    public class ContextDapper : IContextDapper
    {
        public IDbConnection Connection { get; set; }

        public ContextDapper(IConfiguration configuration)
        {
            var config = configuration;

            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapper.Initialize(c =>
                {
                    c.AddMap(new MusicGenreMapping());
                    c.AddMap(new ConfigCashbackMapping());
                    c.AddMap(new ClientMapping());
                    c.AddMap(new VinylDiscMapping());
                    c.AddMap(new SaleMapping());
                    c.AddMap(new ItemSaleMapping());
                    c.ForDommel();
                });
            }

            Connection = new SqlConnection(config.GetConnectionString("VinylRecordSaleContext"));
        }
    }
}