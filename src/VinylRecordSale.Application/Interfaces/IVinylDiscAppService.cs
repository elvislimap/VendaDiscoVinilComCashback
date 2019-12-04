using VinylRecordSale.Domain.ValueObjects;

namespace VinylRecordSale.Application.Interfaces
{
    public interface IVinylDiscAppService
    {
        Result Get(int vinylDiscId);
        Result GetPaged(int page, int musicGenreId);
    }
}