using System.Threading.Tasks;
using VinylRecordSale.Domain.Enums;
using VinylRecordSale.Domain.IntegrationObjects;

namespace VinylRecordSale.Domain.Interfaces.Integrations
{
    public interface ISpotifyIntegrationService
    {
        Task<ResponseGetAlbumSpotify> GetAlbumsByGenres(MusicGenreEnum genreEnum, int maxByGenre);
    }
}