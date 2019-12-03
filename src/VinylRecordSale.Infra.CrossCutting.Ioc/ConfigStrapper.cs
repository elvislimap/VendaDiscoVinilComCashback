using Microsoft.Extensions.DependencyInjection;
using VinylRecordSale.Domain.Interfaces.Contexts;
using VinylRecordSale.Domain.Interfaces.Integrations;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Infra.Data.Contexts;
using VinylRecordSale.Infra.Data.Repositories.Dapper;
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

            #region Contexts

            services.AddScoped<IContextDapper, ContextDapper>();

            #endregion

            #region Dapper repositories

            services.AddScoped<IVinylDiscDapperRepository, VinylDiscDapperRepository>();
            services.AddScoped<ISaleDapperRepository, SaleDapperRepository>();

            #endregion
        }
    }
}