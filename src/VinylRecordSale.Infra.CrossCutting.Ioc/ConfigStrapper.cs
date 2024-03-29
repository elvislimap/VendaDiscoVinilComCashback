﻿using Microsoft.Extensions.DependencyInjection;
using VinylRecordSale.Application.Interfaces;
using VinylRecordSale.Application.Services;
using VinylRecordSale.Domain.Interfaces.Contexts;
using VinylRecordSale.Domain.Interfaces.Integrations;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.Interfaces.Repositories.EntityFramework;
using VinylRecordSale.Domain.Interfaces.Services;
using VinylRecordSale.Domain.Services;
using VinylRecordSale.Infra.Data.Contexts;
using VinylRecordSale.Infra.Data.Repositories.Dapper;
using VinylRecordSale.Infra.Data.Repositories.EntityFramework;
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
            services.AddScoped<IConfigCashbackDapperRepository, ConfigCashbackDapperRepository>();
            services.AddScoped<IClientDapperRepository, ClientDapperRepository>();

            #endregion

            #region EF repositories

            services.AddScoped<ISaleEFRepository, SaleEfRepository>();

            #endregion

            #region AppServices

            services.AddScoped<ISaleAppService, SaleAppService>();

            #endregion

            #region Services

            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IItemSaleService, ItemSaleService>();
            services.AddScoped<IConfigCashbackService, ConfigCashbackService>();

            #endregion
        }
    }
}