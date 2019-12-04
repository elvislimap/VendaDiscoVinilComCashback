using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.EntityFramework;
using VinylRecordSale.Infra.Data.Contexts;
using VinylRecordSale.Infra.Data.Repositories.EntityFramework.Commons;

namespace VinylRecordSale.Infra.Data.Repositories.EntityFramework
{
    public class SaleEFRepository : EFRepositoryBase, ISaleEFRepository
    {
        private readonly ContextEf _contextEf;

        public SaleEFRepository(ContextEf contextEf) : base(contextEf)
        {
            _contextEf = contextEf;
        }


        public void Insert(Sale sale)
        {
            _contextEf.Sales.Add(sale);
            _contextEf.SaveChanges();
        }
    }
}