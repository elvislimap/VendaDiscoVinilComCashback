using System;
using System.Data;
using Dommel;
using VinylRecordSale.Domain.Interfaces.Contexts;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper.Common;

namespace VinylRecordSale.Infra.Data.Repositories.Dapper.Common
{
    public class DapperRepositoryBase<TEntity> : IDapperRepositoryBase<TEntity> where TEntity : class
    {
        private readonly IContextDapper _context;

        public DapperRepositoryBase(IContextDapper context)
        {
            _context = context;
        }


        public virtual TEntity GetById(int id)
        {
            return _context.Connection.Get<TEntity>(id);
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