using System;
using System.Collections.Generic;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper.Common;

namespace VinylRecordSale.Domain.Interfaces.Repositories.Dapper
{
    public interface ISaleDapperRepository : IDapperRepositoryBase<Sale>
    {
        IEnumerable<Sale> Get(int page, DateTime initialDate, DateTime finalDate);
    }
}