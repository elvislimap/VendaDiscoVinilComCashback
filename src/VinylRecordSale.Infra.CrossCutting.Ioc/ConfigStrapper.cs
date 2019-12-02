using Microsoft.Extensions.DependencyInjection;
using VinylRecordSale.Domain.Interfaces.Integrations;
using VinylRecordSale.Infra.Integrations.Spotify;

namespace VinylRecordSale.Infra.CrossCutting.Ioc
{
    public static class ConfigStrapper
    {
        public static void RegisterServicesIoc(this IServiceCollection services)
        {
            #region Integrations

            services.AddScoped<ISpotifyIntegrationService, SpotifyIntegrationService>();

            #endregion
        }
    }
}