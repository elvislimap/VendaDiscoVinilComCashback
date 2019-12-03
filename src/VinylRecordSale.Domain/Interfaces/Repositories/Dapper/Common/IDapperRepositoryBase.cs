using System;

namespace VinylRecordSale.Domain.Interfaces.Repositories.Dapper.Common
{
    public interface IDapperRepositoryBase<out TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(int id);
    }
}