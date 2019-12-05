using System.Collections.Generic;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper.Common;

namespace VinylRecordSale.Domain.Interfaces.Repositories.Dapper
{
    public interface IVinylDiscDapperRepository : IDapperRepositoryBase<VinylDisc>
    {
        Task<IEnumerable<VinylDisc>> Get(int page, int musicGenreId);
    }
}