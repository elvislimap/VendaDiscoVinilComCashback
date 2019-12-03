using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Contexts;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Infra.Data.Repositories.Dapper.Common;

namespace VinylRecordSale.Infra.Data.Repositories.Dapper
{
    public class SaleDapperRepository : DapperRepositoryBase<Sale>, ISaleDapperRepository
    {
        public SaleDapperRepository(IContextDapper contextDapper) : base(contextDapper)
        {
        }
    }
}