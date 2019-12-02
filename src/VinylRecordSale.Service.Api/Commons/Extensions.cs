using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using VinylRecordSale.Infra.Data.Contexts;

namespace VinylRecordSale.Service.Api.Commons
{
    public static class Extensions
    {
        public static void RegisterServicesApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddCors();

            services.AddDbContext<ContextEf>(
                opt => opt.UseSqlServer(configuration.GetConnectionString("VinylRecordSaleContext"),
                b => b.MigrationsAssembly("VinylRecordSale.Service.Api")));

            services.AddMvc()
                .AddJsonOptions(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}