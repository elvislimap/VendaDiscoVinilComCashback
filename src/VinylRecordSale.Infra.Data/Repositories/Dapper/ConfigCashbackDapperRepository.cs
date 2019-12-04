using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Contexts;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Infra.Data.Repositories.Dapper.Commons;

namespace VinylRecordSale.Infra.Data.Repositories.Dapper
{
    public class ConfigCashbackDapperRepository : DapperRepositoryBase<ConfigCashback>, IConfigCashbackDapperRepository
    {
        public ConfigCashbackDapperRepository(IContextDapper context) : base(context) { }
    }
}