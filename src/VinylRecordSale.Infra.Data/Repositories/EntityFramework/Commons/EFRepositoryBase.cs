using System;
using VinylRecordSale.Domain.Interfaces.Repositories.EntityFramework.Common;
using VinylRecordSale.Infra.Data.Contexts;

namespace VinylRecordSale.Infra.Data.Repositories.EntityFramework.Commons
{
    public abstract class EfRepositoryBase : IEFRepositoryBase
    {
        private readonly ContextEf _context;

        protected EfRepositoryBase(ContextEf context)
        {
            _context = context;
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}