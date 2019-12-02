using System.Threading.Tasks;
using VinylRecordSale.Domain.Enums;

namespace VinylRecordSale.Domain.Interfaces.Integrations
{
    public interface ISpotifyIntegrationService
    {
        Task<dynamic> GetAlbumsByGenres(MusicGenreEnum genreEnum, int maxByGenre);
    }
}