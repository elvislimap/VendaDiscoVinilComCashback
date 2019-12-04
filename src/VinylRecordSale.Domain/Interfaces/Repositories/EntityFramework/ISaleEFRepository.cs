using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.EntityFramework.Common;

namespace VinylRecordSale.Domain.Interfaces.Repositories.EntityFramework
{
    public interface ISaleEFRepository : IEFRepositoryBase
    {
        void Insert(Sale sale);
    }
}