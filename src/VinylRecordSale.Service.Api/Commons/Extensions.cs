using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using VinylRecordSale.Infra.Data.Contexts;
using VinylRecordSale.Service.Api.Configurations;

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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }

        public static void RegisterServiceSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => { c.OperationFilter<SwaggerDefaultValues>(); });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }

        public static void UseSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                });
        }
    }
}