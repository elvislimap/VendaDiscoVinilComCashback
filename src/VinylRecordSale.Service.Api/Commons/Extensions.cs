using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Threading.Tasks;
using VinylRecordSale.Domain.ValueObjects;
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

        public static Task<ObjectResult> TaskResult(this Result result)
        {
            var taskResult = new TaskCompletionSource<ObjectResult>();
            var objectResult = new ObjectResult(result) { StatusCode = result.GetStatusCode() };

            taskResult.SetResult(objectResult);

            return taskResult.Task;
        }


        private static int GetStatusCode(this Result result)
        {
            return result.IsValid
                ? (int)HttpStatusCode.OK
                : (int)HttpStatusCode.BadRequest;
        }
    }
}