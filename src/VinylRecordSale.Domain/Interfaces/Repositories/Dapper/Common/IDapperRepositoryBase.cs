using System;
using System.Threading.Tasks;

namespace VinylRecordSale.Domain.Interfaces.Repositories.Dapper.Common
{
    public interface IDapperRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetById(int id);
    }
}