using System.Threading.Tasks;

namespace VinylRecordSale.Domain.Interfaces.Services
{
    public interface IConfigCashbackService
    {
        Task<decimal> GetPercentage(int musicGenreId);
    }
}