using System.Collections.Generic;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Domain.Interfaces.Services
{
    public interface IItemSaleService
    {
        Task CalculateProperties(IEnumerable<ItemSale> itemSales);
    }
}