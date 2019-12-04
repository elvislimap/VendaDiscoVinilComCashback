using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Contexts;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Infra.Data.Repositories.Dapper.Commons;

namespace VinylRecordSale.Infra.Data.Repositories.Dapper
{
    public class ClientDapperRepository : DapperRepositoryBase<Client>, IClientDapperRepository
    {
        public ClientDapperRepository(IContextDapper context) : base(context) { }
    }
}