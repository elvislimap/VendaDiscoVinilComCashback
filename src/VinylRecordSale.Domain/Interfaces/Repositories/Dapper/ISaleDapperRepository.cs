using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper.Common;

namespace VinylRecordSale.Domain.Interfaces.Repositories.Dapper
{
    public interface ISaleDapperRepository : IDapperRepositoryBase<Sale>
    {
        Task<IEnumerable<Sale>> Get(int page, DateTime initialDate, DateTime finalDate);
    }
}