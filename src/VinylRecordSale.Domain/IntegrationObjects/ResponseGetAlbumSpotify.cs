using VinylRecordSale.Domain.Enums;

namespace VinylRecordSale.Domain.IntegrationObjects
{
    public class ResponseGetAlbumSpotify
    {
        public TrackSpotify[] tracks { get; set; }
        public MusicGenreEnum music_genre { get; set; }
    }
}