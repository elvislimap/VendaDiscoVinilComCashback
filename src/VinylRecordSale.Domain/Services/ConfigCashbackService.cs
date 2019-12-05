using System;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.Interfaces.Services;

namespace VinylRecordSale.Domain.Services
{
    public class ConfigCashbackService : BaseService, IConfigCashbackService
    {
        private readonly IConfigCashbackDapperRepository _configCashbackDapperRepository;

        public ConfigCashbackService(INotificationService notificationService,
            IConfigCashbackDapperRepository configCashbackDapperRepository) : base(notificationService)
        {
            _configCashbackDapperRepository = configCashbackDapperRepository;
        }


        public async Task<decimal> GetPercentage(int musicGenreId)
        {
            var configCashback = await _configCashbackDapperRepository.GetById(musicGenreId);

            if (!ConfigCashback.Exists(configCashback))
            {
                Notify($"ConfigCashback with music genre id: {musicGenreId} not exists");
                return 0;
            }

            return GetPercentageByDayOfWeek(configCashback);
        }


        private static decimal GetPercentageByDayOfWeek(ConfigCashback configCashback)
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return configCashback.PercentageSunday;
                case DayOfWeek.Monday:
                    return configCashback.PercentageMonday;
                case DayOfWeek.Tuesday:
                    return configCashback.PercentageTuesday;
                case DayOfWeek.Wednesday:
                    return configCashback.PercentageWednesday;
                case DayOfWeek.Thursday:
                    return configCashback.PercentageThursday;
                case DayOfWeek.Friday:
                    return configCashback.PercentageFriday;
                default:
                    return configCashback.PercentageSaturday;
            }
        }
    }
}