using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Commons;
using VinylRecordSale.Domain.Enums;
using VinylRecordSale.Domain.IntegrationValues;
using VinylRecordSale.Domain.Interfaces.Integrations;

namespace VinylRecordSale.Infra.Integrations.Spotify
{
    public class SpotifyIntegrationService : ISpotifyIntegrationService
    {
        private const string UriToken = @"https://accounts.spotify.com/api/token";
        private const string UriAlbums = @"https://api.spotify.com/v1/recommendations";

        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public SpotifyIntegrationService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }


        public async Task<ResponseGetAlbumSpotify> GetAlbumsByGenres(MusicGenreEnum genreEnum, int maxByGenre)
        {
            var token = await GenerateToken();
            var request = GetRequestAlbumsByGenres(genreEnum, maxByGenre, token);

            using (var client = _clientFactory.CreateClient())
            {
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();
                var responseGetAlbum = JsonConvert.DeserializeObject<ResponseGetAlbumSpotify>(json);

                responseGetAlbum.music_genre = genreEnum;

                return responseGetAlbum;
            }
        }

        private async Task<string> GenerateToken()
        {
            var request = GetRequestGenerateToken();

            using (var client = _clientFactory.CreateClient())
            {
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();
                var responseToken = JsonConvert.DeserializeObject<ResponseTokenSpotify>(json);

                return responseToken.access_token;
            }
        }

        private HttpRequestMessage GetRequestGenerateToken()
        {
            var spotifyConfig = _configuration.GetSection("SpotifyConfig");
            var clientId = spotifyConfig.GetSection("ClientId").Value;
            var clientSecret = spotifyConfig.GetSection("ClientSecret").Value;
            var tokenBase64 = $"{clientId}:{clientSecret}".ToBase64();

            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("scope", "user-read-private user-read-email")
                });

            var request = new HttpRequestMessage(HttpMethod.Post, UriToken) { Content = content };

            request.Headers.Add("Authorization", $"Basic {tokenBase64}");

            return request;
        }

        private static HttpRequestMessage GetRequestAlbumsByGenres(MusicGenreEnum genreEnum, int maxByGenre,
            string token)
        {
            var builder = new UriBuilder(UriAlbums)
            {
                Query = $"limit={maxByGenre.ToText()}&market=PT&seed_genres={genreEnum.GetNameMusicGenre()}"
            };

            var request = new HttpRequestMessage(HttpMethod.Get, builder.Uri);
            request.Headers.Add("Authorization", $"Bearer {token}");

            return request;
        }
    }
}