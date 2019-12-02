using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using VinylRecordSale.Domain.Commons;
using VinylRecordSale.Domain.Enums;
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

        
        public async Task<dynamic> GetAlbumsByGenres(MusicGenreEnum genreEnum, int maxByGenre)
        {
            var token = await GenerateToken();
            var request = GetRequestAlbumsByGenres(genreEnum, maxByGenre, token);

            using (var client = _clientFactory.CreateClient())
            {
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<dynamic>(json);
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
                var authSpotify = JsonSerializer.Deserialize<dynamic>(json);

                return authSpotify.access_token;
            }
        }

        private HttpRequestMessage GetRequestGenerateToken()
        {
            var spotifyConfig = _configuration.GetSection("SpotifyConfig");
            var clientId = spotifyConfig.GetSection("ClientId").Value;
            var clientSecret = spotifyConfig.GetSection("ClientSecret").Value;

            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("scope", "user-read-private user-read-email")
                });

            var request = new HttpRequestMessage(HttpMethod.Post, UriToken) { Content = content };

            request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            request.Headers.Add("Authorization", $"Basic {clientId}:{clientSecret}".ToBase64());

            return request;
        }

        private HttpRequestMessage GetRequestAlbumsByGenres(MusicGenreEnum genreEnum, int maxByGenre, string token)
        {
            var uri = new UriBuilder(UriAlbums);
            var query = HttpUtility.ParseQueryString(uri.Query);

            query.Add("limit", maxByGenre.ToText());
            query.Add("market", "PT");
            query.Add("seed_genres", genreEnum.GetNameMusicGenre());

            var request = new HttpRequestMessage(HttpMethod.Get, UriAlbums);
            request.Headers.Add("Authorization", $"Bearer {token}");

            return request;
        }
    }
}
