using System;
using System.Data;
using System.Threading.Tasks;
using Dommel;
using VinylRecordSale.Domain.Interfaces.Contexts;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper.Common;

namespace VinylRecordSale.Infra.Data.Repositories.Dapper.Commons
{
    public abstract class DapperRepositoryBase<TEntity> : IDapperRepositoryBase<TEntity> where TEntity : class
    {
        private readonly IContextDapper _context;

        protected DapperRepositoryBase(IContextDapper context)
        {
            _context = context;
        }


        public virtual async Task<TEntity> GetById(int id)
        {
            return await _context.Connection.GetAsync<TEntity>(id);
        }

        public void Dispose()
        {
            if (_context.Connection.State != ConnectionState.Closed)
            {
                _context.Connection.Close();
                _context.Connection.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}