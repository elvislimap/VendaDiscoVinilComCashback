using System.Threading.Tasks;
using VinylRecordSale.Domain.Entities;

namespace VinylRecordSale.Application.Interfaces
{
    public interface ISaleAppService
    {
        Task<Sale> Insert(Sale sale);
    }
}